using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entity.Concrete;

namespace ConsoleUI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            CarManager carManager = new CarManager(new EFCarDal());
            

            foreach (var car in carManager.GetAll())
                Console.WriteLine(car.Description);

            Console.WriteLine("--------------------------");

            foreach(var car in carManager.GetAll().Where(c => c.DailyPrice > 10000))
                Console.WriteLine(car.Description);

            Console.WriteLine("--------------------------");

            foreach (var car in carManager.GetCarsByBrandId(5))
                Console.WriteLine(car.Description);

            Console.WriteLine("--------------------------");

            foreach (var car in carManager.GetCarsByColorId(8))
                Console.WriteLine(car.Description);

            carManager.Add(new Car() { Id = 2, BrandId = 3, ColorId = 4, Description = "aasd", DailyPrice = 0, ModelYear = 2012 });
            carManager.Add(new Car() { Id = 10, BrandId = 3, ColorId = 4, Description = "a", DailyPrice = 40, ModelYear = 2012 });

            Console.WriteLine("-----------------------------");
            foreach (var car in carManager.GetAll())
                Console.WriteLine(car.Description);


        }
    }
}