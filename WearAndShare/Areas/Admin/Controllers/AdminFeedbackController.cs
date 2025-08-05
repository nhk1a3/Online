using WearAndShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;

namespace WearAndShare.Areas.Admin.Controllers
{
    [Authorize]
    public class AdminFeedbackController : Controller
    {
        // GET: Admin/Feedback
        menfashionEntities db = new menfashionEntities();
        public AdminFeedbackController()
        {

        }
        // GET: Feedback
        public ActionResult Index()
        {
            if (Session["infoAdmin"] == null)
                return RedirectToAction("Index", "Dashboard");

            var currentUser = Session["infoAdmin"] as Member;

            if (currentUser == null)
                return RedirectToAction("Index", "Dashboard");

            var model = db.Feedbacks
                .Where(x => x.ToUserName == null || x.ToUserName == ""
                || x.FromUserName == currentUser.userName)
                .OrderByDescending(x => x.SendDate)
                .ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Reply(int id)
        {
            var model = db.Feedbacks
                .Where(x => x.Id == id)
                .FirstOrDefault();
            
            if (model == null)
                return RedirectToAction("Index", "AdminFeedback", new { Area = "Admin" });
            
            return View(new Feedback()
            {
                ToUserName = model.FromUserName
            });
        }

        [HttpPost]
        public ActionResult Reply(int id, Feedback model)
        {
            if (Session["infoAdmin"] == null)
                return RedirectToAction("Index", "Dashboard");

            var currentUser = Session["infoAdmin"] as Member;

            if (currentUser == null)
                return RedirectToAction("Index", "Dashboard");

            var currentFeedback = db.Feedbacks
                .Where(x => x.Id == id)
                .FirstOrDefault();
            
            if (currentUser == null)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            if (string.IsNullOrEmpty(model.ToUserName))
            {
                ModelState.AddModelError(nameof(model.ToUserName), "Không tìm thấy thông tin người nhận !");
                return View(model);
            }

            if (string.IsNullOrEmpty(model.Title))
            {
                ModelState.AddModelError(nameof(model.Title), "Tiêu đề không được để trống !");
                return View(model);
            }

            if (string.IsNullOrEmpty(model.Message))
            {
                ModelState.AddModelError(nameof(model.Message), "Nội dung phản hồi không được để trống !");
                return View(model);
            }

            model.FromUserName = currentUser.userName;
            model.ToUserName = currentFeedback.FromUserName;
            model.SendDate = DateTime.Now;
            model.Ref = currentFeedback.Id;

            db.Feedbacks.Add(model);

            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }

            return RedirectToAction("Index", "AdminFeedback");
        }
    }
}