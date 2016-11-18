using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

using DAL.EntityFramework;
using DAL.Interfaces;
using Sdesk.Model;


namespace DAL.Repositories
{
    public class AttachmentRepository: IRepository<Attachment>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Attachment> _attachments;


        public AttachmentRepository(ApplicationContext context)
        {
            _context = context;
            _attachments = _context.Attachments;
        }

        public IEnumerable<Attachment> GetAll()
        {
            return _attachments;
        }


        public Attachment GetSingle(int id)
        {
            return _attachments.FirstOrDefault(o => o.Id == id);
        }


        public IEnumerable<Attachment> FindBy(Expression<Func<Attachment, bool>> predicate)
        {
            return _attachments.Where(predicate);
        }

        public void Create(Attachment attachment)
        {
            _attachments.Add(attachment);
        }

        public void Delete(int id)
        {
            var attachment = _attachments.Find(id);
            if (attachment != null)
            {
                _attachments.Remove(attachment);
            }
        }

        public void Update(Attachment attachment)
        {
            _context.Entry(attachment).State = EntityState.Modified;
        }
    }
}