using System.ComponentModel.DataAnnotations;

namespace RzeczyDoOddania.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Display(Name = "Nazwa Przedmiotu")]
        [Required(ErrorMessage = "Podaj nazwę przedmiotu"), 
            StringLength(100, ErrorMessage = "{0} może mieć maksymalnie {1} znaków")]
        public string Name { get; set; }

        [Display(Name = "Opis")]
        [Required(ErrorMessage = "Uzupełnij opis")]
        public string Description { get; set; }

        [Display(Name = "Adres")]
        [Required(ErrorMessage = "Podaj adres")]
        public string Address { get; set; }

        [Display(Name = "Wygaśnięcie ogłoszenia")]
        public DateTime? Date { get; set; }

        [Display(Name = "Kategoria")]
        public Category? Category { get; set; }
        
        public byte[]? Image { get; set; }

        public string? UserName { get; set; }
        
        public virtual ICollection<SiteUser>? InterestedUsers { get; set; }
    }
}
