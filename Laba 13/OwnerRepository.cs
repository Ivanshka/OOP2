using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laba_13
{
    public class OwnerRepository : IRepository<Owner>
    {
        private DatabaseContext db;

        public OwnerRepository(DatabaseContext context) => db = context;

        /// <summary>
        /// Добавляет объект в локальную БД
        /// </summary>
        public void Create(Owner item) => db.Owners.Add(item);

        /// <summary>
        /// Удаляет объект по ID
        /// </summary>
        public void Delete(int id)
        {
            Owner o = db.Owners.Find(id);
            if (o != null)
                db.Owners.Remove(o);
        }

        /// <summary>
        /// Возвращает объект по ID, т.е. первичному ключу
        /// </summary>
        public Owner GetObject(int id) => db.Owners.Find(id);

        /// <summary>
        /// Возвращает все объекты таблицы
        /// </summary>
        public IEnumerable<Owner> GetAllObjects() => db.Owners;

        /// <summary>
        /// Сохраняет все изменения, отправляя данные на сервер
        /// </summary>
        public void Save() => db.SaveChanges();

        /// <summary>
        /// Помечает объект как требуемый для записи
        /// </summary>
        /// <param name="item"></param>
        public void Update(Owner item) => db.Entry(item).State = EntityState.Modified;

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
            try { db.Owners.Load(); } catch { MessageBox.Show("Can't update the repository!", "Critical error"); }
        }
    }
}
