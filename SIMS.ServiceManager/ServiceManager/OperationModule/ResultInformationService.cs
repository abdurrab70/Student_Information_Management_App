using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SIMS.Core.Model.OperationModule;
using SIMS.Core.ViewModel.OperationModule;
using SIMS.Persistance.DatabaseFile;

namespace SIMS.ServiceManager.ServiceManager.OperationModule
{
    public class ResultInformationService
    {
        private ApplicationDbContext _dbContext;

        public ResultInformationService()
        {
            _dbContext = new ApplicationDbContext();
        }

        public ResultInformationViewModel Get(int id)
        {
            var entity = _dbContext.ResultInformations.SingleOrDefault(c => c.Id == id);
            return (Mapper.Map<ResultInformation, ResultInformationViewModel>(entity));
        }

        public IEnumerable<ResultInformationViewModel> GetAll()
        {
            var entities = _dbContext.ResultInformations
                .Include("Department").ToList().Select(Mapper.Map<ResultInformation, ResultInformationViewModel>);

            return entities;
        }

        public int Add(ResultInformationViewModel vm)
        {
            var entity = Mapper.Map<ResultInformationViewModel, ResultInformation>(vm);
            entity.CreateBy = "User";
            entity.CreateDate = DateTime.Now;
            _dbContext.ResultInformations.Add(entity);
            _dbContext.SaveChanges();
            return entity.StudentEntryId;
        }

        public int Update(int id, ResultInformationViewModel vm)
        {
            var entity = _dbContext.ResultInformations.
                SingleOrDefault(c => c.Id == id);
            Mapper.Map(vm, entity);
            _dbContext.SaveChanges();

            // ReSharper disable once PossibleNullReferenceException
            return entity.StudentEntryId;
        }

        public int Remove(int id)
        {
            var entity = _dbContext.ResultInformations.SingleOrDefault(c => c.Id == id);
            _dbContext.ResultInformations.Remove(entity);
            return _dbContext.SaveChanges();
        }
    }
}
