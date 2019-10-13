using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDbExample.Business.Models;
using MongoDbExample.Business.Repository.Interface;
using MongoDbExample.WebSite.Models;

namespace MongoDbExample.WebSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserRepository _userRepository;

        public HomeController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IActionResult> Index()
        {
            var _users = await _userRepository.GetList();
            var result = new ResponseUsersModel
            {
                user = null,
                users = _users
            };
            return View(result);

        }
        [HttpPost]
        public async Task<IActionResult> Index(ResponseUsersModel model)
        {
            var _user = await _userRepository.Create(model.user);
            var _users = await _userRepository.GetList();
            var result = new ResponseUsersModel
            {
                user = _user,
                users = _users
            };
            return View(result);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var _users = await _userRepository.GetById(id);

            return View(_users);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(string id,Users model)
        {
 
            var _users = _userRepository.Update(id, model);
            return RedirectToAction("Index");


        }
        public async Task<IActionResult> Delete(string Id)
        {
            var _user = _userRepository.Delete(Id);
            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
