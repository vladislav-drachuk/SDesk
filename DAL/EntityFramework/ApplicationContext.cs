
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using DAL.Configuration;
using Sdesk.Model;


namespace DAL.EntityFramework
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Attachment> Attachments { get; set; }

        public DbSet<JiraItem> JiraItems { get; set; }
       

        static ApplicationContext()
        {
         
            Database.SetInitializer<ApplicationContext>(new SDeskDbConfiguration());
        }

        public ApplicationContext(string conectionString) : base(conectionString) { }

     
        
    }
}
