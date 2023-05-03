using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Services.Exceptions
{
    /// <summary>
    /// Class <c>SmtpConnectionException</c> represents the exception that is thrown when the specified SMTP server parameters are invalid.
    /// </summary>
    public class SmtpConnectionException: Exception
    {
        /// <summary>
        /// Initializes a new instance of <see cref="SmtpConnectionException"/>.
        /// </summary>
        public SmtpConnectionException() : base(
            ExceptionStrings.GetExceptionMessage(CustomException.SmtpConnectionException))
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SmtpConnectionException"/>.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public SmtpConnectionException(string message) : base(
            message)
        {
        }

        /// <summary>
        /// Initializes a new instance of <see cref="SmtpConnectionException"/>.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        /// <param name="innerException">The exception that is the cause of the current exception.</param>
        public SmtpConnectionException(Exception innerException) : base(
            ExceptionStrings.GetExceptionMessage(CustomException.SmtpConnectionException),
            innerException)
        {
        }
    }
}
