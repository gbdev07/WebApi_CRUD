namespace WebApi_Test.Models
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Value { get; set; }
        public int? OrderId { get; set; }
        public virtual OrderModel? Order { get; set; }
    }
}
