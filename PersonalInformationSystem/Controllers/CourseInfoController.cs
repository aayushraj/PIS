﻿using System;
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
            else {
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
                return RedirectToAction("Index", "CourseInfo");
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult Delete(int CourseId)
        {
            TempData["msg"] = "<script>alert('Do you want to delete?');</script>";
            CourseInfoProvider pro = new CourseInfoProvider();
            pro.Delete(CourseId);
            return RedirectToAction("Index", "CourseInfo");
        }
    }
}