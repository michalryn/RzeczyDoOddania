using System.ComponentModel.DataAnnotations;
using RzeczyDoOddania.Models;

namespace RzeczyDoOddania.ViewModels.Item
{
    public class ItemPageVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        [Display(Name = "Data wygaśnięcia")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? Date { get; set; }
        public ApplicationUser Owner { get; set; }
        public IList<Category>? Categories { get; set; }
        public IList<string> Images { get; set; }
        public bool? Completed { get; set; }
        public string? ReservedFor { get; set; }
        public IList<ApplicationUser>? InterestedUsers { get; set; }
        public int? InterestUsersCount { get; set; }
    }
}
