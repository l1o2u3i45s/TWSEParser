using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TWSEParser.Model
{
    internal class StockRawData
    {

        public int TradeVolumn { get; set; } //成交股數

        public double OpenPrice { get; set; } //開盤價

        public double MaxPrice { get; set; } //最高價
        public double MinPrice { get; set; } //最低價
        public double ClosePrice { get; set; } //收盤價

        //MA
        public double MA5 { get; set; }
        public double MA10 { get; set; }
        public double MA20 { get; set; }
        public double MA60 { get; set; }

        public double MACDSignal { get; set; }
    }
}
