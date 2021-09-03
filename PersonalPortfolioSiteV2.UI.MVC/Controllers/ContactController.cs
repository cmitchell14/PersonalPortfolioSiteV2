using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PersonalPortfolioSiteV2.UI.MVC.Models;
using System.Net.Mail;  //ADDING FOR ACCESS TO MailMessage
using System.Configuration; //Added (with intellisense) for access to ConfigurationManager.
using System.Net;  //Added (with intellisense) for access to ConfigurationManager. For Network Credentials

namespace PersonalPortfolioSiteV2.UI.MVC.Controllers
{
    public class ContactController : Controller
    {
        //GET for Contact
        public ActionResult Contact()
        {
            return View();
        }

        //POST for Contact
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Contact(ContactViewModel cvm)
        {
            if (ModelState.IsValid)
            {

                string message = $"You have received an email from {cvm.Name}<br/>Subject: " +
                                $"{cvm.Subject}.  Please respond to {cvm.Email} with your response to the following message:" +
                                $"<br/>{cvm.Body}";

                MailMessage mailMessage = new MailMessage(


                    ConfigurationManager.AppSettings["EmailUser"].ToString(),

                    ConfigurationManager.AppSettings["EmailTo"].ToString(),

                    cvm.Subject,

                    cvm.Body

                    );

                mailMessage.IsBodyHtml = true;

                mailMessage.Priority = MailPriority.High;

                mailMessage.ReplyToList.Add(cvm.Email);

                //STMP CLIENT, CREDENTIALS, EXCEPTION
                SmtpClient client = new SmtpClient(ConfigurationManager.AppSettings["EmailClient"].ToString());

                client.Credentials = new NetworkCredential(ConfigurationManager.AppSettings["EmailUser"].ToString(), ConfigurationManager.AppSettings["EmailPass"].ToString());

                try
                {
                    client.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    ViewBag.CustomerMessage = $"We're sorry, but your request could not be completed at this time.  Please try again later. " +
                         $"Error Message: <br/> {ex.StackTrace}";

                    return View(cvm);
                }

                return View("EmailConfirmation", cvm);
            }
            return View(cvm);
        }

        public ActionResult EmailConfirmation()
        {
            return View();
        }

    }
}