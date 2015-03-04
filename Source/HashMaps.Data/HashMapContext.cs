using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMaps.Data
{
    public class HashMapContext : DbContext
    {
        public DbSet<User> Users { get; set; }        

        static HashMapContext()
        {
            Database.SetInitializer<HashMapContext>(new DropCreateDatabaseIfModelChanges<HashMapContext>());
        }
    }
        
}
