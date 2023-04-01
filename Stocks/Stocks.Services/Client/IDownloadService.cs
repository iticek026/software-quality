﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Services.Client
{
    public interface IDownloadService
    {
        public Task<string?> DownloadFile(string path);
    }
}