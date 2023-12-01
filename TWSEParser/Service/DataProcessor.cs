using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TWSEParser.Model;

namespace TWSEParser.Service
{
    internal class DataProcessor
    {

        public void ProcessData(List<StockPriceDTO> prices)
        {
            for (int i = 0; i < prices.Count; i++)
            {
                prices[i].MA5 = i >= 4 ? prices.Skip(i - 4).Take(5).Average(p => p.ClosePrice) : 0;
                prices[i].MA10 = i >= 9 ? prices.Skip(i - 9).Take(10).Average(p => p.ClosePrice) : 0;
                prices[i].MA20 = i >= 19 ? prices.Skip(i - 19).Take(20).Average(p => p.ClosePrice) : 0;
                prices[i].MA60 = i >= 59 ? prices.Skip(i - 59).Take(60).Average(p => p.ClosePrice) : 0;

                double ema12 = CalculateEMA(prices, i, 12);
                double ema26 = CalculateEMA(prices, i, 26);

                prices[i].MACD = ema12 - ema26;
            }

            // 接下来，计算信号线（MACD的9天EMA）
            for (int i = 0; i < prices.Count; i++)
            {
                prices[i].MACDSignal = CalculateEMA(prices.Select(p => p.MACD).ToList(), i, 9);
            }
        }
       
        private static double CalculateEMA(List<StockPriceDTO> prices, int currentDay, int period)
        {
            double multiplier = 2.0 / (period + 1);
            double ema = prices[currentDay].ClosePrice;

            for (int i = currentDay - 1, days = 1; i >= 0 && days < period; i--, days++)
            {
                ema = (prices[i].ClosePrice - ema) * multiplier + ema;
            }

            return ema;
        }

        private static double CalculateEMA(List<double> values, int currentDay, int period)
        {
            if (currentDay >= period - 1)
            {
                return values.Skip(currentDay - period + 1).Take(period).Average();
            }
            return 0;
        }
    }
}
