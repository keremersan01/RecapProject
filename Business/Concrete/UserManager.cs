﻿using Business.Abstract;
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
    public class UserManager: IUserService
    {

        IUserDal _userDal;

    public UserManager(IUserDal userDal)
    {
            _userDal = userDal;
    }
    public IResult Add(User user)
    {
        _userDal.Add(user);
         return new SuccessResult("user is added");
    }
}
}
