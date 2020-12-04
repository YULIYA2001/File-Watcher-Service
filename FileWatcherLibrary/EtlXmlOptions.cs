using System;
using System.Collections.Generic;
using System.Text;

namespace FileWatcherLibrary
{
    public static class EtlXmlOptions
    {
        public static DefaultOptions GetXmlOptions(XmlParser xp)
        {
            DefaultOptions defOp = new DefaultOptions();

            defOp.sourceDirectoryPath = xp.TakeVariableValue("sourceDirectoryPath");
            defOp.targetDirectoryPath = xp.TakeVariableValue("targetDirectoryPath");
            defOp.targetArchivePath = xp.TakeVariableValue("targetArchivePath");
            try
            {
                int key = Convert.ToInt32(xp.TakeVariableValue("key"));
                if (key > 0 && key < 146)
                {
                    defOp.key = key;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return defOp;
        }
    }
}
