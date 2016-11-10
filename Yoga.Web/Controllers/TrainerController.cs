using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Models;

namespace Yoga.Web.Controllers
{
    public class TrainerController : Controller
    {
        //
        // GET: /Trainer/

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
                    TrainerName = phone,
                };
                var trainerBll = new TrainerBll();
                var trainners = trainerBll.Search(criteria).OrderByDescending(x => x.CreatedDate);
                return Json(trainners, JsonRequestBehavior.AllowGet);
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

    }
}
