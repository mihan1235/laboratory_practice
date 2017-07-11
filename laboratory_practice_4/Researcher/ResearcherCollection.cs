using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laboratory__practice.Researchers;
using laboratory__practice_2.Project;
using laboratory__practice.Papers;
using laboratory_practice_3;
using static laboratory_practice_4.Rand;

namespace laboratory_practice_4
{
    delegate void ResearcherHandler(object source, ResearcherHandlerEventArgs args);
    
    class ResearcherCollection
    {
        public event ResearcherHandler ResearcherEvent;
        Dictionary<string, Researcher> res_table = new Dictionary<string, Researcher>();
        public void AddResearchers(params Researcher[] res_list)
        {
            for (int i = 0; i < res_list.Count(); i++)
            {
                res_table.Add(res_list[i].Key,res_list[i]);
            }
        }

        public Dictionary<string, Researcher> ResTable
        {
            get
            {
                return res_table;
            }
        }
        public void AddDefaultResearchers(int n)
        {
            //Researcher[] res_arr = new Researcher[n];
            for (int i = 0; i < n; i++)
            {
                Researcher r1 = new Researcher("name_"+i.ToString(), "surname_" + i.ToString());
                //r1.AddPapers(new Paper("a" + i.ToString(), i));
                //r1.AddPapers(new Paper("b" + i.ToString(), i));
                //r1.AddPapers(new Paper("c" + i.ToString(), i));
                //r1.AddProjects(new Project("p" + i.ToString(), i, TimeFrame.Long));
                //r1.AddProjects(new Project("p" + i.ToString(), i, TimeFrame.Long));
                //res_arr[i] = r1;
                AddResearchers(r1);
            }
            //AddResearchers(res_arr);           
        }
        public bool ContainsResearcher(string Key)
        {
            int time = Environment.TickCount;
            bool is_found = res_table.ContainsKey(Key);
            time = Environment.TickCount - time;
            //double time_d = time * 0.001;
            throw_event(Key,time,SearchMethod.ByKey,is_found);
            return is_found;
        }
        public bool ContainsResearcher(Researcher st)
        {
            int time = Environment.TickCount;
            bool is_found = res_table.ContainsValue(st);
            time = Environment.TickCount - time;
            //double time_d = time * 0.001;
            throw_event(time, SearchMethod.ByValue, is_found);
            return is_found;
        }

        void throw_event(string Key, double time, SearchMethod SearchMethod, bool is_found)
        {
            if (ResearcherEvent != null)
            {
                ResearcherHandlerEventArgs args = new ResearcherHandlerEventArgs();
                args.Key = Key;
                args.time = time;
                args.SearchMethod = SearchMethod;
                args.is_found = is_found;
                ResearcherEvent("Researcher event",args);
            }
        }

        void throw_event(double time, SearchMethod SearchMethod, bool is_found)
        {
            if (ResearcherEvent != null)
            {
                ResearcherHandlerEventArgs args = new ResearcherHandlerEventArgs();
                args.Key = null;
                args.time = time;
                args.SearchMethod = SearchMethod;
                args.is_found = is_found;
                ResearcherEvent("Researcher event", args);
            }
        }

    }
}
