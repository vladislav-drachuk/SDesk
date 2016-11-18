using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using DAL.Interfaces;
using DAL.Repositories;
using Sdesk.Model;

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

        [Route("{id:int}/attachments")]
        public IEnumerable<Attachment> GetAttachments(int id, string extention = null, int status = 0)
        {
            var attachments = _attachmentRepository.FindBy(a => a.MailId == id );
            if (!String.IsNullOrEmpty(extention))
            {
                attachments = attachments.Where(a => a.FileExtention.ToLower() == extention.ToLower());
            }
            if (status != 0)
            {
                attachments = attachments.Where(a => a.StatusId == status);
            }
            return attachments;
        }


        [Route("{id:int}/attachments/{attId:int}")]
        public Attachment GetAttachment(int id, int attId)
        {
            var attachment = _attachmentRepository.FindBy(a => a.MailId == id && a.Id== attId).FirstOrDefault(); ;
            return attachment;
        }


        [HttpPost]
        [Route("{id:int}/attachments")]
        public void CreateAttachment(int id, Attachment attachment)
        {
            _attachmentRepository.Create(attachment);
        }
        [HttpPut]
        [Route("{id:int}/attachments/{attId:int}")]
        public void EditAttachment(int id, int attId, Attachment mail)
        {
            //later
        }
        [HttpDelete]
        [Route("{id:int}/attachments/{attId:int}")]
        public void RemoveAttachment(int id, int attId)
        {
            _attachmentRepository.Delete(attId);
        }
    }
}
