using System.Net.Http.Headers;
using WebApplication20.Models;

namespace WebApplication20.Areas.ViewModels.Members
{
    public class CreateMemberVM
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        //public Profession Profession { get; set; }
        public int ProfessionId { get; set; }

    }
}
