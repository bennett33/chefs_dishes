using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace chefs_dishes.Models
{
    public class Chef
    {
        [Key] // the below prop is the primary key, [Key] is not needed if named with pattern: ModelNameId
        public int ChefId { get; set; }


        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        

        [Required(ErrorMessage = "is required")]
        [MinLength(2, ErrorMessage = "must be at least 2 characters")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }


        [Required(ErrorMessage = "is required")]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        public int Age()
            {
            string birthyear = this.Birthday.ToString("yyyy");
            string year = DateTime.Now.ToString("yyyy");

            int age = int.Parse(year) - int.Parse(birthyear);

            return age;
            }



        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public List<Dish> Dishes { get; set; }

        public int DishCount()
        {
        if (Dishes == null)
        {
            return 0;
        }
        return Dishes.Count();
        }
    }
}
