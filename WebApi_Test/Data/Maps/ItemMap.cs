using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebApi_Test.Models;

namespace WebApi_Test.Data.Maps
{
    public class ItemMap : IEntityTypeConfiguration<ItemModel>
    {
        public void Configure(EntityTypeBuilder<ItemModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Value).IsRequired();
            builder.Property(x => x.OrderId);

            builder.HasOne(x => x.Order);
        }
    }
}
