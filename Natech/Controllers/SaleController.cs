using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Natech.Models;
using Natech.Repository.DTO;
using Natech.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Natech.Controllers
{
    public class SaleController : Controller
    {
        private ISaleRepository _SaleRepository;
        private ISellerRepository _SellerRepository;

        public SaleController(ISaleRepository repository, ISellerRepository repository2)
        {
            _SaleRepository = repository;
            _SellerRepository = repository2;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sales = new SaleView();
            ModelState.Clear();
            sales.sales = new List<SaleDTO>();
            sales.sellers = new List<SelectListItem>();
            sales.sales = await _SaleRepository.GetAll();
            var sellers = await _SellerRepository.GetAll();
            sales.sellers = sellers.Select(q => new SelectListItem
            {
                Text=q.FirstName+" "+q.SurName,
                Value = q.SellerId.ToString()
            }).ToList();

            return View(sales);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaleView sale)
        {
            var sales = new SaleView();
            SaleDTO saleToAdd = new SaleDTO();
            saleToAdd.Amount = sale.Amount;
            saleToAdd.SellerId = sale.Seller;

            await _SaleRepository.Create(saleToAdd);

            sales.sales = new List<SaleDTO>();
            sales.sales = await _SaleRepository.GetAll();

            ModelState.Clear();

            return RedirectToAction("Index", sales);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody] DeleteSale sale)
        {
            var sales = new SaleView();
            var deleted = await _SaleRepository.Delete(sale.SaleId);
            sales.sales = await _SaleRepository.GetAll();

            ModelState.Clear();

            return Ok(sales);
        }

    }
}
