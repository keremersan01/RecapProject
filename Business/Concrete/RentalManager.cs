using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {

        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Rent(Rental rental)
        {
            if(_rentalDal.GetAll().Count == 0)
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
                
            }
            var result = _rentalDal.GetAll(r => r.CarId == rental.CarId).Last();
            if (result.ReturnDate != null)
            {
                _rentalDal.Add(rental);
                return new SuccessResult();
            }

            return new ErrorResult();
        }

    }
}
