using HotalRoyal_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotalRoyal_WebAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Hotel> Hotels{ get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Hotel>().HasData
            (
                new Hotel 
                { 
                    Id = 1, 
                    Name = "Beach View", 
                    Details = "Test Data",
                    ImageUrl = "",
                    Occupancy = 5,
                    Rate = 50,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Hotel
                {
                    Id = 2,
                    Name = "Sea View",
                    Details = "Test Data",
                    ImageUrl = "",
                    Occupancy = 2,
                    Rate = 30,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                },
                new Hotel
                {
                    Id = 3,
                    Name = "City View",
                    Details = "Test Data",
                    ImageUrl = "",
                    Occupancy = 6,
                    Rate = 20,
                    Sqft = 500,
                    Amenity = "",
                    CreatedDate = DateTime.Now
                }
            );
        }
    }
}
