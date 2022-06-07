using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication9.Models;

namespace WebApplication9.Context
{
    public class AppDbContext :DbContext
    {
        IConfiguration _config;
        public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration config) : base (options)
        {
            _config = config;
        }

        public DbSet<Student> Students { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer(_config.GetConnectionString("MyCon"));
            builder.UseSqlServer("Server=LAPTOP-53S2KQS8;Database=TestDb;Trusted_Connection=True;");
        }
    }
}
