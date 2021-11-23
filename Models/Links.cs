using System;
using System.ComponentModel.DataAnnotations;

namespace launchPad.Models {
    // class for the links
    public class Links {
        // ------------------------------------- get/set methods
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name="Name")]
        public string linkName { get; set; }
        [RegularExpression(@"^https?://(www.)?[-a-zA-Z0-9@:%.+~#=]{1,256}.[a-zA-Z0-9()]{1,6}\b([-a-zA-Z0-9()@:%+.~#?&//=]*)$", ErrorMessage = "Invalid URL")]
        [Display(Name="URL")]
        [Required]
        public string linkURL { get; set; }
        [Required]
        public string favourite { get; set; }
        [Required]
        public int categoryID { get; set; }
    }
}