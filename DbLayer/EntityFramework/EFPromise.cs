using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsLayer.EntityFramework
{
    public interface EFPromise<T>
    {
        T Save(T item);

        T Load(object ID);
        Task<T> AsyncLoad(object ID);

        void Delete(object ID);

        IQueryable<T> Query(bool trakeable = false);
    }
}
