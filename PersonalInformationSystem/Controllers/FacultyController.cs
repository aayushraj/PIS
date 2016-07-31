﻿using PersonalInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalInformationSystem.Providers;

namespace PersonalInformationSystem.Controllers
{
    public class FacultyController : Controller
    {
        FacultyProvider pro = new FacultyProvider();
        // GET: StudentStream
        public ActionResult Index()
        {
            
            FacultyModel model = new FacultyModel();
            model = pro.GetList();

            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FacultyModel model)
        {
            if (ModelState.IsValid)
            { 
                 pro.Save(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int facultyID)
        {
            FacultyModel model = new FacultyModel();
            model = pro.GetFacultyById(facultyID);
            return View(model);

        }

        [HttpPost]
        public ActionResult Edit(FacultyModel model)
        {
            pro.Save(model);
            return RedirectToAction("Index", "Faculty");

        }

        public ActionResult Delete(int facultyId)
        {
            pro.Delete(facultyId);
            return RedirectToAction("Index", "Faculty");

        }
    }
}