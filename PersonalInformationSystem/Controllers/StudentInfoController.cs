using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalInformationSystem.Models;
using PersonalInformationSystem.Providers;


namespace PersonalInformationSystem.Controllers
{
    public class StudentInfoController : Controller
    {
        StudentInfoProvider pro = new StudentInfoProvider();
        

        // GET: StudentInfo
        public ActionResult Index()
        {
            StudentInfoModel model = new StudentInfoModel();
            model=pro.GetList(model);
            return View(model);
        }

               
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(StudentInfoModel model)
        {
          
            if(ModelState.IsValid)
            {
                pro.Save(model);


                return RedirectToAction("Index", "Home");
            }


            else { return View(model); }
           
        }

        public ActionResult Delete(int studentId)
        {
            pro.Delete(studentId);
           // TempData["Delete"] = Utility.ValidationMessage.delete;
            return RedirectToAction("Index", "StudentInfo");
        }
    }
}