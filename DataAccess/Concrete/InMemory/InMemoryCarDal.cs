using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        public InMemoryCarDal()
        {
            _cars = new List<Car>() 
            {
            new Car(){ Id = 1, BrandId = 1, ColorId = 2, DailyPrice = 25000, Description = "Honda car", ModelYear = 2000 },
            new Car(){ Id = 2, BrandId = 2, ColorId = 2, DailyPrice = 17500, Description = "Fiat car", ModelYear = 2010 }
            };
        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }

        public void Delete(int id)
        {
            //Linq
            Car carToDelete = _cars.First(c => c.Id == id);

            _cars.Remove(carToDelete);
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public Car GetById(int id)
        {
            return _cars.First(car => car.Id == id);
        }

        public void Update(Car car)
        {
            //Linq
            Car carToUpdate = _cars.First(c => c.Id == car.Id);

            carToUpdate.Id = car.Id;
            carToUpdate.BrandId = car.BrandId; 
            carToUpdate.ColorId = car.ColorId;
        }
    }
}
