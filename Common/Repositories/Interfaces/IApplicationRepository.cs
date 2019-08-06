﻿using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IApplicationRepository
    {
        List<Application> Get();
        Application Get(int id);
        List<Application> Get(string value);
        bool Insert(ApplicationVM applicationVM);
        bool Update(int id, ApplicationVM applicationVM);
        bool Delete(int id);
    }
}