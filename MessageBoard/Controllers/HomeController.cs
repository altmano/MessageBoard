using MessageBoard.Models;
using MessageBoard.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MessageBoard.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ITopicRepository _topicRepository;


        public HomeController(ITopicRepository topicRepository, ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            _topicRepository = topicRepository; 
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel { Categories = _categoryRepository.GetCategories() };
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
