﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalInformationSystem.Models;
using PersonalInformationSystem.Providers;

namespace PersonalInformationSystem.Controllers
{
    public class ClassController : Controller
    {
        ClassProvider pro = new ClassProvider();


        // GET: Class
        public ActionResult Index()
        {
            ClassModel model = new ClassModel();

            model = pro.GetList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ClassModel model)
        {
            if (ModelState.IsValid)
            {
                pro.Save(model);
                TempData["Success"] = Utility.ValidationMessage.save;
                return RedirectToAction("Index");
            }

            else
            {
                TempData["SuccessFail"] = Utility.ValidationMessage.savefailed;
                return View(model);
            }
        }

        public ActionResult Edit(int classId)
        {
            ClassModel model = new ClassModel();
            model = pro.GetClassByClassId(classId);
            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(ClassModel model)
        {
            if (ModelState.IsValid)
            { 
                pro.Save(model);
                TempData["Update"] = Utility.ValidationMessage.edit;
                return RedirectToAction("Index", "Class");
            }

            else
            {
                TempData["UpdateFail"] = Utility.ValidationMessage.editfailed;
                return View(model);

            }
        }



        public ActionResult Delete(int classId)
        {
            pro.Delete(classId);
            TempData["Delete"] = Utility.ValidationMessage.delete;
            return RedirectToAction("Index", "Class");
        }
    }
}