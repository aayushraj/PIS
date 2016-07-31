using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PersonalInformationSystem.Utility
{
    public static class ValidationMessage
    {
        public static string save = "Successfully Saved!";
        public static string savefailed = "Save Failed !";
        public static string edit = "Successfully Updated!";
        public static string editfailed = "Update Failed !";
        public static string delete = "Successfully Deleted!";
        public static string deletefailed = "Deletion Failed !";
        public static string StartDateGreaterthenEndDate = "You Must be Select Start Date less then End Date!";
        public static string HasValues = "Check Start And End Date and Insert Unique Date Which is Not Insert In Database!";
        public static string AlreadyExitThisItems = "This is Already Exit Please Try Agan";
        public static string StartTimeGreaterThenEndTime = "You Must be Select Start Time less then End Time!";
        public static string BalanceLeaveisGreterThenDays = "You can not Access Grater Then Balance Leave Please Try Agan Other Leave";
    }
}