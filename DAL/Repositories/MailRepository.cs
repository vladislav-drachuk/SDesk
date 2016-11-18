
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DAL.EntityFramework;
using DAL.Interfaces;
using Sdesk.Model;

namespace DAL.Repositories
{
    public class MailRepository: IRepository<Mail>
    {
       private readonly ApplicationContext _context;
        private readonly DbSet<Mail> _mails;


        public MailRepository(ApplicationContext context)
        {
            _context = context;
            _mails = _context.Mails;
        }

        public IEnumerable<Mail> GetAll()
        {
            return _mails;
        }


        public Mail GetSingle(int id)
        {
            return _mails.FirstOrDefault(o => o.Id == id);
        }


        public IEnumerable<Mail> FindBy(Expression<Func<Mail, bool>> predicate)
        {
            return _mails.Where(predicate);
        }

        public void Create(Mail mail)
        {
            _mails.Add(mail);
        }

        public void Delete(int id)
        {
            var mail = _mails.Find(id);
            if (mail != null)
            {
                _mails.Remove(mail);
            }
        }

        public void Update(Mail mail)
        {
            _context.Entry(mail).State = EntityState.Modified;
        }
 
   
    }
}
