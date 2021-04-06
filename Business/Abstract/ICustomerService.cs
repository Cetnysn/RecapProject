using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        IDataResult<List<Customers>> GetAllCustomers();
        IDataResult<Customers> GetByCustomerId(int Id);


        IResult Add(Customers customers);
        IResult Delete(Customers customers);
        IResult Update(Customers customers);

    }
}
