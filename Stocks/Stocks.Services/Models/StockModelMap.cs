﻿using CsvHelper.Configuration;

namespace Stocks.Services.Models
{
    public class StockModelMap : ClassMap<StockModel>
    {
        public StockModelMap()
        {
            Map(m => m.Company).Name("company");
            Map(m => m.Ticker).Name("ticker");
            Map(m => m.Shares).Name("shares").Convert(args =>
            {
                return int.Parse(args.Row.GetField("shares").Replace(",", ""));
            });
            Map(m => m.Weight).Name("weight (%)");
            Map(m => m.Cusip).Name("cusip");
        }
    }
}