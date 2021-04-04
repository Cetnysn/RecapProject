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
                var result = from e in context.Cars
                             join b in context.Brands
                             on e.BrandId equals b.BrandId
                             join c in context.Colors
                             on e.ColorId equals c.ColorId
                             select new CarDetailsDto
                             {
                                 CarId = e.CarId,
                                 CarName = e.CarName,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName

                             };
                return result.ToList();
            }
        }
    }
}
