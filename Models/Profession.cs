using System.ComponentModel.DataAnnotations;
using WebApplication20.Models.Base;

namespace WebApplication20.Models
{
    public class Profession: BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        [
          StringLength(10, ErrorMessage = "Name cannot be longer than 10 characters"),
          MinLength(1, ErrorMessage = "Name must be at least 1 characters long")
        ]
        public string Name { get; set; }
        public List<Member> Members { get; set; }
    }
}
