namespace RzeczyDoOddania.Models
{
    public class SiteUser
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
