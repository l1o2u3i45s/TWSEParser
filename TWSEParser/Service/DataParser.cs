using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using TWSEParser.Model;

namespace TWSEParser.Service
{
    internal class DataParser
    {

        public async Task GetStockPrice(string code)
        {
            try
            {
                int startYear = 2018;
                DateTime startDate = new DateTime(startYear, 1, 1);

                List<StockPriceDTO> result = new List<StockPriceDTO>();
                while (startDate < DateTime.Today)
                {
                    string requestUrl =
                        $"https://www.twse.com.tw/rwd/zh/afterTrading/STOCK_DAY?date={startDate:yyyyMMdd}&stockNo={code}&response=json";

                    string response = await HttpGET(requestUrl);
                    var jsonData = JsonConvert.DeserializeObject<JObject>(response);
                    var rawDataList = jsonData["data"];

                    foreach (var item in rawDataList)
                    {
                        var dataArr = JsonConvert.DeserializeObject<string[]>(item.ToString());
                        StockPriceDTO dto = new StockPriceDTO(code, dataArr);
                        result.Add(dto);
                    }

                    await Task.Delay(500);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }


        private async Task<string > HttpGET(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync(request);
                    response.EnsureSuccessStatusCode();
                    string responseBody = await response.Content.ReadAsStringAsync();

                    return responseBody;
                }
                catch (HttpRequestException e)
                {
                    Console.WriteLine("\nException Caught!");
                    Console.WriteLine("Message :{0} ", e.Message);
                }
            }

            return string.Empty;
        }
    }
}
