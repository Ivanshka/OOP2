using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_14
{
    class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DbConnection") { } // конструктор с определенным соединением
        // Локальная таблица с инфой
        public DbSet<Record> Records { get; set; }
    }
}
