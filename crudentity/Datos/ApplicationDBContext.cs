using crudentity.Models;
using Microsoft.EntityFrameworkCore;

namespace crudentity.Datos
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        // Agregar el modelo usuario y todos lo modelos aqui, de la siguiente forma
        public DbSet<Usuario> Usuario{get; set;}


    }
}
