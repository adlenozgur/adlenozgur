using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace muvekkil_dava.Models
{
    public class Dava
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Müvekkil seçilmelidir.")]
        [Display(Name = "Müvekkil")]
        public int MuvekkilId { get; set; }

        [ForeignKey("MuvekkilId")]
        public Muvekkil Muvekkil { get; set; }

        [Required(ErrorMessage = "Dava tarihi zorunludur.")]
        [DataType(DataType.Date)]
        [Display(Name = "Dava Tarihi")]
        public DateTime Tarih { get; set; }

        [StringLength(200)]
        [Display(Name = "Konu")]
        public string Konu { get; set; }

        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
    }
}
