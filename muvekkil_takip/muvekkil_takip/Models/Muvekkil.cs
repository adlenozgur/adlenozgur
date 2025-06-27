using System.ComponentModel.DataAnnotations;

namespace muvekkil_dava.Models
{
    public class Muvekkil
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad soyad zorunludur.")]
        [Display(Name = "Ad Soyad")]
        public string AdSoyad { get; set; }

        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi giriniz.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Geçerli bir telefon numarası giriniz.")]
        public string Telefon { get; set; }

        [Display(Name = "Adres")]
        public string Adres { get; set; }
    }
}
