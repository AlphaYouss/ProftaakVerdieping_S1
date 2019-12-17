using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace Galgje
{
    class FileReader
    {
        public List<string> Words { get; private set; } = new List<string>();

        
        public FileReader()
        {
            LoadTextFile();
        }

       
        
        
        public void LoadTextFile()
        {
            using (StreamReader streamReader = new StreamReader(@"Assets\HangmanWords.txt"))
            {
                while (streamReader.Peek() > 0)
                {
                    string line = streamReader.ReadLine();
                    Words.Add(line);
                }
            }
        }
    }
}
