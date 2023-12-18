using AutoMapper;
using SIMS.Core.Model.SetupModule;
using SIMS.Core.ViewModel.SetupModule;
using SIMS.Persistance.DatabaseFile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIMS.ServiceManager.ServiceManager.SetupModule
{
    public class DepartmentServiceManager
    {
        private ApplicationDbContext _departmentContext;

        public DepartmentServiceManager()
        {
            _departmentContext = new ApplicationDbContext();
        }
        // single data tolar jonne ata kora
        public DepartmentViewModel Get(int id)
        {
            var entity = _departmentContext.Departments.SingleOrDefault(c => c.Id == id);

            //var model = new DepartmentViewModel()
            //{
            //    Id = entity.Id,
            //    Code = entity.Code,
            //    Name = entity.Name,
            //    IsActive = entity.IsActive
            //};

            return (Mapper.Map<Department, DepartmentViewModel>(entity));

        }
        // all data tolar jonne
        public IEnumerable<DepartmentViewModel> GetAll()
        {
            var entities = _departmentContext.Departments.ToList().Select(Mapper.Map<Department, DepartmentViewModel>);
            return entities;
        }

        public int Add(DepartmentViewModel vm)
        {
            var entity = Mapper.Map<DepartmentViewModel, Department>(vm);

            _departmentContext.Departments.Add(entity: entity);
            return _departmentContext.SaveChanges();
        }

        // individuals data update
        public int AddWindows(Department vm)
        {
             //var entity = Mapper.Map<DepartmentViewModel, Department>(vm);

            _departmentContext.Departments.Add(vm);
            return _departmentContext.SaveChanges();
        }

        public int Update(int id, DepartmentViewModel vm)
        {
            var entity = _departmentContext.Departments.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _departmentContext.SaveChanges();
        }

        public int Remove(int id)
        {
            var entity = _departmentContext.Departments.SingleOrDefault(c => c.Id == id);
            _departmentContext.Departments.Remove(entity);
            return _departmentContext.SaveChanges();
        }
    }
}
