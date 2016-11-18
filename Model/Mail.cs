using System;
using System.Collections.Generic;


namespace Sdesk.Model
{
    public class Mail
    {
        public long Id { get; set; }
        public string Subject { get; set; }
        public string Sender { get; set; }
        public string To { get; set; }
        public string Cc { get; set; }
        public string Body { get; set; }


        public ICollection<int> AttachementIds { get; set; } 
        
        public Priority Priority { get; set; } //enum
        public DateTime Received { get; set; } //date when we received email
        public DateTime Saved { get; set; } //date when we saved mail entity

    }
}
