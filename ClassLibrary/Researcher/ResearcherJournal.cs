using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace laboratory_practice_4
{
    public class ResearcherJournal
    {
        FileStream fs = null;
        StreamWriter streamWriter;
        public ResearcherJournal(string journal_file)
        {
            try
            {
                fs=new FileStream(journal_file, FileMode.OpenOrCreate);
                streamWriter = new StreamWriter(fs);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Couldn't initialize file: \n" + ex.Message);
            }
        }

        public void ContainsResearcherEvent(object source, ResearcherHandlerEventArgs args)
        {
            Console.WriteLine("Got event\n");
            Console.WriteLine(source.ToString());
            Console.WriteLine(args.ToString());
            try
            {
                streamWriter.WriteLine(source.ToString());
                streamWriter.WriteLine(args.ToString());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Dispose()
        {
            if (fs != null)
            {
                Console.WriteLine("Dispose\n");
                streamWriter.Close();
                fs.Close();
            }
            
        }
    }
}
