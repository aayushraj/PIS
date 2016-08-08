using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalInformationSystem.Providers;
using PersonalInformationSystem.Models;

namespace PersonalInformationSystem.Controllers
{
    public class CourseInfoController : Controller
    {
        CourseInfoProvider pro = new CourseInfoProvider();
        // GET: CourseInfo
        public ActionResult Index()
        {
            CourseInfoModel model = new CourseInfoModel();
            model=pro.GetList();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(CourseInfoModel model)
        {
            if (ModelState.IsValid)
            {
                pro.Save(model);
                TempData["Success"] = Utility.ValidationMessage.save;
                return RedirectToAction("Index", "CourseInfo");
                //return View ();
            }
            else
            {
                TempData["UpdateFail"] = Utility.ValidationMessage.editfailed;
                return View(model);

            }

        }
        //GET
        public ActionResult Edit(int courseId)
        {
            CourseInfoProvider pro = new CourseInfoProvider();
            CourseInfoModel model = new CourseInfoModel();
            model = pro.GetCourseInfobyCourseId(courseId);
            return View (model);
        }

        [HttpPost]
        public ActionResult Edit(CourseInfoModel model)
        {
            CourseInfoProvider pro = new CourseInfoProvider();
            if(ModelState.IsValid)
            {
                pro.Save(model);
                TempData["Update"] = Utility.ValidationMessage.edit;
                return RedirectToAction("Index", "CourseInfo");
            }
            else
            {
                TempData["UpdateFail"] = Utility.ValidationMessage.editfailed;
                return View(model);
            }
        }

        public ActionResult Delete(int CourseId)
        {
            try
            {
                //TempData["msg"] = "<script>alert('Do you want to delete?');</script>";
                CourseInfoProvider pro = new CourseInfoProvider();
                TempData["Delete"] = Utility.ValidationMessage.delete;
                pro.Delete(CourseId);
                return RedirectToAction("Index", "CourseInfo");
            }

            catch
            {
                TempData["DeleteFail"] = Utility.ValidationMessage.deletefailed;

            }
            return View();
        }
    }
}