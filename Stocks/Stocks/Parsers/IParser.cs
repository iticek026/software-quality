﻿using Stocks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Parsers
{
    public interface IParser
    {
        public Task<IEnumerable<StockModel>> GetStocksAsync(string filePath);
    }
}
