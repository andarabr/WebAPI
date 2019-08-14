using System.Web.Http;
using BusinessLogic.Services;
using BusinessLogic.Services.Interfaces;
using Unity;
using Unity.WebApi;
using Common.Repositories.Interfaces;
using Common.Repositories;

namespace API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IApplicationService, ApplicationService>();
            container.RegisterType<IContractService, ContractService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            container.RegisterType<IDivisionService, DivisionService>();
            container.RegisterType<IDistrictService, DistrictService>();
            container.RegisterType<IEmployeeService, EmployeeService>();
            //container.RegisterType<ILoginApplicationService, LoginApplicationService>();
            container.RegisterType<ILoginService, LoginService>();
            container.RegisterType<IParameterService, ParameterService>();
            container.RegisterType<IProvinceService, ProvinceService>();
            container.RegisterType<IRegencyService, RegencyService>();
            container.RegisterType<IReligionService, ReligionService>();
            container.RegisterType<IRoleService, RoleService>();
            container.RegisterType<IVillageService, VillageService>();

            container.RegisterType<IApplicationRepository, ApplicationRepository>();
            container.RegisterType<IContractRepository, ContractRepository>();
            container.RegisterType<IDepartmentRepository, DepartmentRepository>();
            container.RegisterType<IDivisionRepository, DivisionRepository>();
            container.RegisterType<IDistrictRepository, DistrictRepository>();
            container.RegisterType<IEmployeeRepository, EmployeeRepository>();
            //container.RegisterType<ILoginApplicationRepository, LoginApplicationRepository>();
            container.RegisterType<ILoginRepository, LoginRepository>();
            container.RegisterType<IParameterRepository, ParameterRepository>();
            container.RegisterType<IProvinceRepository, ProvinceRepository>();
            container.RegisterType<IRegencyRepository, RegencyRepository>();
            container.RegisterType<IReligionRepository, ReligionRepository>();
            container.RegisterType<IRoleRepository, RoleRepository>();
            container.RegisterType<IVillageRepository, VillageRepository>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}