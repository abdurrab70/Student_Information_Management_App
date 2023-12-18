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
    public class SubjectServiceManager
    {
        private ApplicationDbContext _subjetContext;

        public SubjectServiceManager()
        {
            _subjetContext = new ApplicationDbContext();
        }
        // single data tolar jonne ata kora
        public SubjectViewModel Get(int id)
        {
            var entity = _subjetContext.Subjects.SingleOrDefault(c => c.Id == id);

            //var model = new DepartmentViewModel()
            //{
            //    Id = entity.Id,
            //    Code = entity.Code,
            //    Name = entity.Name,
            //    IsActive = entity.IsActive
            //};

            return (Mapper.Map<Subject, SubjectViewModel>(entity));

        }
        // all data tolar jonne
        public IEnumerable<SubjectViewModel> GetAll()
        {
            var entities = _subjetContext.Subjects.ToList().Select(Mapper.Map<Subject, SubjectViewModel>);
            return entities;
        }

        public int Add(SubjectViewModel vm)
        {
            var entity = Mapper.Map<SubjectViewModel, Subject>(vm);

            _subjetContext.Subjects.Add(entity: entity);
            return _subjetContext.SaveChanges();
        }

        // individuals data update
        public int AddWindows(Subject vm)
        {
            // var entity = Mapper.Map<DepartmentViewModel, Department>(vm);

            _subjetContext.Subjects.Add(entity: vm);
            return _subjetContext.SaveChanges();
        }

        public int Update(int id, SubjectViewModel vm)
        {
            var entity = _subjetContext.Subjects.SingleOrDefault(c => c.Id == id);

            Mapper.Map(vm, entity);

            return _subjetContext.SaveChanges();
        }

        public int Remove(int id)
        {
            var entity = _subjetContext.Subjects.SingleOrDefault(c => c.Id == id);
            _subjetContext.Subjects.Remove(entity);
            return _subjetContext.SaveChanges();
        }
    }
}
