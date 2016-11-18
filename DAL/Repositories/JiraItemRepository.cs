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
    public class JiraItemRepository: IRepository<JiraItem>
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<JiraItem> _jiraItems;


        public JiraItemRepository(ApplicationContext context)
        {
            _context = context;
            _jiraItems = _context.JiraItems;
        }

        public IEnumerable<JiraItem> GetAll()
        {
            return _jiraItems;
        }


        public JiraItem GetSingle(int id)
        {
            return _jiraItems.FirstOrDefault(o => o.Id == id);
        }


        public IEnumerable<JiraItem> FindBy(Expression<Func<JiraItem, bool>> predicate)
        {
            return _jiraItems.Where(predicate);
        }

        public void Create(JiraItem jiraItem)
        {
            _jiraItems.Add(jiraItem);
        }

        public void Delete(int id)
        {
            var jiraItem = _jiraItems.Find(id);
            if (jiraItem != null)
            {
                _jiraItems.Remove(jiraItem);
            }
        }

        public void Update(JiraItem jiraItem)
        {
            _context.Entry(jiraItem).State = EntityState.Modified;
        }
    }
}