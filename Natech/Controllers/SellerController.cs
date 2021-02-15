using Microsoft.AspNetCore.Mvc;
using Natech.Data.Entities;
using Natech.Models;
using Natech.Repository.DTO;
using Natech.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Natech.Controllers
{
    public class SellerController : Controller
    {
        private ISellerRepository _SellerRepository;

        public SellerController(ISellerRepository repository)
        {
            _SellerRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var sellers = new SellerView();
            ModelState.Clear();
            sellers.sellers = new List<SellerDTO>();
            sellers.sellers = await _SellerRepository.GetAll();

            return View(sellers);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SellerView seller)
        {
            var sellers = new SellerView();
            SellerDTO sellerToAdd = new SellerDTO();
            sellerToAdd.FirstName = seller.FirstName;
            sellerToAdd.SurName = seller.SurName;

            await _SellerRepository.Create(sellerToAdd);

            sellers.sellers = new List<SellerDTO>();
            sellers.sellers = await _SellerRepository.GetAll();

            ModelState.Clear();

            return RedirectToAction("Index", sellers);
        }

        [HttpGet]
        public async Task<IActionResult> GetSeller(long SellerId)
        {

            var seller =await _SellerRepository.Get(SellerId);

            return Ok(seller);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromBody]DeleteSeller seller)
        {
            var sellers = new SellerView();
            var deleted = await _SellerRepository.Delete(seller.SellerId);
            sellers.sellers = await _SellerRepository.GetAll();

            ModelState.Clear();

            return Ok(sellers);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SellerView seller)
        {
            var sellers = new SellerView();
            SellerDTO sellerToAdd = new SellerDTO();
            sellerToAdd.FirstName = seller.FirstName;
            sellerToAdd.SurName = seller.SurName;
            sellerToAdd.SellerId = seller.SellerId;

            await _SellerRepository.Update(sellerToAdd);

            sellers.sellers = new List<SellerDTO>();
            sellers.sellers = await _SellerRepository.GetAll();

            ModelState.Clear();

            return RedirectToAction("Index", sellers);
        }

    }
}
