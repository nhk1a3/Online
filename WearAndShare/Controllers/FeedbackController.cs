using WearAndShare.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WearAndShare.Controllers
{
    public class FeedbackController : Controller
    {
        menfashionEntities db = new menfashionEntities();
        public FeedbackController()
        {
           
        }
        // GET: Feedback
        public ActionResult Index()
        {
            if (Session["info"] == null)
                return RedirectToAction("Index", "Home");

            var currentUser = Session["info"] as Member;

            if (currentUser == null)
                return RedirectToAction("Index", "Home");

            var model = db.Feedbacks
                .Where(x => x.FromUserName == currentUser.userName || x.ToUserName == currentUser.userName)
                .OrderByDescending(x => x.SendDate)
                .ToList();

            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            var model = new Feedback();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Feedback model)
        {
            if (Session["info"] == null)
                return RedirectToAction("Index", "Home");
            
            var currentUser = Session["info"] as Member;
            
            if (currentUser == null)
                return RedirectToAction("Index", "Home");

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
            model.ToUserName = "";
            model.SendDate = DateTime.Now;

            db.Feedbacks.Add(model);

            try
            {
                db.SaveChanges();
            } 
            catch(Exception ex)
            { 
                ModelState.AddModelError("", ex.Message);
                return View(model);
            } 

            return RedirectToAction("Index", "Feedback");
        }
    }
}