using System.IO;
using System;

namespace FileWatcherLibrary
{
    public class Manager
    {     
        public static DefaultOptions GetOptions()
        {
            DefaultOptions defOp = new DefaultOptions();
            AppDomain domain = AppDomain.CurrentDomain;

            string xmlPath = domain.BaseDirectory + "config.xml";
            string jsonPath = domain.BaseDirectory + "appsettings.json";
            int stop = 0;            

            if (File.Exists(xmlPath))
            {
                XmlParser x = new XmlParser(xmlPath);
                if (x.nodes is null)
                {
                    stop = 1;
                }
                else
                {                 
                    defOp = EtlXmlOptions.GetXmlOptions(x);
                }
            }
            else
            {
                stop = 1;
            }
            if (File.Exists(jsonPath) && stop == 1)
            {
                JsonParser j = new JsonParser(jsonPath);
                if (!(j.nodes is null))
                {
                    defOp = EtlJsonOptions.GetJsonOptions(j);
                }
            }
            return defOp;
        }
    }
}

