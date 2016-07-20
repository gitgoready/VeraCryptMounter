using System;

namespace VeraCrypt_Mounter
{
    /// <summary>
    /// Exception if drivletter is used
    /// </summary>
    public class DrivletterUsedException : Exception
    {
        public DrivletterUsedException()
        {

        }

        public DrivletterUsedException(string message) : base (message)
        {

        }
        public DrivletterUsedException(string message, Exception inner) : base (message, inner)
        {

        }
    }
}
