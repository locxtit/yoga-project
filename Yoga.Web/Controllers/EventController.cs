using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Enums;
using Yoga.Entity.Models;

namespace Yoga.Web.Controllers
{
    public class EventController : Controller
    {
        //
        // GET: /Event/

        public ActionResult Index(string eventTypeId)
        {
            if (eventTypeId == EventTypeEnum.CENTRAL_ACTIVITY.ToString())
                ViewBag.Title = "Danh sách Hoạt động trung tâm";
            else if (eventTypeId == EventTypeEnum.COMMUNITY_ACTIVITY.ToString())
                ViewBag.Title = "Danh sách Hoạt động Cộng đồng";
            ViewBag.EventTypeId = eventTypeId;
            return View();
        }

        public ActionResult Edit(int? eventId, string eventTypeId)
        {
            var model = new Event();
            if (eventId.HasValue && eventId.Value > 0)
            {
                model = new EventBll().GetById(eventId.Value);
            }
            else
            {
                if (string.IsNullOrEmpty(eventTypeId))
                {
                    eventTypeId = EventTypeEnum.CENTRAL_ACTIVITY.ToString();
                }
            }

            if (model == null)
                model = new Event();

            model.EventTypeId = eventTypeId;
            return View(model);
        }

        public ActionResult GetList(string eventTypeId)
        {
            try
            {
                var eventBll = new EventBll();
                var events = eventBll.GetByEventType(eventTypeId).OrderByDescending(x => x.CreatedDate);
                return Json(events, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public ActionResult Edit(Event model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                errorMessage.Result = new EventBll().SaveOrUpdate(model);
                if (errorMessage.Result)
                {
                    errorMessage.ErrorString = "Cập nhật thành công";
                }
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int eventId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var eventBll = new EventBll();
            var events = eventBll.GetById(eventId);
            if (events == null)
            {
                response.ErrorString = "Không tồn tại Hoạt động";
            }
            else
            {
                response.Result = eventBll.Delete(eventId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Joiners(int eventId)
        {
            var model = new EventBll().GetById(eventId);
            return View(model);
        }

        public ActionResult GetJoiners(int eventId)
        {
            try
            {
                var eventJoinerBll = new EventJoinerBll();
                var eventJoiners = eventJoinerBll.GetByEventId(eventId).OrderByDescending(x=>x.CreatedDate);
                return Json(eventJoiners, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult EditJoiner(int? eventjoinerId)
        {
            var model = new EventJoiner();
            if (eventjoinerId.HasValue && eventjoinerId.Value > 0)
            {
                model = new EventJoinerBll().GetById(eventjoinerId.Value);
            }

            if (model == null)
                model = new EventJoiner();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditJoiner(Event model)
        {
            var errorMessage = new ErrorMessage()
            {
                Result = false,
                ErrorString = "Cập nhật thất bại"
            };
            if (ModelState.IsValid)
            {
                errorMessage.Result = new EventJoinerBll().SaveOrUpdate(model);
                if (errorMessage.Result)
                {
                    errorMessage.ErrorString = "Cập nhật thành công";
                }
            }
            return Json(errorMessage, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteJoiner(int eventJoinerId)
        {
            var response = new ErrorMessage()
            {
                Result = false,
            };
            var eventJoinerBll = new EventJoinerBll();
            var eventJoiner = eventJoinerBll.GetById(eventJoinerId);
            if (eventJoiner == null)
            {
                response.ErrorString = "Không tồn tại thành viên";
            }
            else
            {
                response.Result = eventJoinerBll.Delete(eventJoinerId);
                if (!response.Result)
                    response.ErrorString = "Xóa thất bại";

            }
            return Json(response, JsonRequestBehavior.AllowGet);

        }
    }
}
