
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sdesk.Model;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
       
        IRepository<Attachment> AttachmentRepository { get; }
        IRepository<Mail> MailRepository { get; }
        IRepository<JiraItem> JiraItemRepository { get; }

        void Save();

    }
}
