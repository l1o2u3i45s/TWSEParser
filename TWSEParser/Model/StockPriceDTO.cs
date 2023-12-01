using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSEParser.Service;

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
            TradeVolumn = ParseInt(data[1]);
            TradeMoney = ParseDouble(data[2]);
            OpenPrice = ParseDouble(data[3]);
            MaxPrice = ParseDouble(data[4]);
            MinPrice = ParseDouble(data[5]);

            ClosePrice = ParseDouble(data[6]);
            Spread = data[7];
            TradeCount = ParseInt(data[8]);
        }

        private int ParseInt(string input)
        {
            if (Int32.TryParse(input.Replace(",", ""), out int result))
            {
                return result;
            }
            else
            {
                // 记录错误或采取其他措施
                IsValid = false;
                return 0; // 或者返回一个默认值
            }
        }

        private double ParseDouble(string input)
        {
            if (Double.TryParse(input.Replace(",", ""), out double result))
            {
                return result;
            }
            else
            {
                IsValid = false;
                return 0; // 或者返回一个默认值
            }
        }

        public bool IsValid { get; set; } = true;
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
