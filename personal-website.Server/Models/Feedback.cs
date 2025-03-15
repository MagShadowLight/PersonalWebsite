namespace personal_website.Server.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string FeedbackName { get; set; }
        public string Email { get; set; }
        public string FeedbackComment { get; set; }
        public bool NeededResponse { get; set; }
        public bool IsResolved { get; set; }
    }
}
