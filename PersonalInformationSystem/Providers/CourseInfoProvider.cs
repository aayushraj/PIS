using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PersonalInformationSystem.Models;
using System.Data.Entity;

namespace PersonalInformationSystem.Providers
{
    public class CourseInfoProvider
    {
        public CourseInfoModel GetList()
        {
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();
            CourseInfoModel model = new CourseInfoModel();
            model.CourseInfoModelList = (from c in ent.CourseInfoes
                                         where c.DeletedOn == null
                                         select new CourseInfoModel
                                         {
                                            CourseId=c.CourseId,
                                            CourseName=c.CourseName,
                                            CourseDesc=c.CourseDesc,
                                            CourseDuration=c.CourseDuration,
                                            CourseAmount=c.CourseAmount,
                                            Facilitator=c.Facilitator,
                                            CreatedBy=c.CreatedBy,
                                            CreatedOn=c.CreatedOn,
                                            ModifiedBy=c.ModifiedBy,
                                            ModifiedOn=c.ModifiedOn,
                                            DeletedBy=c.DeletedBy,
                                            DeletedOn=c.DeletedOn,
                                            Status=c.Status
                                         }).ToList();
        
            return model;
        }
        public CourseInfoModel GetCourseInfobyCourseId(int courseId)
        {
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();
            CourseInfo entityCourseInfo = ent.CourseInfoes.Where(x => x.CourseId == courseId).FirstOrDefault();
            CourseInfoModel model = new CourseInfoModel();

            model.CourseId = entityCourseInfo.CourseId;
            model.CourseName = entityCourseInfo.CourseName;
            model.CourseDesc = entityCourseInfo.CourseDesc;
            model.CourseDuration = entityCourseInfo.CourseDuration;
            model.Facilitator = entityCourseInfo.Facilitator;
            model.CourseAmount = entityCourseInfo.CourseAmount;
            model.Status = entityCourseInfo.Status;
            model.CreatedBy = entityCourseInfo.CreatedBy;
            model.CreatedOn = entityCourseInfo.CreatedOn;
            model.ModifiedBy = entityCourseInfo.ModifiedBy;
            model.ModifiedOn = entityCourseInfo.ModifiedOn;
            model.DeletedBy = entityCourseInfo.DeletedBy;
            model.DeletedOn = entityCourseInfo.DeletedOn;
            return model;
        }
        public int Save(CourseInfoModel model)
        {
            CourseInfo entityCourseInfo = new CourseInfo();
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();

            entityCourseInfo.CourseId = model.CourseId;
            entityCourseInfo.CourseName = model.CourseName;
            entityCourseInfo.CourseDesc = model.CourseDesc;
            entityCourseInfo.CourseDuration = model.CourseDuration;
            entityCourseInfo.Facilitator = model.Facilitator;
            entityCourseInfo.CourseAmount = model.CourseAmount;

            if(model.CourseId!=0 && model.CourseId > 0)
            {
                ent.Entry(entityCourseInfo).State = EntityState.Modified;
                entityCourseInfo.ModifiedBy = 1;
                entityCourseInfo.ModifiedOn = DateTime.Now;
                entityCourseInfo.Status = model.Status;

            }
            else
            {
                ent.Entry(entityCourseInfo).State = EntityState.Added;
                entityCourseInfo.CreatedBy = 1;
                entityCourseInfo.Status = true;
                entityCourseInfo.CreatedOn = DateTime.Now;
            }
            ent.SaveChanges();
            return 1;
        }
        public bool Delete(int courseinfoId)
        {
            PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities();
            CourseInfo entityCourseInfo = ent.CourseInfoes.Where(x => x.CourseId == courseinfoId).FirstOrDefault();
            entityCourseInfo.DeletedBy = 1;
            entityCourseInfo.DeletedOn = DateTime.Now;
            ent.Entry(entityCourseInfo).State = EntityState.Modified;
            ent.SaveChanges();
            return true;
        }
    }
}