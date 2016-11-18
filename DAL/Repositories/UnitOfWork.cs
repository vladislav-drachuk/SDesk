
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DAL.EntityFramework;
using DAL.Interfaces;
using Sdesk.Model;


namespace DAL.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly ApplicationContext _dataBase;

        private readonly IRepository<Mail> _mailRepository;
        private readonly IRepository<Attachment> _attachmentRepository;

        private readonly IRepository<JiraItem> _jiraItemRepository;


        //DI here later
        public UnitOfWork(string connectionString)
        {
            _dataBase = new ApplicationContext(connectionString);

            _mailRepository = new MailRepository(_dataBase);
            _attachmentRepository = new AttachmentRepository(_dataBase);
            _jiraItemRepository = new JiraItemRepository(_dataBase);
        }



        public IRepository<Mail> MailRepository
        {
            get { return _mailRepository; }
        }

        
        public IRepository<Attachment> AttachmentRepository
        {
            get { return _attachmentRepository; }
        }

        public IRepository<JiraItem> JiraItemRepository
        {
            get { return _jiraItemRepository; }
        }


        public void Save()
        {
            _dataBase.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _dataBase.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
