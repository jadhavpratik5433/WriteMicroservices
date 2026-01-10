using System.ComponentModel.DataAnnotations;

namespace WebApiProject.Entities
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
    }
}
