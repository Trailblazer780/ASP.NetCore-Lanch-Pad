using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using launchPad.Models;

namespace launchPad.Controllers {

    public class HomeController : Controller {

        private LaunchPadModel launchPadModel;
        
        public IActionResult Index() {
            // Construction of the model
            launchPadModel = new LaunchPadModel();
            // return to the index view if not logged in
            if (HttpContext.Session.GetString("auth") != "true"){
                return View("Index", launchPadModel);
            }

            return View("Index", launchPadModel);
        }

    }
}
