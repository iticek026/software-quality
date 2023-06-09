﻿using Microsoft.Extensions.Configuration;

namespace Stocks.Services.Models.Configuration
{
    /// <summary>
    /// Class <c>Settings</c> represents the settings for the application from the appsettings.json file.
    /// </summary>
    public class Settings
    {
        public string SaveDirectory { get; set; }
        public string FileNameFormat { get; set; }
        public string FileExtension { get; set; }
        public string CsvUrl { get; set; }
        public string UserAgent { get; set; }
        public SmtpCredentials Smtp { get; set; } = new();
        public EmailSettings Email { get; set; } = new();

        public static Settings Get(IConfiguration configuration)
        {
            return configuration.GetRequiredSection("Settings").Get<Settings>();
        }
    }
}