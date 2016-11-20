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
   
    [RoutePrefix("api/mails")]
    public class AttachmentsController : ApiController
    {
        private readonly IRepository<Attachment> _attachmentRepository;

        public AttachmentsController()
        {
            var uof = new UnitOfWork("SDeskConnection");
            _attachmentRepository = uof.AttachmentRepository;
        }

        [VersionedRoute("{id:int}/attachments",1)]
        public HttpResponseMessage GetAttachments(int id, string extention = null, int status = 0)
        {

            /*
            var attachments = _attachmentRepository.FindBy(a => a.MailId == id );
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
            */
            throw new NotImplementedException();
        }


        [VersionedRoute("{id:int}/attachments/{attId:int}",1)]
        public HttpResponseMessage GetAttachment(int id, int attId)
        {
            var attachment = _attachmentRepository.FindBy(a => a.MailId == id && a.Id== attId).FirstOrDefault();
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
        [VersionedRoute("{id:int}/attachments",1)]
        public HttpResponseMessage CreateAttachment(int id, Attachment attachment)
        {
            _attachmentRepository.Create(attachment);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }


        [HttpPut]
        [VersionedRoute("{id:int}/attachments/{attId:int}",1)]
        public HttpResponseMessage EditAttachment(int id, int attId, Attachment attachment)
        {
            if (attachment == null && attId != attachment.Id && id != attachment.MailId)
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
        [VersionedRoute("{id:int}/attachments/{attId:int}",1)]
        public HttpResponseMessage RemoveAttachment(int id, int attId)
        {
            _attachmentRepository.Delete(attId);
            return new HttpResponseMessage(HttpStatusCode.Accepted);
        }

    }
}
