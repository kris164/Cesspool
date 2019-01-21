using Microsoft.EntityFrameworkCore;
using Cesspool.Models;

namespace Cesspool
{
    public class DatosContext : DbContext
    {

        public DatosContext(DbContextOptions<DatosContext> options)
            : base(options)
        { }

        public virtual DbSet<pesso> pesso { get; set; }
    }
}