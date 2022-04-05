using Core.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


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

  
        }

        public DBContext GetDBContext()
        { 
            return dbContext;
        }
    }
}
