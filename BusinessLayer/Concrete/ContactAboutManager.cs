using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
	public class ContactAboutManager : IContactAboutService
	{
		private readonly IContactAboutDal _contactAboutDal;

		public ContactAboutManager(IContactAboutDal contactAboutDal)
		{
			_contactAboutDal = contactAboutDal;
		}

		public void TDelete(ContactAbout t)
		{
			_contactAboutDal.Delete(t);
		}

		public ContactAbout TGetById(int id)
		{
			return _contactAboutDal.GetById(id);
		}

		public List<ContactAbout> TGetList()
		{
			return _contactAboutDal.GetList();
		}

		public void TInsert(ContactAbout t)
		{
			_contactAboutDal.Insert(t);
		}

		public void TUpdate(ContactAbout t)
		{
			_contactAboutDal.Update(t);
		}
	}
}
