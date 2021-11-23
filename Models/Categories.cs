using System;
using System.ComponentModel.DataAnnotations;

namespace launchPad.Models {
    // category class to use in the database
    public class Categories {
        public int id {get; set;}
        [Display(Name="Category Name")]
        [Required]
        public string categoryName {get; set;}
    }

}