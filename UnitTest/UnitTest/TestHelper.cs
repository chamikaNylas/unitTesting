using Core.Context;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace UnitTest
{
    public class TestHelper
    {
        /// <summary>
        /// The DB Instance
        /// </summary>
        private readonly DBContext dbContext;


        /// <summary>
        /// TestHelper Constructor
        /// </summary>
        public TestHelper()
        {
            // Create In Memory DB
            var builder = new DbContextOptionsBuilder<DBContext>();
            builder.UseInMemoryDatabase(databaseName:"MovieDB");

            var dbContextOptions = builder.Options;
            dbContext = new DBContext(dbContextOptions);

            // Delete existing db before creating a new one
            if (dbContext != null)
            {
                dbContext.Database.EnsureDeleted();
                dbContext.Database.EnsureCreated();
                
            }

            // Add default data
             AddDefaultData();

        }

        public DBContext GetDBContext()
        { 
            return dbContext;
        }


        private  void AddDefaultData()
        {
            // Prepare default test data
             var movies = new List<Movie>
            {
                new Movie { Id = 0, Title = "Test Movie 1", Genre = "Test Genre", PostedBy = "saman", ReleaseDate = DateTime.Now.AddDays(2) },
                new Movie { Id = 0, Title = "Test Movie 2", Genre = "Test Genre", PostedBy = "kamal", ReleaseDate = DateTime.Now.AddDays(2) }
            };

            // Add new entity record to the DB
            dbContext.AddRange(movies);
            dbContext.SaveChanges();          
        }
    }
}
