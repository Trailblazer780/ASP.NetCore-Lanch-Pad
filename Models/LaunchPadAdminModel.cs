using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace launchPad.Models {

    public class LaunchPadAdminModel : DbContext {
        // creating the http context object
        private HttpContext context;

        // Construction method
        public LaunchPadAdminModel(HttpContext myHttpContext){
            // setting the variable to the http context object
            context = myHttpContext;
        }
        // ------------------------------------------------------------ gets/sets
        [Required]
        [Display(Name="Name")]
        public string linkName { get; set; }
        [RegularExpression(@"^https?://(www.)?[-a-zA-Z0-9@:%.+~#=]{1,256}.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%+.~#?&//=]*)$", ErrorMessage = "Invalid URL")]
        [Display(Name="Link")]
        [Required]
        public string linkURL { get; set; }
        public string categoryName {get; set;}
        public int categoryID {get; set;}
        public int favouriteCount {get; set;} = 0;
        
        // Database tables
        private DbSet<Categories> tblCategory {get; set;}
        public DbSet<Links> tblLinks {get; set;}

        // getting the categories from the database
        public List<Categories> categories {
            get {
                return tblCategory.OrderBy(i => i.id).ToList();
            }
        }
        // getting the links from the database
        public List<Links> links {
            get {
                return tblLinks.OrderBy(i => i.linkName).ToList();
            }
        }

        // ------------------------------------------------------------ Public Methods
        public SelectList getSelectList(){
            // get the list of the data in the table
            List<Categories> listData = tblCategory.OrderBy(i => i.id).ToList();
            // return the list of the data in the table
            return new SelectList(listData, "id", "categoryName");
        }

        public int countLinks(int categoryID){
            // get the list of the data in the table
            favouriteCount = tblLinks.Where(i => i.favourite == "true" && i.categoryID == categoryID).Count();
            // return the number of favourites in the specific category
            return favouriteCount;
        }

        public void Logout() {
            // logout the user by clearing the session
            context.Session.Clear();
        }

        // ------------------------------------------------------------ Priavte Methods 
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}