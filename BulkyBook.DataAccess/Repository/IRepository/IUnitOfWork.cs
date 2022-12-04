using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {

        ICategoryRepository Category { get;}
        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }

        //The global method that we want will also be implemented here, which will
        //be the same method
        void Save();
    }
}
