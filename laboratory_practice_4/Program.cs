using System;
using laboratory__practice.Researchers;
using laboratory__practice.Papers;
using System.Collections;
using laboratory__practice.Persons;
using laboratory__practice_2.Project;
using System.Collections.Generic;
using laboratory__practice_2.Interfaces;
using laboratory_practice_3;
using System.Linq;
using laboratory_practice_4;

namespace laboratory__practice
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearcherCollection res_coll = new ResearcherCollection();
            res_coll.AddDefaultResearchers(100000);
            ResearcherJournal res_event_journal = new ResearcherJournal("n.log");
            res_coll.ResearcherEvent += res_event_journal.ContainsResearcherEvent;
            res_coll.ContainsResearcher("name_1000000 surname_1000000");
            res_coll.ContainsResearcher("name_1 surname_1");
            res_coll.ContainsResearcher(make_researcher(4));
            Researcher res1 = res_coll.ResTable["name_1 surname_1"];
            res_coll.ContainsResearcher(res1);
            res_event_journal.Dispose();
        }

        public static Researcher make_researcher(int i)
        {
            Researcher r1 = new Researcher("name_" + i.ToString(), "surname_" + i.ToString());
            r1.AddPapers(new Paper("a" + i.ToString(), i));
            r1.AddPapers(new Paper("b" + i.ToString(), i));
            r1.AddPapers(new Paper("c" + i.ToString(), i));
            r1.AddProjects(new Project("p" + i.ToString(), i, TimeFrame.Long));
            r1.AddProjects(new Project("p" + i.ToString(), i, TimeFrame.Long));
            return r1;
        }
    }
}
