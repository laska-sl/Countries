using System.ComponentModel.DataAnnotations;

namespace Countries.Data.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
