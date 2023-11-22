using Microsoft.EntityFrameworkCore;
using PegaderoDeLaMula.Models;
using System.Collections.Generic;

namespace PegaderoDeLaMula.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Cliente> CLIENTE { get; set; }
        public DbSet<TipoProducto> TIPO_PRODUC { get; set; }
        public DbSet<Detalles> DDA { get; set; }
        public DbSet<Inventario> INVENTARIO { get; set; }
        public DbSet<User> USER { get; set; }
        public DbSet<Recomendaciones> RECOMENDACIONES { get; set; }
    }
}
