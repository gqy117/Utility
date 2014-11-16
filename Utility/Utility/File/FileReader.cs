namespace Utility
{
    using System.IO;

    public class FileReader
    {
        public string ReadString(string fileName)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return sr.ReadToEnd();
            }
        }
    }
}
