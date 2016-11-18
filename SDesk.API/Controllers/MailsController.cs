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
    public class MailsController : ApiController
    {

        private readonly IRepository<Mail> _mailRepository;

        public MailsController()
        {
            var uof = new UnitOfWork("SDeskConnection");
            _mailRepository = uof.MailRepository;
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
    }
}
