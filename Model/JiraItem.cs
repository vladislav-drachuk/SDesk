namespace Sdesk.Model
{
    public class JiraItem
    {
        public long Id   { get; set; }   //(our internal)
        public int JiraSourceId { get; set; }
        public long RequestIdType { get; set; }
        public long JiraNumber { get; set; } 

    }
}
