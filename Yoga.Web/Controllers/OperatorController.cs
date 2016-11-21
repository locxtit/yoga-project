using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Enums;
using Yoga.Entity.Models;
using Yoga.Web.Helpers;
using Yoga.Web.Infrastructure.Extensions;

namespace Yoga.Web.Controllers
{
    public class OperatorController : BaseController
    {
        //
        // GET: /Operator/

        [Authorized]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList()
        {
            try
            {
                var operatorBll = new OperatorBll();
                var myList = operatorBll.GetAll().OrderBy(x => x.Email);
                return Json(myList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? operatorId)
        {
            var oper = new Operator();
            if (operatorId.HasValue)
                oper = new OperatorBll().GetById(operatorId.Value);
            return PartialView("_EditOperator", oper);
        }

        public ActionResult Update(Operator model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };

            var operatorBll = new OperatorBll();
            if (ModelState.IsValid)
            {
                bool canSaveOrUpdate = false;
                if (model.OperatorId <= 0)
                {
                    var oper = operatorBll.GetByEmail(model.Email);
                    if (oper != null && oper.StatusId == StatusEnum.DELETED.ToString())
                        errorMessage.ErrorString = "Không cho phép tạo mới tài khoản đã bị xóa";
                    else if (oper != null)
                        errorMessage.ErrorString = "Email đã tồn tại trong hệ thống";
                    else
                        canSaveOrUpdate = true;
                }
                else
                    canSaveOrUpdate = true;

                if (canSaveOrUpdate)
                {
                    errorMessage.Result = new OperatorBll().SaveOrUpdate(model);
                    if (errorMessage.Result)
                    {
                        errorMessage.ErrorString = "Cập nhật thành công";
                        CategoryBll.Operators = null;
                    }
                }
            }
            else
            {
                errorMessage.ErrorString = Util.GetModelStateErrors(ModelState);
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int operatorId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var operatorBll = new OperatorBll();
            var oper = operatorBll.GetById(operatorId);
            if (oper == null)
            {
                response.ErrorString = "Không tồn tại Người dùng";
            }
            else
            {
                response.Result = operatorBll.Delete(operatorId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        public ActionResult IsExistEmail(string email)
        {
            var response = new ErrorMessage()
            {
                Result = true,
            };
            var operatorBll = new OperatorBll();
            var oper = operatorBll.GetByEmail(email);
            if (oper != null)
            {
                response.Result = false;
                response.ErrorString = "Email đã rồn tại. Vui lòng nhập email khác.";
            }
            
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [Authorized]
        public ActionResult Profile()
        {
            if (CurrentOperator != null)
            {
                ViewBag.Messag = null;
                return View(CurrentOperator);
            }

            return Redirect("/");
        }

        [HttpPost]
        [Authorized]
        public ActionResult Profile(Operator model)
        {
            if (CurrentOperator != null)
            {
                model.Email = CurrentOperator.Email;
                model.StatusId = CurrentOperator.StatusId;
                model.OperatorTypeId = CurrentOperator.OperatorTypeId;
                model.OperatorId = CurrentOperator.OperatorId;

                var message = new ErrorMessage()
                {
                    Result = false,
                    ErrorString = "Cập nhật thất bại"
                };

                if (new OperatorBll().SaveOrUpdate(model))
                {
                    message.Result = true;
                    message.ErrorString = "Cập nhật thành công";
                }

                ViewBag.Message = message;

                return View(CurrentOperator);
            }

            return Redirect("/");
        }

    }
}
