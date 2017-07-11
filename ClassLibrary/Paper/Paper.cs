using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laboratory__practice_2.Interfaces;

namespace laboratory__practice.Papers
{
    [Serializable]
    public class Paper: IDeepCopy, ITeamCount
    {
        public string PublicationName { get; set; }
        public int PublicationAuthorAmount { get; set; }
        public DateTime PublicRelease { get; set; }

        public Paper(string publication_name = "unknown_publication_name", int author_amount = 0,
            DateTime dateTime = new DateTime())
        {
            PublicationName = publication_name;
            PublicationAuthorAmount = author_amount;
            PublicRelease = dateTime;

        }

        public override string ToString()
        {
            return "Paper \"" + PublicationName +
                    "\" published by " + PublicationAuthorAmount +
                    " athors on "+ PublicRelease.ToString()+"\n";
        }

        public object DeepCopy()
        {
            Paper obj = new Paper();
            obj.PublicationAuthorAmount = PublicationAuthorAmount;
            obj.PublicationName = PublicationName;
            obj.PublicRelease = PublicRelease;
            return obj;
        }

        public int Count { get; }
    }
}
