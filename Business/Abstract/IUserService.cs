using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<Users>> GetAllUsers();
        IDataResult<Users> GetByUserId(int userId);


        IResult Add(Users users);
        IResult Delete(Users users);
        IResult Update(Users users);
    }
}
