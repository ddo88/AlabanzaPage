using AlabanzaPage.App_Start;
using AlabanzaPage.Models;
using AlabanzaPage.Properties;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace AlabanzaPage.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn
        AlabanzaMembership mb = new AlabanzaMembership();

        public ActionResult LogOn()
        {
            
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {

                if (mb.ValidateUser(model.UserName, model.Password))
                {
                    //if (HttpContext.Application["Roles"] == null)
                    //{
                    //    //HttpContext.Application["Roles"] = p.Roles;
                    //    List<string> roles = HttpContext.Application["Roles"] as List<string>;
                    //}
                    Usuario u=mb.GetUser(model.UserName, false);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(10), true, model.UserName);
                    Session["UniqueUserId"]          = model.UserName;
                    Session["Role"]                  = u.Role;
                    string encTicket                 = FormsAuthentication.Encrypt(ticket);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket) { Expires = DateTime.Now.AddMinutes(10) });
                    FormsAuthentication.SetAuthCookie(u.User, model.RememberMe);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/") && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "El usuario o la contraseña es incorrecta.");
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            HttpContext.Application["Roles"] = null;
            Session["UniqueUserId"] = null;
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        ////
        //// GET: /Account/Register
        public ActionResult Register()
        {
            return View();
        }

        ////
        //// POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to register the user
                MembershipCreateStatus createStatus;
                Usuario u= new Usuario{ Id=model.Email,Pass=model.Password, User= model.Name };
                mb.CreateUser(u, out createStatus);
                //mb.CreateUser(model.UserName, model.Password, model.Email, null, null, true, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    FormsAuthentication.SetAuthCookie(model.Name, false /* createPersistentCookie */);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePassword

        [Authorize]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            
            if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    
                    Usuario currentUser = mb.GetUser(User.Identity.Name, true /* userIsOnline */);
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }

    public static class ExtensionUsuario
    {
        public static bool ChangePassword(this Usuario user, string oldPassword, string newPassword)
        {
            return true;
        }
    }

        public class AlabanzaMembership //: MembershipProvider
        {
            public readonly Context context = new Context();

            public static bool ChangePassword(string username, string oldPassword, string newPassword)
            {
                Context context = new Context();
                Usuario u=context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).Find(Query<Usuario>.EQ(x => x.Id, username)).First();
                if(u.Pass==GetMD5(oldPassword))
                {
                    u.Pass = GetMD5(newPassword);
                    WriteConcernResult result = context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).Update(Query.EQ("_id", username), Update.Replace(u), UpdateFlags.Upsert);
                    context.RemoveCache(Settings.Default.UsuariosCollection);
                    if (result.Ok)
                        return true;
                }       
                return false;
            }
            //public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
            public Usuario CreateUser(Usuario u, out MembershipCreateStatus status)
            {
                try
                {
                    u.Pass = GetMD5(u.Pass);
                    WriteConcernResult result = context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).Save(u);
                    context.RemoveCache(Settings.Default.UsuariosCollection);
                    if (result.Ok){
                        status = MembershipCreateStatus.Success;
                        return u;
                    }
                    else
                        status = MembershipCreateStatus.DuplicateUserName;
                }
                catch (Exception ex)
                {
                    status = MembershipCreateStatus.ProviderError;
                }
                return new Usuario();
            }
            public Usuario GetUser(string username, bool userIsOnline)
            {
                try
                {
                    var query = context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).Find(Query<Usuario>.EQ(x => x.Id, username)).First();
                    return (Usuario)query;
                }
                catch (Exception ex)
                {
                    return new Usuario();
                }
                
            }
        
            public bool ValidateUser(string username, string password)
            {
                Usuario user= context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).Find(Query<Usuario>.EQ(x => x.Id, username)).First();
                if (user.Pass == GetMD5(password))
                    return true;
                else
                    return false;
            }

            private static string GetMD5(string value)
            {

                value = value + "salt";
                MD5 md = MD5.Create();
                StringBuilder sBuilder = new StringBuilder();
                byte[] data = md.ComputeHash(System.Text.Encoding.ASCII.GetBytes(value));
                // Loop through each byte of the hashed data 
                // and format each one as a hexadecimal string.
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();

            }
    }
    
}
