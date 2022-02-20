using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace chefs_dishes.Models
{
    public class Dish
    {
        [Key] // the below prop is the primary key, [Key] is not needed if named with pattern: ModelNameId
        public int DishId { get; set; }


        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Dish Name")]
        public string DishName { get; set; }
        

        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Chef Name")]
        public string ChefName { get; set; }


        [Required (ErrorMessage= "is required")]
        [Range(0, int.MaxValue, ErrorMessage ="must be greater than 0")]
        [Display(Name = "Calories")]
        public int Calories { get; set; }


        [Required(ErrorMessage = "is required")]
        [Range(1, 5, ErrorMessage ="must be between 1 and 5")]
        [Display(Name = "Tastiness")]
        public int Tastiness { get; set; }


        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Description")]
        public string Description { get; set; }


        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


        public int ChefId { get; set; }

        [NotMapped]
        public List<Chef> Chefs { get; set;}

        public Chef Creator{get; set;}
    }
}
