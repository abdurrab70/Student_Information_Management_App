using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using AutoMapper;
using SIMS.Core.Model.ComnmonModel;
using SIMS.Core.Model.OperationModule;
using SIMS.Core.Model.SetupModule;
using SIMS.Core.ViewModel.OperationModule;
using SIMS.Core.ViewModel.SetupModule;

namespace SIMS.Core.AutoMapperConfigurations
{
    public class MappingsProfile : Profile
    {
        public override string ProfileName => "MappingsProfile";

        public MappingsProfile()
        {
            CreateMap<Department, DepartmentViewModel>();
            CreateMap<DepartmentViewModel, Department>();

            CreateMap<Subject, SubjectViewModel>();
            CreateMap<SubjectViewModel, Subject>();


            CreateMap<StudentEntry, StudentEntryViewModel>().ForMember(vm => vm.BirthDate,
                opt => opt.MapFrom(m => DateTimeFormatter.DateToString(m.BirthDate)));

            CreateMap<StudentEntryViewModel, StudentEntry>()
                .ForMember(dto => dto.BirthDate,
                    opt => opt.MapFrom(m => DateTimeFormatter.StringToDate(m.BirthDate)));


            CreateMap<ResultInformation, ResultInformationViewModel>();
            CreateMap<ResultInformationViewModel, ResultInformation>();

            CreateMap<Marks, MarksViewModel>();
            CreateMap<MarksViewModel, Marks>();
        }
    }
}
