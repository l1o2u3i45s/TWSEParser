using Newtonsoft.Json;
using TWSEParser.Model;
using TWSEParser.Service;


string code = "006208";
DataParser dataParser = new DataParser();
DataProcessor dataProcessor = new DataProcessor();
var rawDataList = await dataParser.GetStockPrice(code);
dataProcessor.ProcessData(rawDataList);

var result = rawDataList.Select<StockPriceDTO, StockRawData>(_ => _);

string output = JsonConvert.SerializeObject(result);

using (StreamWriter writer = new StreamWriter(code + ".json"))
{
    writer.WriteLine(output);
}
