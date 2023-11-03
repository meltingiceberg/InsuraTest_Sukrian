using System.ComponentModel.DataAnnotations;

namespace Test_API.Response
{
    public class CitizenResponse
    {
        public long Id { get; set; }
        public string NIK { get; set; } = null!;
        public string Nama { get; set; } = null!;
        public string? Alamat { get; set; }
        public int StatusPerkawinan { get; set; }
    }
}
