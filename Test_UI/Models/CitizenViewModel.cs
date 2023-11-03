using System.ComponentModel.DataAnnotations;

namespace Test_UI.Models
{
    public class CitizenViewModel
    {
        public long Id { get; set; }
        [Required]
        [RegularExpression("^[0-9]{16}$", ErrorMessage = "Numbers only!")]
        [MinLength(16)]
        public string NIK { get; set; } = null!;
        [Required]
        [RegularExpression("^(?i)([a-z]+(\\s[a-z]+){0,49})$", ErrorMessage = "No special characters!")]
        [StringLength(50)]
        public string Nama { get; set; } = null!;
        [RegularExpression("^[0-9a-zA-Z\\s.,#-]+$", ErrorMessage = "No special characters!")]
        [StringLength(1250)]
        public string? Alamat { get; set; }
        [Range(0, 2)]
        public int StatusPerkawinan { get; set; }

        public string? StatusPerkawinanText { get; set; }
    }

    public enum StatusPerkawinanEnum
    {
        Lajang = 0,
        Menikah = 1,
        Bercerai  = 2
    }
}
