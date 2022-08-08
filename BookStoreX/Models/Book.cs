using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStoreX.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }
       
        //[Required]
        [Display(Name = "Название книги")]
        public string Name { get; set; }
        
        //[Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        //[Required]
        [Display(Name = "Цена")]
        public int Price { get; set; }

    }
}
