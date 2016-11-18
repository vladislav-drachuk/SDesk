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
    public class MailsController2 : ApiController
    {

        private readonly IRepository<Mail> _mailRepository;
        private readonly IRepository<Attachment> _attachmentRepository;

        public MailsController2()
        {
            var uof = new UnitOfWork("SDeskConnection");
            _mailRepository = uof.MailRepository;
            _attachmentRepository = uof.AttachmentRepository;
        }


        public IEnumerable<Mail> GetAllMails()
        {
            var mails = _mailRepository.GetAll();
            return mails;
        }


        public Mail GetMail(int id)
        {
            var mail = _mailRepository.GetSingle(id);
            return mail;
        }


        public void PostMail(Mail mail)
        {
            _mailRepository.Create(mail);
        }


        public void PutMail(int id, Mail mail)
        {
            //later
        }


        public void DeleteMail(int id)
        {
            _mailRepository.Delete(id);
        }

        [Route("{id:int:min(1)}/attachments")]
        public IEnumerable<Attachment> GetAttachments(int id, string extention = null, int status = 0)
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
            return attachments;
        }


        [Route("{id:int:min(1)}/attachments/{attId:int:min(1)}")]
        public Attachment GetAttachment(int id, int attId)
        {
            var attachment = _attachmentRepository.FindBy(a => a.MailId == id && a.Id == attId).FirstOrDefault(); ;
            return attachment;
        }


        [HttpPost]
        [Route("{id:int:min(1)}/attachments")]
        public void CreateAttachment(int id, Attachment attachment)
        {
            _attachmentRepository.Create(attachment);
        }
        [HttpPut]
        [Route("{id:int:min(1)}/attachments/{attId:int:min(1)}")]
        public void EditAttachment(int id, int attId, Attachment mail)
        {
            //later
        }
        [HttpDelete]
        [Route("{id:int:min(1)}/attachments/{attId:int:min(1)}")]
        public void RemoveAttachment(int id, int attId)
        {
            _attachmentRepository.Delete(attId);
        }
    }
}
