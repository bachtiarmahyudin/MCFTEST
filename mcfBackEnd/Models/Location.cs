using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mcfBackEnd.Models
{
    [Table("ms_storage_location", Schema = "dbo")]
    public class Location
    {
        [Key]
        [Column("location_id")]
        public string LocationId { get; set; }

        [Column("location_name")]
        public string LocationName { get; set; }
    }
}
