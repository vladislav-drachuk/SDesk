using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Interfaces;
using DAL.Repositories;
using Sdesk.Model;
using SDesk.API.Util;

namespace SDesk.API.Controllers
{
   [VersionedRoute("api/mails/{id?}", 1)]
    public class MailsController : ApiController
    {

        private readonly IRepository<Mail> _mailRepository;

        public MailsController()
        {
            var uof = new UnitOfWork("SDeskConnection");
            _mailRepository = uof.MailRepository;
        }


        public HttpResponseMessage GetAllMails()
        {
            /*
             var mails = _mailRepository.GetAll();
             if (mails != null && mails.Count() != 0)
             {

                return Request.CreateResponse<IEnumerable<Mail>>(HttpStatusCode.OK, mails);
             }
             else
             {
                 return new HttpResponseMessage(HttpStatusCode.NotFound);
             }
             */
            throw new NotImplementedException();
        }


        public HttpResponseMessage GetMail(int id)
        {
            var mail = _mailRepository.GetSingle(id);
            if (mail != null)
            {
                return Request.CreateResponse<Mail>(HttpStatusCode.OK, mail);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }


        public HttpResponseMessage PostMail(Mail mail)
        {
            _mailRepository.Create(mail);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }


        public HttpResponseMessage PutMail(int id, Mail mail)
        {
            if (mail == null && id != mail.Id)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                var oldMail = _mailRepository.GetSingle(id);
                if (oldMail == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
                }
                _mailRepository.Delete(id);
                _mailRepository.Create(mail);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }
            
        }


        public HttpResponseMessage DeleteMail(int id)
        {
            _mailRepository.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
