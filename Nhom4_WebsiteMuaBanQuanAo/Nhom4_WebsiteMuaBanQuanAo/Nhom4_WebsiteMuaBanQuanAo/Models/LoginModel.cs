using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nhom4_WebsiteMuaBanQuanAo.Models
{
    public class LoginModel
    {
        DBPermissionEntitiesDataContext db = new DBPermissionEntitiesDataContext();

        [Display(Name = "Username")]
        public string Username { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }

        public bool IsValid(LoginModel model)
        {
            try
            {
                if (Convert.ToBoolean(db.admins.First(x => x.username == model.Username && x.password == model.Password).id_admin))
                {
                    SetAdminSession(db.admins.First(x => x.username == model.Username && x.password == model.Password).id_admin);
                    return true;
                }
            }
            catch (Exception) { }
            try
            {
                if (Convert.ToBoolean(db.teachers.First(x => x.username == model.Username && x.password == model.Password).id_teacher))
                {
                    SetTeacherSession(db.teachers.First(x => x.username == model.Username && x.password == model.Password).id_teacher);
                    return true;
                }
            }
            catch (Exception) { }
            try
            {
                if (Convert.ToBoolean(db.students.First(x => x.username == model.Username && x.password == model.Password).id_student))
                {
                    SetStudentSession(db.students.First(x => x.username == model.Username && x.password == model.Password).id_student);
                    return true;
                }
            }
            catch (Exception) { }
            return false;
        }
        public void SetAdminSession(int userID)
        {
            admin user = db.admins.SingleOrDefault(x => x.id_admin == userID);
            HttpContext.Current.Session.Add(Models.UserSession.ISLOGIN, true);
            HttpContext.Current.Session.Add(Models.UserSession.ID, user.id_admin);
            HttpContext.Current.Session.Add(Models.UserSession.PERMISSION, user.id_permission);
            HttpContext.Current.Session.Add(Models.UserSession.USERNAME, user.username);
            HttpContext.Current.Session.Add(Models.UserSession.EMAIL, user.email);
            HttpContext.Current.Session.Add(Models.UserSession.NAME, user.name);
        }
        public void SetTeacherSession(int userID)
        {
            teacher user = db.teachers.SingleOrDefault(x => x.id_teacher == userID);
            HttpContext.Current.Session.Add(Models.UserSession.ISLOGIN, true);
            HttpContext.Current.Session.Add(Models.UserSession.ID, user.id_teacher);
            HttpContext.Current.Session.Add(Models.UserSession.PERMISSION, user.id_permission);
            HttpContext.Current.Session.Add(Models.UserSession.USERNAME, user.username);
            HttpContext.Current.Session.Add(Models.UserSession.EMAIL, user.email);
            HttpContext.Current.Session.Add(Models.UserSession.NAME, user.name);
        }
        public void SetStudentSession(int userID)
        {
            student user = db.students.SingleOrDefault(x => x.id_student == userID);
            HttpContext.Current.Session.Add(Models.UserSession.ISLOGIN, true);
            HttpContext.Current.Session.Add(Models.UserSession.ID, user.id_student);
            HttpContext.Current.Session.Add(Models.UserSession.PERMISSION, user.id_permission);
            HttpContext.Current.Session.Add(Models.UserSession.USERNAME, user.username);
            HttpContext.Current.Session.Add(Models.UserSession.EMAIL, user.email);
            HttpContext.Current.Session.Add(Models.UserSession.NAME, user.name);
        }
    }
}