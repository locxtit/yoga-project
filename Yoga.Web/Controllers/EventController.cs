using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Yoga.Bussiness;
using Yoga.Entity;
using Yoga.Entity.Enums;
using Yoga.Entity.Models;
using Yoga.Web.Infrastructure.Extensions;

namespace Yoga.Web.Controllers
{
    public class EventController : BaseController
    {
        //
        // GET: /Event/

        [Authorized]
        public ActionResult Index(string eventTypeId)
        {
            if (eventTypeId == EventTypeEnum.CENTRAL_ACTIVITY.ToString())
                ViewBag.Title = "Danh sách Hoạt động trung tâm";
            else if (eventTypeId == EventTypeEnum.COMMUNITY_ACTIVITY.ToString())
                ViewBag.Title = "Danh sách Hoạt động Cộng đồng";
            ViewBag.EventTypeId = eventTypeId;
            return View();
        }

        [Authorized]
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


            if (model.EventId <= 0)
            {
                model.EventTypeId = eventTypeId;
            }

            return View(model);
        }

        public ActionResult GetList(string eventTypeId, string title, string organizerName, string phone, int? trainerId)
        {
            try
            {
                var criteria = new SearchEventCriteriaModel
                {
                    EventTypeId = eventTypeId,
                    OrganizerName = organizerName,
                    OrganizerPhone = phone,
                    Title = title,
                    TrainerId = trainerId

                };
                var eventBll = new EventBll();
                var events = eventBll.Search(criteria);

                var models = events.Select(x=>new EventViewModel
                {
                    ContentDetail = x.ContentDetail,
                    CreatedDate = x.CreatedDate,
                    Description = x.Description,
                    EventId = x.EventId,
                    EventTypeId = x.EventTypeId,
                    EventType = x.EventType,
                    OperatorId = x.OperatorId,
                    OrganizerName = x.OrganizerName,
                    OrganizerEmail = x.OrganizerEmail,
                    OrganizerPhone = x.OrganizerPhone,
                    OrganizerAddress = x.OrganizerAddress,
                    StartDate = x.StartDate,
                    Title = x.Title,
                    StatusId = x.StatusId,
                    Status = x.Status,
                    Operator = x.Operator,
                    TrainerNames = x.TrainerNames
                }).ToList();
                return Json(models, JsonRequestBehavior.AllowGet);
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
                var eventBll = new EventBll();

                var oldEvent = eventBll.GetById(model.EventId);
                if (oldEvent == null)
                {
                    model.OperatorId = CurrentOperator.OperatorId;
                }

                errorMessage.Result = eventBll.SaveOrUpdate(model);
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

        [Authorized]
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
                var eventJoiners = eventJoinerBll.GetByEventId(eventId);
                foreach (var item in eventJoiners)
                {
                    item.Event.EventJoiners = null;
                }
                return Json(eventJoiners.ToList(), JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet]
        public ActionResult EditJoiner(int? eventjoinerId, int eventId)
        {
            var model = new EventJoiner();
            if (eventjoinerId.HasValue && eventjoinerId.Value > 0)
            {
                model = new EventJoinerBll().GetById(eventjoinerId.Value);
            }
            else
            {
                model.EventId = eventId;
            }

            return PartialView("_EditJoiner", model);
        }

        [HttpPost]
        public ActionResult EditJoiner(EventJoiner model)
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
