using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace Common.Repositories.Interfaces
{
    public interface IDivisionRepository
    {
        List<Division> Get();
        Division Get(int id);
        bool Insert(DivisionVM divisionVM);
        bool Update(int id, DivisionVM divisionVM);
        bool Delete(int id);
    }
}