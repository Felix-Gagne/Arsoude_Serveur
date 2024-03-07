namespace Arsoude_Backend.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Date { get; set; }
        public bool userHasCompleted { get; set; }
        public string Username { get; set; }
        public virtual User User { get; set; }
        public virtual Trail Trail { get; set; }
    }
}
