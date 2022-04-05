using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Context
{
    public class DBContext : DbContext
    {
        /// <summary>
        /// DBContext Constructor
        /// </summary>
        /// <param name="options"></param>
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }

        /// <summary>
        /// The data models
        /// </summary>
        public DbSet<Movie> Movies { get; set; }
    }
}
