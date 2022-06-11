namespace RzeczyDoOddania.Models
{
    public class UserItem
    {
        public string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
