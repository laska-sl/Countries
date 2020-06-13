using System.ComponentModel.DataAnnotations;

namespace Countries.Data.Models
{
    public class Region
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
