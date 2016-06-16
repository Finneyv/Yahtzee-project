using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using VicWebsite.Models;

namespace VicWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact(ContactModel model)
        {
            try
            {
                MailMessage message = new MailMessage();
                message.Body = model.Message;
                message.Subject = "Message from " + model.Name + " Email: " + model.Email;
                message.To.Add("Papercut@user.com");
                if (model.WantCC)
                {
                    message.CC.Add(model.Email);
                }
                SmtpClient client = new SmtpClient();
                client.EnableSsl = false;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = true;

                client.Send(message);
            }
            catch(Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            return RedirectToAction("Index");
        }
    }
}