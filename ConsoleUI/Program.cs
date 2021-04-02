using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarTest();
            ColorTest();
            BrandTest();

            Console.ReadLine();
        }

        private static void BrandTest()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            Brand brand = new Brand
            {
                BrandId = 2,
            };
            brandManager.Add(brand);
            foreach (var brands in brandManager.GetAllBrands())
            {
                Console.WriteLine(brands.BrandName);
            }
        }

        private static void ColorTest()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            Color color = new Color
            {
                ColorName = "Java Green"
            };
            colorManager.Add(color);
            foreach (var colors in colorManager.GetAllColors())
            {
                Console.WriteLine(colors.ColorName);
            }
            colorManager.Update(color);
            Console.WriteLine("Renk güncellendi");
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            Car car1 = new Car
            {
                CarId = 2
            };

            carManager.Add(new Car { BrandId = 1, CarId = 1, CarName = "Mercedes", ColorId = 1, DailyPrice = 329, ModelYear = 2013, Description = "Premium aile aracı" });
            foreach (var cars in carManager.GetCarDetails())
            {
                Console.WriteLine("{0} / {1} / {2} / {3}", cars.CarName, cars.BrandName, cars.ColorName, cars.DailyPrice);
            };

            foreach (var cars in carManager.GetAllCars())
            {
                Console.WriteLine(cars.CarName);
            }
            foreach (var cars in carManager.GetCarsByBrandId(1))
            {
                Console.WriteLine(cars.DailyPrice);
            }
            foreach (var cars in carManager.GetCarsByColorId(5))
            {
                Console.WriteLine(cars.ModelYear);
            }

            carManager.Delete(car1);
        }
    }
}
