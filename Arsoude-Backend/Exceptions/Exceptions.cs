namespace Arsoude_Backend.Exceptions
{
    public class NotOwnerExcpetion : Exception
    {
        public NotOwnerExcpetion() : base("No owner was found.") { }
    }

    public class TrailNotFoundException : Exception
    {
        public TrailNotFoundException() : base("No trail was found.") { }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("No user was found.") { }
    }


}
