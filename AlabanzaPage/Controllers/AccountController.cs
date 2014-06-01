using AlabanzaPage.App_Start;
using AlabanzaPage.Models;
using AlabanzaPage.Properties;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AlabanzaPage.Tools;

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
                    Usuario u=mb.GetUser(model.UserName, false);
                    FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(0, model.UserName, DateTime.Now, DateTime.Now.AddMinutes(10), true, u.Role);
                    Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName,FormsAuthentication.Encrypt( ticket)) { Expires = DateTime.Now.AddMinutes(10) });

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
            //HttpContext.Application["Roles"] = null;
            //Session["UniqueUserId"] = null;
            //Session["Role"] = null;
            FormsAuthentication.SignOut();
            Response.Cookies.Remove("Role");
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
            public readonly Context context = Context.GetInstance();

            public static bool ChangePassword(string username, string oldPassword, string newPassword)
            {
                Context context = Context.GetInstance();
                Usuario u=context.GetCollection<Usuario>(Settings.Default.UsuariosCollection).Find(Query<Usuario>.EQ(x => x.Id, username)).First();
                if (u.Pass == oldPassword.GetMD5())
                {
                    u.Pass = newPassword.GetMD5();
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
                    u.Pass = u.Pass.GetMD5();
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
                if (user.Pass == password.GetMD5())
                    return true;
                else
                    return false;
            }

            
    }
    
}
