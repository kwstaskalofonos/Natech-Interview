using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Natech.Models;
using Natech.Repository.DTO;
using Natech.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Natech.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISaleRepository _SaleRepository;
        private ISellerRepository _SellerRepository;

        public HomeController(ILogger<HomeController> logger, ISaleRepository repository, ISellerRepository repository2)
        {
            _logger = logger;
            _SaleRepository = repository;
            _SellerRepository = repository2;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel();
            homeViewModel.SellersSum = _SellerRepository.Count();
            homeViewModel.SalesSum = _SaleRepository.Sum();

            return View(homeViewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
