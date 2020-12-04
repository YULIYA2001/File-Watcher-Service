using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace FileWatcherLibrary
{
    public class JsonParser
    {        
        // словарь хранит пары имя - значение
        public Dictionary<string, string> nodes = new Dictionary<string, string>();

        public JsonParser(string jsonPath)
        {
            try
            {
                JsonDocument jDoc = JsonDocument.Parse(File.ReadAllText(jsonPath));
                nodes = new Dictionary<string, string>();

                foreach (JsonProperty node in jDoc.RootElement.EnumerateObject())
                {
                    nodes.Add(node.Name, node.Value.ToString());
                }
                //foreach (KeyValuePair<string, string> keyValue in nodes)
                //{
                //    Console.WriteLine(keyValue.Key + " : " + keyValue.Value);
                //}
            }
            catch
            {
                nodes = null;
            }
                
        }           
       
        public string TakeVariableValue(string name)
        {
            string variableValue = nodes[name];
            return variableValue;
        }
    }
}
