using WebApplication20.Models.Base;

namespace WebApplication20.Models
{
    public class Profession: BaseEntity
    {
        public string Name { get; set; }
        public List<Member> Members { get; set; }
    }
}
