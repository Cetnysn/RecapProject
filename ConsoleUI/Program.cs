using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            CarManager carManager = new CarManager(new EFCarDal());
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine(car.Description);
            //}
            

            //PersonelManager personelManager = new PersonelManager(new EFPersonelDal());
            //foreach (var personel in personelManager.GetAll())
            //{
            //    Console.WriteLine("{0} / {1} / {2} ", personel.Id, personel.Name, personel.Surname);
            //}

            Console.ReadLine();
        }
    }
}
