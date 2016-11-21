using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Models;
using Yoga.Web.Helpers;
using Yoga.Web.Infrastructure.Extensions;
using Yoga.Web.Models;

namespace Yoga.Web.Controllers
{
    public class TrainerController : Controller
    {
        //
        // GET: /Trainer/
        [Authorized]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetList(string email, string phone, string trainerName)
        {
            try
            {
                var criteria = new SearchTrainerCriteriaModel()
                {
                    Email = email,
                    Phone = phone,
                    TrainerName = trainerName,
                };
                var trainerBll = new TrainerBll();
                var trainners = trainerBll.Search(criteria).OrderByDescending(x => x.CreatedDate);
                var model = trainners.Select(x => new TrainerViewModel
                {
                    Address = x.Address,
                    CreatedDate = x.CreatedDate,
                    Email = x.Email,
                    Experience = x.Experience,
                    Note = x.Note,
                    Phone = x.Phone,
                    Status = x.Status,
                    StatusId = x.StatusId,
                    Subject = x.Subject,
                    TrainerId = x.TrainerId,
                    TrainerName = x.TrainerName
                });
                return Json(model, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Edit(int? trainerId)
        {
            var trainer = new Trainer();
            if (trainerId.HasValue)
                trainer = new TrainerBll().GetById(trainerId.Value);
            return PartialView("_EditTrainer", trainer);
        }

        public ActionResult Update(Trainer model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                
                errorMessage.Result = new TrainerBll().SaveOrUpdate(model);
                if (errorMessage.Result)
                {
                    errorMessage.ErrorString = "Cập nhật thành công";
                }
            }
            else
            {
                errorMessage.ErrorString = Util.GetModelStateErrors(ModelState);
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int trainerId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var trainerBll = new TrainerBll();
            var trainer = trainerBll.GetById(trainerId);
            if (trainer == null)
            {
                response.ErrorString = "Không tồn tại Tỉnh";
            }
            else
            {
                response.Result = trainerBll.Delete(trainerId);
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
            var trainerBll = new TrainerBll();
            var trainer = trainerBll.GetByEmail(email);
            if (trainer != null)
            {
                response.Result = false;
                response.ErrorString = "Email đã rồn tại. Vui lòng nhập email khác.";
            }

            return Json(response, JsonRequestBehavior.AllowGet);
        }

        public ActionResult BankInfos(int trainerId)
        {
            var trainer = new TrainerBll().GetById(trainerId);
            ViewBag.Trainer = trainer;
            var bankInfos = new BankInfoBll().GetByTrainerId(trainerId);
            return PartialView("_BankInfos", bankInfos);
        }

        public ActionResult EditBankInfo(int bankInfoId, int trainerId)
        {
            var trainer = new TrainerBll().GetById(trainerId);
            var bankInfo = new BankInfoBll().GetById(bankInfoId);
            if (bankInfo == null)
                bankInfo = new BankInfo()
                    {
                        TrainerId = trainer.TrainerId
                    };
            return PartialView("_EditBankInfo", bankInfo);
        }

        [HttpPost]
        public ActionResult SaveBankInfo(BankInfo model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                var bankInfoBll = new BankInfoBll();
                if (bankInfoBll.SaveOrUpdate(model))
                {
                    errorMessage.Result = true;
                    errorMessage.ErrorString = "Cập nhật thành công";
                }
            }
            else
                errorMessage.ErrorString = Util.GetModelStateErrors(ModelState);
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        
        }

        [HttpPost]
        public ActionResult DeleteBankInfo(int bankInfoId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var bankInfoBll = new BankInfoBll();
            var bankInfo = bankInfoBll.GetById(bankInfoId);
            if (bankInfo == null)
            {
                response.ErrorString = "Không tồn tại Thông tin ngân hàng";
            }
            else
            {
                response.Result = bankInfoBll.Delete(bankInfoId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

    }
}
