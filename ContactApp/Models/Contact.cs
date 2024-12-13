using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace ContactApp.Models
{
    public class Contact
    {
        public int ContactId { get; set; }

        [Required(ErrorMessage = "Lütfen bir ad giriniz.")]
        public string FirstName { get; set; } = null!;

        [Required(ErrorMessage = "Lütfen bir soyad giriniz.")]
        public string LastName { get; set; } = null!;

        [Required(ErrorMessage = "Lütfen bir telefon numarası giriniz.")]
        public string PhoneNumber { get; set; } = null!;

        [Required(ErrorMessage = "Lütfen bir e-posta adresi giriniz.")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Lütfen bir kategori seçiniz.")]
        public int? CategoryId { get; set; }

        [ValidateNever]
        public Category Category { get; set; } = null!;

        public DateTime DateAdded { get; set; }

        //Read only property that returns the full name of the contact
        public string Slug => FirstName?.Replace(' ', '-').ToLower() + '-' + LastName?.Replace(' ', '-').ToLower();
    }
}
