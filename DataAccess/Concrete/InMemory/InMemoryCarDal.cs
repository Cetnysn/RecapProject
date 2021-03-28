using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
             new Car{CarId= 1, BrandId= 1, ColorId=1, DailyPrice= 370, ModelYear= 2017, Description = "Uzun yol aracı"},
             new Car{CarId= 1, BrandId= 1, ColorId=1, DailyPrice= 200, ModelYear= 2017, Description = "Az yakar"},
             new Car{CarId= 1, BrandId= 1, ColorId=1, DailyPrice= 700, ModelYear= 2017, Description = "1 depo benzin hediye"},
             new Car{CarId= 1, BrandId= 1, ColorId=1, DailyPrice= 549, ModelYear= 2017, Description = "Bagaj kapasitesi büyük"},
             new Car{CarId= 1, BrandId= 1, ColorId=1, DailyPrice= 999, ModelYear= 2017, Description = "Premium Aile aracı"}
            };
        }

        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(Car car)
        {
            Car carToDelete = _cars.SingleOrDefault(c => c.BrandId == car.BrandId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetById(int carId)
        {
            return _cars.Where(c => c.CarId == carId).ToList();
        }

        public void Update(Car car)
        {
            Car carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.Description = car.Description;
        }
    }
}
