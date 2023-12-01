using TWSEParser.Service;

DataParser dataParser = new DataParser();
DataProcessor dataProcessor = new DataProcessor();
var rawDataList = await dataParser.GetStockPrice("006208");
dataProcessor.ProcessData(rawDataList);
Console.WriteLine("aaa");
