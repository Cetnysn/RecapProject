using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
       
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.Description.Length <= 1 && car.DailyPrice < 0  )
            {
                Console.WriteLine("Hata!. Araba ismi mininum 2 karakter olmalıdır.");
            }
            else if (car.Description.Length >= 2 && car.DailyPrice < 0)
            {
                Console.WriteLine("Hata!. Araba günlük fiyatı 0' dan büyük olmalıdır.");
            }
            else
            {
                _carDal.Add(car);
                Console.WriteLine("Araba sisteme eklendi.");
            }

        }

        public void Delete(Car car)
        {
            _carDal.Delete(car);
            Console.WriteLine("Araç sistemden silinmiştir.");  
        }

        public List<Car> GetAll()
        {
            return _carDal.GetAll();    
        }

        public List<Car> GetCarsByBrandId(int id)
        {
            return _carDal.GetAll(c => c.BrandId == id);
        }

        public List<Car> GetCarsByColorId(int id)
        {
            return _carDal.GetAll(c => c.ColorId == id);
        }

        public void Update(Car car)
        {
            _carDal.Update(car);
            Console.WriteLine("Araç bilgileri güncellenmiştir.");
        }
    }
}
