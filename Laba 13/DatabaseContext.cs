using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace Laba_13
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DbConnection") { } // конструктор с определенным соединением
        // Локальные таблицы с инфой
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}