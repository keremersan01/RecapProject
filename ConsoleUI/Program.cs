using Business.Concrete;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            CarManager carManager = new CarManager(new InMemoryCarDal());
            carManager.Add(
                new Car() { Id = 3, BrandId = 5, ColorId = 8, DailyPrice = 7800, Description = "Hyundai Car", ModelYear = 2005 }
                );

            foreach (var car in carManager.GetAll())
                Console.WriteLine(car.Description);

            Console.WriteLine("--------------------------");

            Car carToGet = carManager.GetById(2);
            Console.WriteLine(carToGet.Description);
            Console.WriteLine("------------------------");

            carManager.Delete(3);

            foreach (var car in carManager.GetAll())
                Console.WriteLine(car.Description);

        }
    }
}