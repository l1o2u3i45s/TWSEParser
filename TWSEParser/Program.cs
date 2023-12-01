using Newtonsoft.Json;
using TWSEParser.Service;


string code = "006208";
DataParser dataParser = new DataParser();
DataProcessor dataProcessor = new DataProcessor();
var rawDataList = await dataParser.GetStockPrice(code);
dataProcessor.ProcessData(rawDataList);

string output = JsonConvert.SerializeObject(rawDataList);

using (StreamWriter writer = new StreamWriter(code + ".json"))
{
    writer.WriteLine(output);
}
