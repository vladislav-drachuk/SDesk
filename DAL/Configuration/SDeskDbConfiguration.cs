using System;
using System.Collections.Generic;
using System.Data.Entity;
using DAL.EntityFramework;
using Sdesk.Model;

namespace DAL.Configuration
{
    public class SDeskDbConfiguration : DropCreateDatabaseIfModelChanges<ApplicationContext>
    {
        protected override void Seed(ApplicationContext db)
        {
            var attachment1 = new Attachment
            {
                Id = 1,
                MailId = 1,
                FileExtention = "pdf",
                FileName = "Pdf attachment",
                Path = "somepath",
                StatusId = 1
            

            };

            var attachment2 = new Attachment
            {
                Id = 2,
                MailId = 1,
                FileExtention = "txt",
                FileName = "Txt attachment",
                Path = "somepath",
                StatusId = 1


            };

            var attachment3 = new Attachment
            {
                Id = 3,
                MailId = 2,
                FileExtention = "pdf",
                FileName = "Pdf attachment",
                Path = "somepath",
                StatusId = 1


            };

            var attachment4 = new Attachment
            {
                Id = 4,
                MailId = 3,
                FileExtention = "pdf",
                FileName = "Pdf attachment",
                Path = "somepath",
                StatusId = 1


            };

            var attachment5 = new Attachment
            {
                Id = 5,
                MailId = 3,
                FileExtention = "txt",
                FileName = "Txt attachment",
                Path = "somepath",
                StatusId = 1


            };

            var attachment6 = new Attachment
            {
                Id = 6,
                MailId = 3,
                FileExtention = "jpg",
                FileName = "Jpg attachment",
                Path = "somepath",
                StatusId = 1


            };
            var attachment7 = new Attachment
            {
                Id = 7,
                MailId = 4,
                FileExtention = "Jpg",
                FileName = "Jpg attachment",
                Path = "somepath",
                StatusId = 1


            };


            var mail1 = new Mail
            {
                Id = 1,
                AttachementIds = new List<int>(new []{1,2}),
                Body = "1st mail",
                Priority = Priority.Medium,
                Cc = "mail",
                Sender = "Anonym",
                Subject = "Work",
                Received = DateTime.Now,
                Saved = DateTime.Now
               
            };

            var mail2 = new Mail
            {
                Id = 2,
                AttachementIds = new List<int>(new[] { 3 }),
                Body = "2nd mail",
                Priority = Priority.Medium,
                Cc = "mail",
                Sender = "Anonym",
                Subject = "Spam",
                Received = DateTime.Now,
                Saved = DateTime.Now
            };

            var mail3 = new Mail
            {
                Id = 3,
                AttachementIds = new List<int>(new[] { 4,5,6 }),
                Body = "3rd mail",
                Priority = Priority.Medium,
                Cc = "mail",
                Sender = "Anonym",
                Subject = "",
                Received = DateTime.Now,
                Saved = DateTime.Now
            };

            var mail4 = new Mail
            {
                Id = 2,
                AttachementIds = new List<int>(new[] { 7 }),
                Body = "4th mail",
                Priority = Priority.Medium,
                Cc = "mail",
                Sender = "Anonym",
                Subject = "Help",
                Received = DateTime.Now,
                Saved = DateTime.Now
            };

            var jira1 = new JiraItem
            {
                Id = 1,
                JiraNumber = 1,
                JiraSourceId = 1,
            };

            var jira2 = new JiraItem
            {
                Id = 2,
                JiraNumber = 2,
                JiraSourceId = 2,
            };

            var jira3 = new JiraItem
            {
                Id = 3,
                JiraNumber = 3,
                JiraSourceId = 3,
            };

            var jira4 = new JiraItem
            {
                Id = 4,
                JiraNumber = 4,
                JiraSourceId = 4,
            };

            db.Attachments.Add(attachment1);
            db.Attachments.Add(attachment2);
            db.Attachments.Add(attachment3);
            db.Attachments.Add(attachment4);
            db.Attachments.Add(attachment5);
            db.Attachments.Add(attachment6);
            db.Attachments.Add(attachment7);

            db.Mails.Add(mail1);
            db.Mails.Add(mail2);
            db.Mails.Add(mail3);
            db.Mails.Add(mail4);

            db.JiraItems.Add(jira1);
            db.JiraItems.Add(jira2);
            db.JiraItems.Add(jira3);
            db.JiraItems.Add(jira4);
        }
    }
}