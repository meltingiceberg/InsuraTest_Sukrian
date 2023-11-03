using System.ComponentModel.DataAnnotations;

namespace Test_API.Request
{
    public class CitizenRequest
    {
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
        [Range(0, 3)]
        public int StatusPerkawinan { get; set; }
    }

    public class UpdateCitizenRequest : CitizenRequest
    {
        [Required]
        public long Id { get; set; }
    }
}
