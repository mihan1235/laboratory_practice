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

namespace SerializeReseacherList
{
    class Program
    {
        static void Main(string[] args)
        {
            //test_new_deep_copy();
            serialize_researcher_list();
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

        public static void test_new_deep_copy()
        {
            Researcher r1 = make_researcher(3);
            Researcher r2 = r1.DeepCopy();
            Console.WriteLine("////////////Testing deep copy//////////////////");
            Console.WriteLine("Original researcher: ");
            Console.Write(r1);
            Console.WriteLine("///////////////////////////////////////////////");
            Console.WriteLine("Clonned researcher: ");
            Console.Write(r2);
            Console.WriteLine("///////////////////////////////////////////////");
            r1.PapersList.Clear();
            Console.WriteLine("///////////////after cnhanging r1//////////////");
            Console.WriteLine("Original researcher: ");
            Console.Write(r1);
            Console.WriteLine("///////////////////////////////////////////////");
            Console.WriteLine("Clonned researcher: ");
            Console.Write(r2);
            Console.WriteLine("///////////////////////////////////////////////");
        }

        public static void serialize_researcher_list()
        {
            ResearcherList res_coll = new ResearcherList();
            res_coll.AddDefaults();
            Console.WriteLine("////////////Researcher List//////////////////");
            Console.Write(res_coll);
            string file_name=read_filename();
            if (ResearcherList.Save(file_name, res_coll))
            {
                Console.WriteLine("Succsessfuly serialized ResearcherList");
            }
        }

        static string read_filename()
        {
            Console.Write("Enter filename, where serialize researcher_list: ");
            string str = Console.ReadLine();
            str = "..\\..\\..\\" + str;
            return str;
        }

    }
}
