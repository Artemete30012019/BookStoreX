using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStoreX.Models
{
    public class Book
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Укажите название книги")]
        [Display(Name = "Название книги")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Укажите автора")]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Укажите стоимость книги")]
        [Display(Name = "Цена")]
        public int Price { get; set; }

    }
}
