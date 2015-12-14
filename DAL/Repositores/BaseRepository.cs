using DAL.Inerfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositores
{
    public abstract class BaseRepository<T> where T : new()
    {
        internal IContext _context;
        private DbSet _objectContext;
        public DbSet objectContext
        {
            get
            {
                if (_objectContext == null)
                {
                    var modelType = typeof(T);
                    MethodInfo getEntityMethod = modelType.GetMethod("GetEntity", BindingFlags.Instance | BindingFlags.NonPublic);
                    var entityType = getEntityMethod.ReturnType;
                    _objectContext = ((Context.Context)_context).Set(entityType);
                    return _objectContext;
                }

                return _objectContext;
            }
        }

        public ObjectOperationResult<T> Add(T item)
        {
            try
            {
                Type modelType = typeof(T);
                MethodInfo getEntityMethod = modelType.GetMethod("GetEntity", BindingFlags.Instance | BindingFlags.NonPublic);

                var entityToAdd = getEntityMethod.Invoke(item, null);
                var addedEntity = objectContext.Add(entityToAdd);
                _context.SaveChanges();

                object[] args = new object[] { addedEntity };
                var returnModel = (T)Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.NonPublic, null, args, null);

                return new ObjectOperationResult<T>("Dodano pomyślnie", returnModel);
            }
            catch (Exception ex)
            {
                return new ObjectOperationResult<T>(false, true, ex.Message);
            }
        }
    }
}
