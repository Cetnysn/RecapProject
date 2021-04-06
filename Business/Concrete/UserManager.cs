using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UserManager : IUserService     
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(Users users)
        {
            _userDal.Add(users);
            return new SuccessResult("Kullanıcı eklendi"); 
            
        }

        public IResult Delete(Users users)
        {
            _userDal.Delete(users);
            return new SuccessResult("Kullanıcı verileri sistemden silindi");
        }

        public IDataResult<List<Users>> GetAllUsers()
        {
            return new SuccessDataResult<List<Users>>(_userDal.GetAll(),("Kullanıcılar Listelendi"));
        }

        public IDataResult<Users> GetByUserId(int userId)
        {
            return new SuccessDataResult<Users>(_userDal.Get(u => u.UserId == userId));
        }

        public IResult Update(Users users)
        {
            _userDal.Update(users);
            return new SuccessResult("Kullanıcı verileri güncellendi");
        }
    }
}
