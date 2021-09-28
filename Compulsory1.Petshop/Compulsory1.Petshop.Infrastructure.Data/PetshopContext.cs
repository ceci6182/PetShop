using Compulsory1.Petshop.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Compulsory1.Petshop.Infrastructure.Data
{
    public class PetshopContext: DbContext
    {
        public PetshopContext(DbContextOptions<PetshopContext> opt) : base(opt)
        {
            
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
    }
}