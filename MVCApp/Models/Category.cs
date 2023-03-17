using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace MVCApp.Models
{
    public class Category
    {
        [Key]
        public int id { get; set; }
        [Required]
        [DisplayName("Name")]
        public string name { get; set; }
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100 !! ")]
        public int displayorder { get; set; }
        public DateTime createdDateTime { get; set; } = DateTime.Now;
    }
}
