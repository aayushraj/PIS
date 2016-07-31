using System.Collections.Generic;
using System.Web.Mvc;
using PersonalInformationSystem.Models;
using System.Linq;

namespace PersonalInformationSystem.Utility
{
    public class Utility
    {
        public static IEnumerable<SelectListItem> GetClasses()
        {
            using (PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities())
            {
                return new SelectList(ent.Classes.Where(m=>m.Status==true).ToList(), "ClassId", "ClassName");
            }
        }

        public static IEnumerable<SelectListItem> GetFaculties()
        {
            using (PersonalInformationSystemEntities ent = new PersonalInformationSystemEntities())
            {
                return new SelectList(ent.Faculties.Where(m=>m.Status==true), "FacultyId", "FacultyName");
            }
        }

        public static IEnumerable<SelectListItem> GetGender()
        {
            return new SelectList(new[]
            {

                new {Id="1",Value="Male"},
                new {Id="2",Value="Female"},



            }, "value", "Value");
        }

        public static IEnumerable<SelectListItem> GetAns()
        {
            return new SelectList(new[]
            {

                new {Id="1",Value="Yes"},
                new {Id="2",Value="No"},



            }, "value", "Value");
        }

    }
}