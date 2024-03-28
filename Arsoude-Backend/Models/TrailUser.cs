using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arsoude_Backend.Models
{
    public class TrailUser
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int TrailId { get; set; }

        public double VoteValue { get; set; }
    }
}
