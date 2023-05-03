using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Services.Exceptions
{
    /// <summary>
    /// Class <c>SmtpAuthenticationException</c> represents the exception that is thrown when the specified SMTP credentials are invalid.
    /// </summary>
    public class SmtpAuthenticationException: Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SmtpAuthenticationException"/>.
        /// </summary>
        public SmtpAuthenticationException() : base(
            ExceptionStrings.GetExceptionMessage(CustomException.SmtpAuthenticationException))
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SmtpAuthenticationException"/>.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SmtpAuthenticationException(string message) : base(
            message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SmtpAuthenticationException"/>.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public SmtpAuthenticationException(Exception innerException) : base(
            ExceptionStrings.GetExceptionMessage(CustomException.SmtpAuthenticationException),
            innerException)
        {
        }
    }
}
