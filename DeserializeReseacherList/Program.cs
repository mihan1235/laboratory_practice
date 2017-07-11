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

namespace DeserializeReseacherList
{
    class Program
    {
        static void Main(string[] args)
        {
            deserialize_researcher_list();
        }

        public static void deserialize_researcher_list()
        {
            ResearcherList res_coll = new ResearcherList();
            string file_name = read_filename();
            if (ResearcherList.Load(file_name, ref res_coll))
            {
                Console.WriteLine("Succsessfuly loaded researcher_list");
                Console.WriteLine("////////////Researcher List after serialization//////////////////");
                Console.Write(res_coll);
            }
        }

        static string read_filename()
        {
            Console.Write("Enter filename, where serialized researcher_list is contained: ");
            string str = Console.ReadLine();
            str = "..\\..\\..\\" + str;
            return str;
        }
    }
}
