namespace WeatherNote.Db
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using WeatherNote.Models;

    public class WeatherDbContext : DbContext
    {
        // Your context has been configured to use a 'WeatherDbContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'WeatherNote.Db.WeatherDbContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'WeatherDbContext' 
        // connection string in the application configuration file.
        public WeatherDbContext()
            : base("WeatherDbContext")
        {
            Database.SetInitializer(new WeatherDbContextInitializer());
        }

        public DbSet<WeatherNote> Notes { get; set; }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class WeatherDbContextInitializer : CreateDatabaseIfNotExists<WeatherDbContext>
    {
        protected override void Seed(WeatherDbContext context)
        {
            context.Notes.Add(new WeatherNote { Date = DateTime.Now, Message = "mymessage"});

            base.Seed(context);
        }
    }
}