using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace resturant_pro.Models
{

    [MetadataType(typeof(MealMetaData))]
    public partial class Meal
    {




    }

    public class MealMetaData
        {
        
        [Display(Name="Meal Id")]
        public int MealId { get; set; }

        [Required]
        [Display(Name = "Meal Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name="Price=>LE")]
        public Nullable<double> Price { get; set; }

        [Required]
        public string Description { get; set; }

        
        public string Image { get; set; }

    }
}