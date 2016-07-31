using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalInformationSystem.Models;
using System.Data.Entity;

namespace PersonalInformationSystem.Providers
{
    public class FacultyProvider
    {
        public FacultyModel GetList()
        {
           FacultyModel model = new FacultyModel();
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();
            //IEnumerable<FacultyModel> model = null;
            model.FacultyModelList = (from s in ent.Faculties
                                      join j in ent.Classes on s.ClassId equals j.ClassId
                                      where s.DeletedOn == null
                                      select new FacultyModel
                                      {

                                          FacultyId = s.FacultyId,
                                          FacultyName = s.FacultyName,
                                          FacultyDesc = s.FacultyDesc,
                                          Status = s.Status,
                                          ClassName = j.ClassName



                                      }).ToList();

            return model;
        }

        public FacultyModel GetFacultyById(int facultyId)
        {
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();
            Faculty entityFaculty = ent.Faculties.Where(x => x.FacultyId == facultyId).FirstOrDefault();
            FacultyModel model = new FacultyModel();
            model.ClassId = entityFaculty.ClassId;
            model.FacultyId = entityFaculty.FacultyId;
            model.FacultyName = entityFaculty.FacultyName;
            model.Status = entityFaculty.Status;
           
            return model;
        }

        public int Save(FacultyModel model)
        {

            //database initailization
            Faculty entityFaculty = new Faculty();
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();



            entityFaculty.FacultyId = model.FacultyId;
            entityFaculty.FacultyName = model.FacultyName;



            //Class entityClass = new Class();

            entityFaculty.ClassId = model.ClassId;


            if (model.FacultyId != 0 && model.FacultyId > 0)
            {
                ent.Entry(entityFaculty).State = EntityState.Modified;
                entityFaculty.ModifiedBy = 1;
                entityFaculty.ModifiedOn = DateTime.Now;
                entityFaculty.Status = model.Status;
            }

            else
            {
                ent.Faculties.Add(entityFaculty);
                entityFaculty.CreatedBy = 1;
                entityFaculty.Status = true;
                entityFaculty.CreatedOn = DateTime.Now;
            }


            ent.SaveChanges();
            return 1;



        }
        public bool Delete(int facultyId)
        {
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();
            Faculty entityFaculty = ent.Faculties.Where(x => x.FacultyId == facultyId).FirstOrDefault();
            entityFaculty.DeletedOn = DateTime.Now;
            entityFaculty.DeletedBy = 1;
            ent.Entry(entityFaculty).State = EntityState.Modified;
            ent.SaveChanges();
            return true;
        }

    }
}
