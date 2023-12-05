using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
	public  class EfContactDal : GenericRepository<Contact>, IContactDal
	{
		public EfContactDal(Context context) : base(context)
		{
		}

        public int ContactCount()
        {
            using (var context = new Context())
            {
                int contactCount = context.Contacts.Count();
                return contactCount;
            }
        }
    }
}
