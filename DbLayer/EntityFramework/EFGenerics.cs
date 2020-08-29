using Microsoft.EntityFrameworkCore;
using ModelsLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
    using System.Reflection;
using System.Threading.Tasks;

namespace ModelsLayer.EntityFramework
{
    public class EFGenericRepository<T> where T : class 
    {
        protected virtual DbContext UnitOfWork { get; set; } 
        protected virtual DbSet<T> itemDbSet { get; set; } 

        public EFGenericRepository(DbContext unitOfWork) 
        {
            UnitOfWork = unitOfWork;
            itemDbSet = unitOfWork.Set<T>();
        }

        public virtual T Save(T Item)
        {
            
            if (Load(Item) == null)
            {                
                this.itemDbSet.Add(Item);
                this.UnitOfWork.SaveChanges();
            }
            else
            {
                this.UnitOfWork.Attach(Item);
                this.UnitOfWork.Entry(Item).State = EntityState.Modified;
                this.UnitOfWork.SaveChanges();                
            }
                
            return Item;
        }

        public virtual T Load(object ID)
        {
            return itemDbSet.Find(ID);

        }

        public virtual Task<T> AsyncLoad(object ID)
        {
            return itemDbSet.FindAsync(ID).AsTask();
        }
    
        public virtual void Delete(object ID)
        {
            var itemToDelete = AsyncLoad(ID);
            
            this.UnitOfWork.Remove(itemToDelete);
            this.UnitOfWork.SaveChanges();
        }

        /// <summary>
        /// This Method return a non-trackeableQuery by default
        /// For a trackeable instance of the DbSet send the boolean in true
        /// </summary>
        /// <returns></returns>
        public virtual IQueryable<T> Query(bool trakeable = false)
        {
            return trakeable ? itemDbSet.AsTracking<T>() : itemDbSet.AsNoTracking<T>();
        }

    }
}
