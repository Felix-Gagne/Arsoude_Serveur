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

    public class HikeNotFoundException : Exception
    {
        public HikeNotFoundException() : base("No Hike was found.") { }
    }

    public class UserNotFoundException : Exception
    {
        public UserNotFoundException() : base("No user was found.") { }
    }

    public class CoordinateNotFoundException : Exception
    {
        public CoordinateNotFoundException() : base("No coordinate was found.") { }
    }


}
