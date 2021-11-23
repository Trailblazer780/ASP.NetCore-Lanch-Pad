using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace launchPad.Models {

    public class LaunchPadModel : DbContext {
        
        public LaunchPadModel(){

        }

        // ------------------------------------------------------------ gets/sets
        public int favouriteCount {get; set;} = 0;

        // gets and sets for the tables in the database
        private DbSet<Categories> tblCategory {get; set;}
        private DbSet<Links> tblLinks {get; set;}
        // getting the category data from the database
        public List<Categories> categories {
            get {
                return tblCategory.OrderBy(i => i.id).ToList();
            }
        }
        // getting the link data from the database
        public List<Links> links {
            get {
                return tblLinks.OrderBy(i => i.linkName).ToList();
            }
        }

        // ------------------------------------------------------------ Public Methods
        public int countLinks(int categoryID){
            // get the list of the data in the table
            favouriteCount = tblLinks.Where(i => i.favourite == "true" && i.categoryID == categoryID).Count();
            // return how many favourite there are for the specific category
            return favouriteCount;
        }

        // ------------------------------------------------------------ Priavte Methods 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            optionsBuilder.UseMySql(Connection.CONNECTION_STRING, new MySqlServerVersion(new Version(8, 0, 11)));
        }
    }
}
