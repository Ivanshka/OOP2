using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba_13
{
    public class CarRepository : IRepository<Car>
    {
        private DatabaseContext db;

        public CarRepository(DatabaseContext context) => db = context;

        public void Create(Car item) => db.Cars.Add(item);

        public void Delete(int id)
        {
            Car o = db.Cars.Find(id);
            if (o != null)
                db.Cars.Remove(o);
        }

        public Car GetObject(int id) => db.Cars.Find(id);

        public IEnumerable<Car> GetAllObjects() => db.Cars;

        public void Save() => db.SaveChanges();

        public void Update(Car item) => db.Entry(item).State = EntityState.Modified;

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Обновляет содержимое индивидуального контекста репозитория
        /// </summary>
        public void Refresh()
        {
            try { db.Cars.Load(); } catch { MessageBox.Show("Can't update the repository!", "Critical error"); }
        }
    }
}
