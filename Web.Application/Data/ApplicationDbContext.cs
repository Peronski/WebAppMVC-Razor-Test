using Microsoft.EntityFrameworkCore;
using Test_Cinema.Models;

namespace Web.Application.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        DbSet<Film> Films { get; set; }
    }
}
