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
using Yoga.Web.Models;

namespace Yoga.Web.Controllers
{
    public class ClassInfoController : BaseController
    {
        //
        // GET: /ClassInfo/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(int? trainerId, string customerName)
        {
            try
            {
                SearchClassInfoCriteriaModel criteria = new SearchClassInfoCriteriaModel()
                {
                    TrainerId = trainerId,
                    CustomerName = customerName,
                };
                var classInfoBll = new ClassInfoBll();
                var classInfos = classInfoBll.Search(criteria).OrderByDescending(x => x.CreatedDate);

                var model = classInfos.Select(x => new ClassInfoViewModel
                {
                    ClassInfoId = x.ClassInfoId,
                    ClassName = x.ClassName,
                    CompletedPayment = x.CompletedPayment,
                    CreatedDate = x.CreatedDate,
                    CustomerName = x.Customer.Name,
                    CustomerPhone = x.Customer.Phone,
                    NumOfPaidDays = x.NumOfPaidDays,
                    Price = x.Price,
                    StartDate = x.StartDate,
                    StatusName = x.Status.StatusName,
                    TotalDays = x.TotalDays,
                    TrainerName = x.Trainer.TrainerName,
                    TrainerPrice = x.TrainerPrice,
                });

                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? classInfoId)
        {
            var classInfo = new ClassInfo();
            if (classInfoId.HasValue)
                classInfo = new ClassInfoBll().GetById(classInfoId.Value);
            return PartialView("_EditClassInfo", classInfo);
        }

        public ActionResult Update(ClassInfo model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                errorMessage.Result = new ClassInfoBll().SaveOrUpdate(model);
                if (errorMessage.Result)
                {
                    errorMessage.ErrorString = "Cập nhật thành công";
                }
            }
            else
                errorMessage.ErrorString = Util.GetModelStateErrors(ModelState);
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int classInfoId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var classInfoBll = new ClassInfoBll();
            var classInfo = classInfoBll.GetById(classInfoId);
            if (classInfo == null)
            {
                response.ErrorString = "Không tồn tại Lớp";
            }
            else
            {
                response.Result = classInfoBll.Delete(classInfoId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        public ActionResult PaymentList(int classInfoId)
        {
            var classInfo = new ClassInfoBll().GetById(classInfoId);
            var orders = new OrderBll().GetByClassInfoId(classInfoId).ToList();
            ViewBag.ClassInfo = classInfo;
            return View(orders);
        }

        public ActionResult CreateOrder(int classInfoId)
        {
            var model = new Order();
            var classInfo = new ClassInfoBll().GetById(classInfoId);
            model.Price = classInfo.Price;
            model.PriceForTrainer = classInfo.TrainerPrice;
            model.ClassInfoId = classInfo.ClassInfoId;

            ViewBag.ClassInfo = classInfo;
            return PartialView("_CreateOrder", model);
        }

        public ActionResult EditOrder(int orderId)
        {
            var model = new OrderBll().GetById(orderId);
            var classInfo = new ClassInfoBll().GetById(model.ClassInfoId);

            ViewBag.ClassInfo = classInfo;
            return PartialView("_CreateOrder", model);
        }

        [HttpPost]
        public ActionResult SaveOrder(Order model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                var classInfoBll = new ClassInfoBll();
                var classInfo = classInfoBll.GetById(model.ClassInfoId);
                if (classInfo != null)
                {

                    var orderBll = new OrderBll();
                    var oldOrder = orderBll.GetById(model.OrderId);
                    if (oldOrder == null)
                    {
                        if (classInfo.TotalDays - classInfo.NumOfPaidDays < model.NumOfDays)
                        {
                            errorMessage.ErrorString = string.Format("Không thể thanh toán số ngày vượt quá {0}", classInfo.TotalDays - classInfo.NumOfPaidDays);
                        }
                        else
                        {
                            model.OperatorId = CurrentOperator.OperatorId;
                            if (model.OrderStatusId == OrderStatusEnum.PAID.ToString())
                            {
                                model.PaymentDate = DateTime.Now;
                            }
                            errorMessage.Result = orderBll.SaveOrUpdate(model);
                        }
                    }
                    else
                    {
                        if (oldOrder.OrderStatusId == OrderStatusEnum.PAID.ToString() && oldOrder.OrderStatusId == OrderStatusEnum.CANCEL.ToString())
                        {
                            errorMessage.ErrorString = "Hóa đơn đã thanh toán hoặc đã bị hủy. Không thể cập nhật được";
                        }
                        else
                        {
                            if (model.OrderStatusId == OrderStatusEnum.WAITING.ToString())
                            {
                                errorMessage.ErrorString = "Hóa đơn ko cho phép Cập nhật";
                            }
                            else
                            {
                                oldOrder.OrderStatusId = model.OrderStatusId;
                                if (model.OrderStatusId == OrderStatusEnum.PAID.ToString())
                                {
                                    oldOrder.PaymentDate.ToString();
                                }
                                errorMessage.Result = orderBll.SaveOrUpdate(oldOrder);
                            }
                        }
                    }

                    if (errorMessage.Result)
                    {
                        if (model.OrderStatusId == OrderStatusEnum.PAID.ToString())
                        {
                            classInfoBll.UpdateByOrder(model);
                        }
                        errorMessage.ErrorString = "Cập nhật thành công";
                    }
                }
                else
                {
                    errorMessage.ErrorString = "Không tồn tại thông tin lớp";
                }
            }
            else
                errorMessage.ErrorString = Util.GetModelStateErrors(ModelState);
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }
    }
}
