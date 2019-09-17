using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tzest
{
    /// <summary>
    /// Связь между классом и бд
    /// </summary>
   public class ApplicationContext : DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
         // Database.SetInitializer<EkosContext>(null);
        }
        public DbSet<Catalog> Catalogs { get; set; }
    }


}
