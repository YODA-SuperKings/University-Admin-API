﻿using System;
using System.Collections.Generic;
using System.Text;
using BusinessLogic.Model.Models;

namespace BusinessLogic.Interface.IServices
{
    public interface ICollegeRegistrationService
    {
        List<CollegeRegistration> GetCollegeRegistration();
        string CreateCollegeRegistration(CollegeRegistration _CollegeRegistration);
    }
}
