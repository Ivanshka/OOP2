using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba_13
{
    public class UnitOfWork : IDisposable
    {
        // единый контекст базы данных. он передается в контруктор репозиториев, обеспечивая наличие одной и той же ссылки на контекст
        private DatabaseContext db = new DatabaseContext();
        // репозитории с инфой и свойства для них
        private OwnerRepository ownerRepository;
        private CarRepository carRepository;

        public OwnerRepository Owners
        {
            get
            {
                if (ownerRepository == null)
                    ownerRepository = new OwnerRepository(db);
                return ownerRepository;
            }
        }

        public CarRepository Cars
        {
            get
            {
                if (carRepository == null)
                    carRepository = new CarRepository(db);
                return carRepository;
            }
        }

        /// <summary>
        /// Сохраняет изменения в БД
        /// </summary>
        public void Save()
        {
            using (var transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.SaveChanges();
                    transaction.Commit();
                }
                catch {
                    MessageBox.Show("Упс! Что-то пошло не по плану и сохранить не удалось. Отменяем транзакцию!");
                    transaction.Rollback();
                }
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
