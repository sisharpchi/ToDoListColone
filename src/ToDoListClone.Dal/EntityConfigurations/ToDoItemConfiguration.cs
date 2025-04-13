using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ToDoListClone.Dal.Entities;

namespace ToDoListClone.Dal.EntityConfigurations;

public class ToDoItemConfiguration : IEntityTypeConfiguration<ToDoItem>
{
    public void Configure(EntityTypeBuilder<ToDoItem> builder)
    {
        builder.HasKey(b => b.Id);

        builder.ToTable("ToDoLists");

        builder.Property(b => b.Title)
        .IsRequired(true)
        .HasMaxLength(50);

        builder.Property(b => b.Description)
        .IsRequired(true)
        .HasMaxLength(150);

        builder.Property(b => b.CreatedAt)
        .IsRequired(true)
        .HasMaxLength(50);

        builder.Property(b => b.DueDate)
        .IsRequired(true)
        .HasMaxLength(50);

        builder.Property(b => b.IsComplited)
        .IsRequired(true)
        .HasMaxLength(10);
    }
}
