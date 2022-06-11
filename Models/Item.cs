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

        [Display(Name = "Kategorie")]
        public virtual ICollection<Category>? Categories { get; set; }
        
        [Display(Name = "Zdjęcia")]
        public virtual ICollection<Image>? Images { get; set; }

        [Display(Name = "Właściciel")]
        public ApplicationUser? Owner { get; set; }

        public bool? Completed { get; set; }

        public string? ReservedFor { get; set; }
        
        public virtual ICollection<ApplicationUser>? InterestedUsers { get; set; }
    }
}
