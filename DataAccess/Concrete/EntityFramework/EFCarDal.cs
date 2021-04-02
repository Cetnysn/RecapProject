using Core.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, NorthwindContext>, ICarDal
    {
        public List<CarDetailsDto> GetCarDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var result = from m in context.Cars
                             join b in context.Brands
                             on m.BrandId equals b.BrandId
                             join c in context.Colors
                             on m.ColorId equals c.ColorId
                             select new CarDetailsDto
                             {
                                 CarId = m.CarId,
                                 CarName = m.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName

                             };
                return result.ToList();
            }
        }
    }
}
