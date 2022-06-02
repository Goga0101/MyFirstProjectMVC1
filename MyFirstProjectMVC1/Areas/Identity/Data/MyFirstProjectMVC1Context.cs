using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyFirstProjectMVC1.Entities;

namespace MyFirstProjectMVC1.Data;

public class MyFirstProjectMVC1Context : IdentityDbContext<IdentityUser>
{




    public DbSet<Category> Categories { get; set; }







    public MyFirstProjectMVC1Context(DbContextOptions<MyFirstProjectMVC1Context> options)
        : base(options)
    {

    }

    

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ApplyConfiguration(new CategoryConfiguration());


        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}
