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
            //CarManagerAdd();
            //ColorManagerAdd();
            //BrandManagerAdd();
            ListAllCarItems();
            ListCarDetails();

        }

        private static void ListCarDetails()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var carDetails in carManager.GetCarDetails())
                Console.WriteLine($"{carDetails.CarName} -- {carDetails.ColorName} -- {carDetails.BrandName} -- {carDetails.DailyPrice}");
        }

        private static void ListAllCarItems()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            foreach (var car in carManager.GetAll())
                Console.WriteLine("Car name: " + car.Description);
        }

        private static void CarManagerAdd()
        {
            CarManager carManager = new CarManager(new EFCarDal());
            carManager.Add(new Car() { Id = 1, BrandId = 1, ColorId = 1, Description = "Keremin Arabası", DailyPrice = 2500});
            carManager.Add(new Car() { Id = 2, BrandId = 2, ColorId = 1, Description = "Miracın Arabası", DailyPrice = 1800});
            carManager.Add(new Car() { Id = 3, BrandId = 2, ColorId = 2, Description = "Halilin Arabası", DailyPrice = 2100});
        }

        private static void BrandManagerAdd()
        {
            BrandManager brandManager = new BrandManager(new EFBrandDal());
            brandManager.Add(new Brand() { Id = 1, Name = "Hyundai" });
            brandManager.Add(new Brand() { Id = 2, Name = "Volvo" });
        }

        private static void ColorManagerAdd()
        {
            ColorManager colorManager = new ColorManager(new EFColorDal());
            colorManager.Add(new Color() { Id = 1, Name = "Kırmızı" });
            colorManager.Add(new Color() { Id = 2, Name = "Beyaz" });
        }
    }
}