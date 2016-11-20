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
    public class MailsV2Controller : ApiController
    {

        private readonly IRepository<Mail> _mailRepository;
        private readonly IRepository<Attachment> _attachmentRepository;

        public MailsV2Controller()
        {
            var uof = new UnitOfWork("SDeskConnection");
            _mailRepository = uof.MailRepository;
            _attachmentRepository = uof.AttachmentRepository;
        }

        [VersionedRoute("api/mails", 2)]
        public HttpResponseMessage GetAllMails()
        {
            var mails = _mailRepository.GetAll();
            if (mails != null && mails.Count() != 0)
            {
                return Request.CreateResponse<IEnumerable<Mail>>(HttpStatusCode.OK, mails);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

        }

        [VersionedRoute("api/mails/{id}", 2)]
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

        [VersionedRoute("api/mails", 2)]
        public HttpResponseMessage PostMail(Mail mail)
        {
            _mailRepository.Create(mail);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

        [VersionedRoute("api/mails/{id}", 2)]
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

        [VersionedRoute("api/mails/{id}", 2)]
        public HttpResponseMessage DeleteMail(int id)
        {
            _mailRepository.Delete(id);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
  
        [VersionedRoute("api/mails/{id}/attachments",2)]
        public HttpResponseMessage GetAttachments(int id, string extention = null, int status = 0)
        {
            var attachments = _attachmentRepository.FindBy(a => a.MailId == id);
            if (!String.IsNullOrEmpty(extention))
            {
                attachments = attachments.Where(a => a.FileExtention.ToLower() == extention.ToLower());
            }
            if (status != 0)
            {
                attachments = attachments.Where(a => a.StatusId == status);
            }
            if (attachments != null && attachments.Count() != 0)
            {
                return Request.CreateResponse<IEnumerable<Attachment>>(HttpStatusCode.OK, attachments);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }


          [VersionedRoute("api/mails/{id}/attachments/{attId}",2)]
           public HttpResponseMessage GetAttachment(int id, int attId)
           {
               var attachment = _attachmentRepository.FindBy(a => a.MailId == id && a.Id == attId).FirstOrDefault(); ;
            if (attachment != null)
            {
                return Request.CreateResponse<Attachment>(HttpStatusCode.OK, attachment);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }


         [HttpPost]
           [VersionedRoute("api/mails/{id}/attachments",2)]
           public HttpResponseMessage CreateAttachment(int id, Attachment attachment)
           {
               _attachmentRepository.Create(attachment);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }

           [HttpPut]
           [VersionedRoute("api/mails/{id}/attachments/{attId}",2)]
           public HttpResponseMessage EditAttachment(int id, int attId, Attachment attachment)
           {
            if (attachment == null && attId != attachment.Id && id !=attachment.MailId)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            else
            {
                var oldAttachment = _attachmentRepository.GetSingle(attId);
                if (oldAttachment == null)
                {
                    return new HttpResponseMessage(HttpStatusCode.MethodNotAllowed);
                }
                _attachmentRepository.Delete(attId);
                _attachmentRepository.Create(attachment);
                return new HttpResponseMessage(HttpStatusCode.Accepted);
            }

        }

        [HttpDelete]
           [VersionedRoute("api/mails/{id}/attachments/{attId}",2)]
           public HttpResponseMessage RemoveAttachment(int id, int attId)
           {
            _attachmentRepository.Delete(attId);

            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }
    }
}
