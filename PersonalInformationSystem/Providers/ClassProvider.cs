using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalInformationSystem.Models;
using System.Data.Entity;
using System.Web.Mvc;

namespace PersonalInformationSystem.Providers
{
    public class ClassProvider
    {
        public ClassModel GetList()
        {
            ClassModel model = new ClassModel();
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();

            

            model.ClassModelList = (from s in ent.Classes
                                           where s.DeletedOn == null
                                           select new ClassModel
                                           {
                                               ClassId = s.ClassId,
                                               ClassName = s.ClassName,
                                               Status=s.Status
                                               

                                           }).ToList();

            

            return model;

        }

        public ClassModel GetClassByClassId(int classId)
        {
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();
            Class entityClass = ent.Classes.Where(x => x.ClassId == classId).FirstOrDefault();
            ClassModel model = new ClassModel();
            model.ClassId = entityClass.ClassId;
            model.ClassName = entityClass.ClassName;
            model.Status = entityClass.Status;

            return model;
        }
        public int Save(ClassModel model)
        {

            //database initailization
            Class entityClass = new Class();
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();

            //var toSave = AutoMapper.Mapper.Map<StudentInfoModel, StudentInfo>(model);

            entityClass.ClassId = model.ClassId;
            entityClass.ClassName = model.ClassName;
           
            if (model.ClassId != 0 && model.ClassId > 0)
            {
                ent.Entry(entityClass).State = EntityState.Modified;
                entityClass.ModifiedBy = 1;
                entityClass.ModifiedOn = DateTime.Now;
                entityClass.Status = model.Status;
            }

            else
            {
                ent.Classes.Add(entityClass);
                entityClass.CreatedBy = 1;
                entityClass.CreatedOn = DateTime.Now;
                entityClass.Status = true;
            }


            ent.SaveChanges();
            return 1;



        }
        public bool Delete(int classId)
        {
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();
            Class entityClass = ent.Classes.Where(x => x.ClassId == classId).FirstOrDefault();
            entityClass.DeletedOn = DateTime.Now;
            entityClass.DeletedBy = 1;
            ent.Entry(entityClass).State = EntityState.Modified;
            ent.SaveChanges();
            return true;
        }

    }
}