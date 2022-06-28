using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EFCarDal : EFEntityRepositoryBase<Car, RecapContext>, ICarDal
    {
        public List<CarDetailsDTO> GetCarDetails()
        {
            using(RecapContext recapContext = new RecapContext())
            {
                var result = from car in recapContext.Cars
                             join color in recapContext.Colors
                             on car.ColorId equals color.Id
                             join brand in recapContext.Brands
                             on car.BrandId equals brand.Id
                             select new CarDetailsDTO()
                             {
                                 CarName = car.Description,
                                 BrandName = brand.Name,
                                 ColorName = color.Name,
                                 DailyPrice = car.DailyPrice
                             };

                return result.ToList();
            }
        }
    }
}
