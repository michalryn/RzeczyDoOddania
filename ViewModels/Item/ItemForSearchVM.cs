using RzeczyDoOddania.Models;
using System.ComponentModel.DataAnnotations;

namespace RzeczyDoOddania.ViewModels.Item
{
    public class ItemForSearchVM
    {
        public int Id { get; set; }
        [Display(Name = "Nazwa Przedmiotu")]
        public string Name { get; set; }

        [Display(Name = "Adres")]
        public string Address { get; set; }

        [Display(Name = "Kategorie")]
        public IList<Category>? Categories { get; set; }

        [Display(Name = "Wygaśnięcie ogłoszenia")]
        [DisplayFormat(DataFormatString = "{0:D}")]
        public DateTime? Date { get; set; }

        [Display(Name = "Zdjęcie")]
        public string Image { get; set; }

        public string? ReservedFor { get; set; }
        public int? InterestUsersCount { get; set; }
    }
}
