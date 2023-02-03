namespace WebApi_Test.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public DateTime CreatedOn { get; set; }
        public int? ClientId { get; set; }
        public int ItemId { get; set; }
        public virtual ClientModel? Client { get; set; }
    }
}
