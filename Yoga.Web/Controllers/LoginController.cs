using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity.Enums;
using Yoga.Entity.Models;
using Yoga.Web.Common;
using Yoga.Web.Models;

namespace Yoga.Web.Controllers
{
    public class LoginController : BaseController
    {
        //
        // GET: /Login/

        public ActionResult Login(string redirectUrl)
        {
            if (Session[SessionConstant.SESSION_OPERATOR] != null)
            {
               return RedirectToAction("Index", "Home");
            }

            ViewBag.RedirectUrl = redirectUrl;
            return View();
        }

        public ActionResult Logout()
        {
            Session[SessionConstant.SESSION_OPERATOR] = null;
            return RedirectToAction("Login");
        }

        [HttpPost]
        public ActionResult DoLogin(LoginModel model)
        {
            var response = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Đăng nhập không thành công. Email hoặc mật khẩu không đúng"
            };
            var operatorBll = new OperatorBll();

            var oper = operatorBll.GetByEmail(model.Email);
            if (oper != null)
            {
                if (oper.StatusId == StatusEnum.INACTIVE.ToString())
                    response.ErrorString = "Tài khoản đã ngừng hoạt động";
                else if (oper.StatusId == StatusEnum.ACTIVE.ToString())
                {
                    Session[SessionConstant.SESSION_OPERATOR] = oper;
                    response.Result = true;
                    response.ErrorString = string.Empty;
                }
            }
            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}
