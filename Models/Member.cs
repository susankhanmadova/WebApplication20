using WebApplication20.Models.Base;

namespace WebApplication20.Models
{
    public class Member: BaseEntity
    {
        public string Name { get; set; }
        public Profession Profession { get; set; }
        public string ImageUrl { get; set; }
    }
}
