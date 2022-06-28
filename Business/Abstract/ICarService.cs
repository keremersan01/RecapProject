using Entity.Concrete;
using Entity.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        void Delete(Car car);
        void Add(Car car);

        void Update(Car car);
        public List<Car> GetCarsByColorId(int id);
        public List<Car> GetCarsByBrandId(int id);
        public List<CarDetailsDTO> GetCarDetails();
    }
}
