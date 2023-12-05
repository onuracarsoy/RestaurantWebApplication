using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfProductDal : GenericRepository<Product>, IProductDal
    {
        public EfProductDal(Context context) : base(context)
        {
        }

        public List<Product> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Products.Include(x => x.Category).ToList();
            }
        }
        public List<Product> ProductListWithCategory(int id)
        {
            using (var c = new Context())
            {
                return c.Products.Include(x => x.Category).Where(y =>y.CategoryID == id).ToList();
            }
        }

        public int ProductCount()
        {
            using (var context = new Context())
            {
                int ProductCount = context.Products.Count();
                return ProductCount;
            }
        }
    }
}
