using DAL.Models;
using DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;

namespace QuertionnaireCreator.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork _unitOfWork = new UnitOfWork();
        protected ApplicationUserManager _userManager;
      
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            protected set
            {
                _userManager = value;
            }
        }

        protected User GetUser()
        {
            if (User.Identity.IsAuthenticated)
            {
                if (UserManager != null)
                {
                    var membership = UserManager.FindByName(User.Identity.Name);
                    var pas = membership.PasswordHash;

                    if (membership != null)
                    {
                        var result = _unitOfWork.UserRepository.GetByMembershipId(membership.Id);
                        return result.CurrentObject;
                    }
                }
            }
            return null;
        }


        protected override void Dispose(bool disposing)
        {
            _unitOfWork.Dispose();

            base.Dispose(disposing);
        }
    }
}