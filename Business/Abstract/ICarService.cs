using Entity.Concrete;
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
        void Delete(int id);
        void Add(Car car);
        void Update(Car car);
        Car GetById(int id);
    }
}
