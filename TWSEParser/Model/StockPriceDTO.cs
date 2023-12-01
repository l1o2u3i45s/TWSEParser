using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSEParser.Model
{
    internal class StockPriceDTO
    {

        public StockPriceDTO(string id,string[] data)
        {
            ID = id;

            if (data.Length != 9)
                throw new NotImplementedException("StockPriceDTO data error!");

            Date = Convert.ToDateTime(data[0]).AddYears(1911);
            TradeVolumn = Convert.ToInt32(data[1].Replace(",",""));
            TradeMoney = Convert.ToDouble(data[2].Replace(",", ""));
            OpenPrice = Convert.ToDouble(data[3].Replace(",", ""));
            MaxPrice = Convert.ToDouble(data[4].Replace(",", ""));
            MinPrice = Convert.ToDouble(data[5].Replace(",", ""));
            ClosePrice = Convert.ToDouble(data[6].Replace(",", ""));
            Spread = data[7];
            TradeCount = Convert.ToInt32(data[8].Replace(",", ""));
        }
        public string ID { get; set; }

        public DateTime Date { get; set; } //日期
        public int TradeVolumn { get; set; } //成交股數

        public double TradeMoney { get; set; } //成交金額

        public double OpenPrice { get; set; } //開盤價

        public double MaxPrice { get; set; } //最高價
        public double MinPrice { get; set; } //最低價
        public double ClosePrice { get; set; } //收盤價

        public string Spread { get; set; } //漲跌價差

        public int TradeCount { get; set; } //成交筆數

        //MA
        public double MA5 { get; set; }
        public double MA10 { get; set; }
        public double MA20 { get; set; }
        public double MA60 { get; set; }
        public double MACD { get; set; }

        public double MACDSignal {get; set; }
    }
}
