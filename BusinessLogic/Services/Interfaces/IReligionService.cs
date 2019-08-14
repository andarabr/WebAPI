using System.Collections.Generic;
using DataAccess.Models;
using DataAccess.ViewModels;

namespace BusinessLogic.Services.Interfaces
{
    public interface IReligionService
    {
        List<Religion> Get();
        Religion Get(int id);
        bool Insert(ReligionVM religionVM);
        bool Update(int id, ReligionVM religionVM);
        bool Delete(int id);
    }
}