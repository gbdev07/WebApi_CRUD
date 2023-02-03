using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi_Test.Models;

namespace WebApi_Test.Data.Maps
{
    public class OrderMap : IEntityTypeConfiguration<OrderModel>
    {
        public void Configure(EntityTypeBuilder<OrderModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrderNumber).IsRequired().HasMaxLength(255);
            builder.Property(x => x.CreatedOn).IsRequired();
            builder.Property(x => x.ClientId);
            builder.Property(x => x.ItemId).IsRequired();

            builder.HasOne(x => x.Client);
        }
    }
}
