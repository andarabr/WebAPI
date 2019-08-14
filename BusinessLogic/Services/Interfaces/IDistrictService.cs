﻿using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface IDistrictService
    {
        List<District> Get();
        District Get(int id);
        bool Insert(DistrictVM districtVM);
        bool Update(int id, DistrictVM districtVM);
        bool Delete(int id);
    }
}