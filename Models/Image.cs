namespace RzeczyDoOddania.Models
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] Data { get; set; }
        public int ItemId { get; set; }
        public Item Item { get; set; }
    }
}
