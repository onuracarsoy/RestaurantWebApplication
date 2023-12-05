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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _abouDal;

        public AboutManager(IAboutDal abouDal)
        {
            _abouDal = abouDal;
        }

        public void TDelete(About t)
        {
            _abouDal.Delete(t);
        }

        public About TGetById(int id)
        {
            return _abouDal.GetById(id);
        }

        public List<About> TGetList()
        {
            return _abouDal.GetList();
        }

        public void TInsert(About t)
        {
            _abouDal.Insert(t);
        }

        public void TUpdate(About t)
        {
            _abouDal.Update(t);
        }
    }
}
