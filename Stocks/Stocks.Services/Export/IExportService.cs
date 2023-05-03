using Stocks.Services.Exceptions;

namespace Stocks.Services.Export
{
    /// <summary>
    /// Interface <c>IExportService</c> defines the contract for the service that exports content.
    /// </summary>
    public interface IExportService
    {
        /// <summary>
        /// Exports the content.
        /// </summary>
        /// <param name="content">The content to be exported.</param>
        /// <returns>Task.</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Task Export(string content);
    }
}