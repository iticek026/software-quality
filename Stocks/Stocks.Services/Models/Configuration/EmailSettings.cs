﻿namespace Stocks.Services.Models.Configuration
{
    /// <summary>
    /// Class <c>EmailSettings</c> represents the settings for sending emails.
    /// </summary>
    public class EmailSettings
    {
        public string Sender { get; set; }
        public List<string> Recepients { get; set; } = new List<string>();
        public string SubjectTemplate { get; set; }
    }
}