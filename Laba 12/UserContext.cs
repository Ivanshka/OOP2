using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Laba_12
{
    class UserContext : DbContext
    {
        public UserContext() : base("DbConnection") { }

        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}