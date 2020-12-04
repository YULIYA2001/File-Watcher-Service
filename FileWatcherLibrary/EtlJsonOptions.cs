using System;

namespace FileWatcherLibrary
{
    public static class EtlJsonOptions
    {
        public static DefaultOptions GetJsonOptions(JsonParser jp)
        {
            DefaultOptions defOp = new DefaultOptions();

            defOp.sourceDirectoryPath = jp.TakeVariableValue("sourceDirectoryPath");
            defOp.targetDirectoryPath = jp.TakeVariableValue("targetDirectoryPath");
            defOp.targetArchivePath = jp.TakeVariableValue("targetArchivePath");
            try
            {
                int key = Convert.ToInt32(jp.TakeVariableValue("key"));
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
