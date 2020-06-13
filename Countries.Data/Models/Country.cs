using System.ComponentModel.DataAnnotations;

namespace Countries.Data.Models
{
    public class Country
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string Code { get; set; }

        [Required]
        public int CapitalId { get; set; }

        public City Capital { get; set; }

        public double Area { get; set; }

        public int Population { get; set; }

        [Required]
        public int RegionId { get; set; }

        public Region Region { get; set; }
    }
}
