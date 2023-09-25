using EmployeeCrud.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeCrud.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base(options) 
        { 
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
