using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_BusinessLogic
{
    public class Citizen
    {
        public long Id { get; set; }
        public string? NIK { get; set; }
        public string? Nama { get; set; }
        public string? Alamat { get; set; }
        public int StatusPerkawinan { get; set; }
    }
}
