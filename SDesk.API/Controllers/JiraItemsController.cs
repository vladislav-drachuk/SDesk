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
    public class JiraItemsController : ApiController
    {
        private readonly IRepository<JiraItem> _jiraItemRepository;

        public JiraItemsController()
        {
            var uof = new UnitOfWork("SDeskConnection");
            _jiraItemRepository = uof.JiraItemRepository;
        }

        [ActionName("GetById")]
        public HttpResponseMessage GetJiraItems(int id)
        {
            var jiraItem = _jiraItemRepository.GetSingle(id);
            if (jiraItem != null)
            {
                return Request.CreateResponse<JiraItem>(HttpStatusCode.OK, jiraItem);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

     //   [Route("api/jiraitems/{id:jiraid}")]
        [ActionName("GetByString")]
        public HttpResponseMessage GetJiraItems(string id)
        {
            var intId = Int32.Parse(id.Substring(5)); 
            var jiraItem = _jiraItemRepository.GetSingle(intId);
            if (jiraItem != null)
            {
                return Request.CreateResponse<JiraItem>(HttpStatusCode.OK, jiraItem);
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

        }

    }
}
