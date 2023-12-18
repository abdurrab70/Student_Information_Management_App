using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using SIMS.Core.Model.SetupModule;

namespace SIMS.Core.ViewModel.OperationModule
{
    public class StudentEntryViewModel
    {
        public int Id { get; set; }
        [Required]
        public string StudentId { get; set; }
        [Required]
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string PhoneNo { get; set; }
        public string Email { get; set; }
        public string BirthDate { get; set; }
        public string PresentAddress { get; set; }
        public string PermanantAddress { get; set; }
        public string Nationality { get; set; }
        public string Gender { get; set; }
        public string BloodGroup { get; set; }
        public string Religion { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; }
        public string Section { get; set; }
        public string Remark { get; set; }
        public bool IsActive { get; set; }
        public string FatherPhoneNo { get; set; }
        public string MotherPhoneNo { get; set; }
        public string FatherEmail { get; set; }
        public string NidBirthCertificate { get; set; }
        public int StudentEntryId { get; set; }
    }
}
