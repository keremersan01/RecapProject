using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using Entity.DTOs;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {

        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }
        public IResult Add(Car car)
        {
            if((car.DailyPrice > 0) && (car.Description.Length >= 2))
            {
                _carDal.Add(car);
                return new SuccessResult(Messages.ProductAdded);
            }
            else
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            
        }

        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult("Product is deleted");
        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), true, "Get cars by brand id");
        }

        public IDataResult<List<CarDetailsDTO>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDTO>>(_carDal.GetCarDetails(), true, "Get car details");
        }

        public IDataResult<List<Car>> GetCarsByBrandId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.BrandId == id), true, "Get cars by brand id");
        }

        public IDataResult<List<Car>> GetCarsByColorId(int id)
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(c => c.ColorId == id), true, "Get cars by color id");
        }

        public IResult Update(Car car)
        {
             _carDal.Update(car);
            return new SuccessResult("Product is updated");
        }

    }
}
