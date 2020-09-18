using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace antelo.Models
{
    public enum placeType
    {
        plaza,
        casa,
        gimanasio,
        bar,
        comedor
    }
    public class Antelo
    {
        [Key]
        public int anteloID { get; set; }
        [Required]
        [Display(Name ="Nombre completo")]
        [StringLength(24,MinimumLength =2)]
        public string Friendofantelo { get; set; }
        [Required]
        public placeType Place { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Muestre cumpleaños")]
        [DisplayFormat(DataFormatString = "{0:dd,MM,yyyy}")]
        [DataType(DataType.Date)]//necesario
        public DateTime Birthdate { get; set; }

    }
}