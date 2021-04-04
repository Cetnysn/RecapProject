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
            foreach (var brands in brandManager.GetAllBrands().Data)
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
            foreach (var colors in colorManager.GetAllColors().Data)
            {
                Console.WriteLine(colors.ColorName);
            }
            colorManager.Update(color);
            Console.WriteLine("Renk güncellendi");
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success== true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    Console.WriteLine(car.CarName + "/" + car.BrandName);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            carManager.Delete(new Car { CarId = 1, BrandId = 2, CarName = "Maserati" }) ;


            foreach (var cars in carManager.GetAllCars().Data)
            {
                Console.WriteLine(cars.CarName);
            }
            foreach (var cars in carManager.GetCarsByBrandId(1).Data)
            {
                Console.WriteLine(cars.DailyPrice);
            }
            foreach (var cars in carManager.GetCarsByColorId(5).Data)
            {
                Console.WriteLine(cars.ModelYear);
            }

            
        }
    }
}
