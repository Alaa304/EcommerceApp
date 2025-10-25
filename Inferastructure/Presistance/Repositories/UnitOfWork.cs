using DomainLayer.Contracts;
using DomainLayer.Models;
using Presistance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistance.Repositories
{
    public class UnitOfWork(StoreDbContext _context) : IUnitOfWork
    {private readonly Dictionary<string , object> _repositories = new();//بدل ما انشاء لكل ريبوزيتوري كلاس جديد بستخدم داكشنري الما احتاج ريبوزيتوري معين باجي اخدها من هنا او اذا ماكانش موجود بعمله انشاء جديد و بخزنه هنا
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var type = typeof(TEntity).Name;//as product// key
            if(_repositories.TryGetValue(type, out object?value))
            {
                return (IGenericRepository<TEntity, TKey>)value;
            }
            else
            {
               var repository = new GenericRepository<TEntity, TKey>(_context);
                _repositories.Add(type, repository);
                return repository;
            }


        }

        public async Task<int> SaveChangesAsync()
        =>await _context.SaveChangesAsync();
    }
}
