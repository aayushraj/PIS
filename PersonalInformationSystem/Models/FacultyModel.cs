using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonalInformationSystem.Models
{
    public class FacultyModel
    {
        public int FacultyId { get; set; }
        public int ClassId { get; set; }
        public string ClassName { get; set; }
        [Required]
        public string FacultyName { get; set; }
        public string FacultyDesc { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public int ModifiedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public int DeletedBy { get; set; }
        public DateTime DeletedOn { get; set; }
        public bool Status { get; set; }
        public ClassModel ObjClassModel { get; set; }
        public List<FacultyModel> FacultyModelList { get; set;}
        //public List<ClassModel> ClassModelList  { get; set; }

    }
}