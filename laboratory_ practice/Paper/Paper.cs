using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory__practice.Papers
{
    public class Paper
    {
        public string PublicationName { get; set; }
        public int PublicationAuthorAmount { get; set; }
        public Paper( string publication_name="unknown_publication_name"
              ,int author_amount=0)
        {
            PublicationAuthorAmount = author_amount;
            PublicationName = publication_name;
        }

        public override string ToString()
        {
            return "Paper \"" + PublicationName +
                    "\" published by " + PublicationAuthorAmount +
                    " athors \n";
        }
    }
}
