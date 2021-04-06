using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _customerDal;

        public CustomerManager(ICustomerDal customerDal)
        {
            _customerDal = customerDal;
        }

        public IResult Add(Customers customers)
        {
            _customerDal.Add(customers);
            return new SuccessResult("Kullanıcı eklendi");

        }

        public IResult Delete(Customers customers)
        {
            _customerDal.Delete(customers);
            return new SuccessResult("Kullanıcı verileri sistemden silindi");
        }

        public IDataResult<List<Customers>> GetAllCustomers()
        {
            return new SuccessDataResult<List<Customers>>(_customerDal.GetAll(), ("Kullanıcılar Listelendi"));
        }

        public IDataResult<Customers> GetByCustomerId(int userId)
        {
            return new SuccessDataResult<Customers>(_customerDal.Get(u => u.UserId == userId));
        }

        public IResult Update(Customers customers)
        {
            _customerDal.Update(customers);
            return new SuccessResult("Kullanıcı verileri güncellendi");
        }
    }
}
