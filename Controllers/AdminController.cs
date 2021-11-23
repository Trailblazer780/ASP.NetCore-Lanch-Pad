using System;
using Microsoft.AspNetCore.Mvc;
using launchPad.Models;
using Microsoft.AspNetCore.Http;

namespace launchPad.Controllers {

    public class AdminController : Controller {

        private LaunchPadAdminModel launchPadAdminModel;

        public IActionResult Index() {
            // construction of the model
            launchPadAdminModel = new LaunchPadAdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            return View("Index", launchPadAdminModel);
        }

        public IActionResult EditCategory(int cId, string cName) {
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            // Construction of the model
            launchPadAdminModel = new LaunchPadAdminModel(HttpContext);
            // Creating the category object to set the values
            Categories category = new Categories();
            // setting the values
            category.categoryName = cName;
            category.id = cId;
            // returning the view
            return View(category);
        }

    
        public IActionResult EditCategorySubmit(Categories category) {
            launchPadAdminModel = new LaunchPadAdminModel(HttpContext);
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            // If it is satisfied make the changes and save them
            if(ModelState.IsValid){
                launchPadAdminModel.Update(category);
                launchPadAdminModel.SaveChanges();
            }
            // return the view
            return RedirectToAction("Index");
        }

        public IActionResult AddLink(int id, string cName){
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            // construction of the model
            launchPadAdminModel = new LaunchPadAdminModel(HttpContext);
            // setting the variables
            launchPadAdminModel.categoryName = cName;
            launchPadAdminModel.categoryID = id;
            // returning the view
            return View("AddLink", launchPadAdminModel);
        }

        public IActionResult AddLinkSubmit(string linkCategory, string linkName, string linkURL, string isFavourite, int catID) {
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            // Construction of the model
            launchPadAdminModel = new LaunchPadAdminModel(HttpContext);
            // Creating the link object to set the values
            Links link = new Links();
            // setting the values
            link.linkName = linkName;
            link.linkURL = linkURL;
            link.categoryID = catID;
            link.favourite = isFavourite;
            // if it is satisfied add the link and save it
            if(ModelState.IsValid){
                launchPadAdminModel.tblLinks.Add(link);
                launchPadAdminModel.SaveChanges();
            }
            // return the view
            return RedirectToAction("Index", launchPadAdminModel);
        }

        public IActionResult EditLink(int editLinkID, int categoryID, string editLinkName, string editlinkURL, string editFavourite) {
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            // construction of the model
            launchPadAdminModel = new LaunchPadAdminModel(HttpContext);
            // Creating the link object to set the values
            Links link = new Links();
            // getting the select list for the categories
            ViewBag.selectList = launchPadAdminModel.getSelectList();
            // setting the values
            link.id = editLinkID;
            link.linkName = editLinkName;
            link.linkURL = editlinkURL;
            link.categoryID = categoryID;
            link.favourite = editFavourite;
            // returning the view
            return View("EditLink", link);
        }

        public IActionResult EditLinkSubmit(int editLinkID, int categoryID2, string editLinkName, string editlinkURL, string editFavourite) {
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            // Construction of the model
            launchPadAdminModel = new LaunchPadAdminModel(HttpContext);
            // Creating the link object to set the values
            Links link = new Links();
            // setting the values
            link.id = editLinkID;
            link.linkName = editLinkName;
            link.linkURL = editlinkURL;
            link.categoryID = categoryID2;
            link.favourite = editFavourite;
            // if it is satisfied make the changes and save them
            if(ModelState.IsValid){
                launchPadAdminModel.Update(link);
                launchPadAdminModel.SaveChanges();
            }
            // return the view
            return RedirectToAction("Index", launchPadAdminModel);
        }
        public IActionResult DeleteLink(int deleteLinkID, string deleteLinkName, string deleteLinkURL) {
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            // construction of the model
            launchPadAdminModel = new LaunchPadAdminModel(HttpContext);
            // Creating the link object to set the values
            Links link = new Links();
            // setting the values
            link.id = deleteLinkID;
            link.linkName = deleteLinkName;
            link.linkURL = deleteLinkURL;
            // returning the view
            return View("DeleteLink", link);
        }
        public IActionResult DeleteLinkSubmit(int linkID){
            // if not logged in send user back to home page
            if (HttpContext.Session.GetString("auth") != "true"){
                return RedirectToAction("Index", "Home");
            }
            // construction of the model
            launchPadAdminModel = new LaunchPadAdminModel(HttpContext);
            // creating the link object so we can delete the link from the database
            Links linkToDelete = new Links();
            // getting the link to delete
            linkToDelete.id = linkID;
            // If it is satisfied delete the link and save the changes
            if(ModelState.IsValid){
                launchPadAdminModel.Remove(linkToDelete);
                launchPadAdminModel.SaveChanges();
            }
            // return the view
            return RedirectToAction("Index", launchPadAdminModel);
        }
        [HttpPost]
        public IActionResult Logout() {
            // construction of the model
            LaunchPadAdminModel admin = new LaunchPadAdminModel(HttpContext);
            // log the user out
            admin.Logout();
            // return the view
            return RedirectToAction("Index", "Home");
        }

    }
}
