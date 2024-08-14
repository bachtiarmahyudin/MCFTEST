using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcfBackEnd.Models
{
    [Table("tr_bpkb", Schema = "dbo")]
    public class BPKB
    {
        [Key]
        [Column("agreement_number")]
        public string AgreementNumber { get; set; }

        [Column("bpkb_no")]
        public string BPKBNo { get; set; }

        [Column("branch_id")]
        public string BranchId { get; set; }

        [Column("bpkb_date")]
        public DateTime BPKBDate { get; set; }

        [Column("faktur_no")]
        public string FakturNo { get; set; }

        [Column("faktur_date")]
        public DateTime FakturDate { get; set; }

        [Column("location_id")]
        public string LocationId { get; set; }

        [Column("police_no")]
        public string PoliceNo { get; set; }

        [Column("bpkb_date_in")]
        public DateTime BPKBDateIn { get; set; }

        [Column("created_by")]
        public string CreatedBy { get; set; }

        [Column("created_on")]
        public DateTime CreatedDate { get; set; }

        [Column("last_updated_by")]
        public string UpdateBy { get; set; }

        [Column("last_updated_on")]
        public DateTime UpdateDate { get; set; }
    }
}
