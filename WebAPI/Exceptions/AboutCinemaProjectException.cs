using System.Runtime.Serialization;

namespace WebAPI.Exceptions;

[Serializable]
public class AboutCinemaProjectException : Exception
{
    private static readonly string DefaultMessage = "AboutCinemaProject exception was thrown.";

    public AboutCinemaProjectException() : base(DefaultMessage)
    {
    }

    public AboutCinemaProjectException(string message) : base(message)
    {
    }

    public AboutCinemaProjectException(string message, Exception innerException)
        : base(message, innerException)
    {
    }

    protected AboutCinemaProjectException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}