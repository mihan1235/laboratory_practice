using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory_practice_4
{
    enum SearchMethod
    {
        ByKey,
        ByValue
    }

    class ResearcherHandlerEventArgs: EventArgs
    {
        public string Key { get; set; }
        public double time { get; set; }
        public SearchMethod SearchMethod { get; set; }
        public bool is_found { get; set; }
        public override string ToString()
        {
            string output = "Event args: \n";
            output = output + base.ToString();
            if (Key != null)
            {
                output = output + " with Key: ";
                output = output + Key;
            }
            output = output + "\n";
            output = output + " Time needed to find element: ";
            output = output + time+ "\n";
            if (SearchMethod==SearchMethod.ByKey)
            {
                output = output + " Search method: by key\n";
            }
            else
            {
                output = output + " Search method: by value\n";
            }
            if (is_found)
            {
                output = output + " Search process is successfull\n";
            }
            else
            {
                output = output + " Search process is not successfull\n";
            }
            return output;
        }
    }
}
