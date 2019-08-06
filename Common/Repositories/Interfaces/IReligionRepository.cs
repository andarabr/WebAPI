﻿using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IReligionRepository
    {
        List<Religion> Get();
        Religion Get(int id);
        List<Religion> Get(string value);
        bool Insert(ReligionVM religionVM);
        bool Update(int id, ReligionVM religionVM);
        bool Delete(int id);
    }
}