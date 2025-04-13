using Microsoft.EntityFrameworkCore;
using ToDoListClone.Dal.Entities;
using ToDoListClone.Dal.EntityConfigurations;

namespace ToDoListClone.Dal;

public class MainContext : DbContext
{
    public DbSet<ToDoItem> ToDoItems { get; set; }

    public MainContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ToDoItemConfiguration());
    }

}
