using System.ComponentModel.DataAnnotations.Schema;

namespace mcfFrontEnd.Models
{
    public class BPKB
    {
        public string? AgreementNumber { get; set; }

        public string? BPKBNo { get; set; }

        public string? BranchId { get; set; }

        public DateTime? BPKBDate { get; set; }

        public string? FakturNo { get; set; }

        public DateTime? FakturDate { get; set; }

        public string? LocationId { get; set; }

        public string? PoliceNo { get; set; }

        public DateTime? BPKBDateIn { get; set; }
        public string? CreateBy { get; set; }

    }
}
