using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BusinessLogic
{
    public class Citizen
    {
        [Key]
        public long Id { get; set; }
        [Required]
        [StringLength(16)]
        public string NIK { get; set; } = null!;
        [Required]
        [StringLength(50)]
        public string Nama { get; set; } = null!;
        [StringLength(1250)]
        public string? Alamat { get; set; }
        public int StatusPerkawinan { get; set; }
    }
}
