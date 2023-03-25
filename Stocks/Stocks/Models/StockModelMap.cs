﻿using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stocks.Models
{
    public class StockModelMap: ClassMap<StockModel>
    {
        public StockModelMap()
        {
            Map(m => m.Date).Name("date");
            Map(m => m.Company).Name("company");
            Map(m => m.Ticker).Name("ticker");
            Map(m => m.Shares).Name("shares").Convert(args =>
            {
                return int.Parse(args.Row.GetField("shares").Replace(",", ""));
            });
            Map(m => m.MarketValue).Name("market value ($)");
        }
    }
}
