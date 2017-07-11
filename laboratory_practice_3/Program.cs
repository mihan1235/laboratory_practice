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

namespace laboratory__practice
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearcherList res_list = new ResearcherList();
            res_list.AddDefaults();
            Console.Write(res_list.ToString());
            print_average_time_frame(res_list);
            print_min_public_date(res_list);
            print_researcher_min_public_release(res_list);
            print_publication_name_string(res_list);
            print_res_one_author_not_year(res_list);
            print_res_same_authors_more_two_pub(res_list);
            print_sorted_project_with_one_year(res_list);
            print_sorted_project_with_num_long(res_list);
            print_proj_theme_with_diff_Time(res_list);
        }

        public static void print_average_time_frame(ResearcherList res_list)
        {
            Console.Write("Average Time Frame: {0}\n", res_list.AverageTimeFrame);
        }

        public static void print_min_public_date(ResearcherList res_list)
        {
            DateTime date = res_list.MinPublicDate;
            Console.Write("Minimum public release date with one author: {0}\n", date);
        }

        public static void print_researcher_min_public_release(ResearcherList res_list)
        {
            Researcher obj = res_list.ResearcherMinPublicDate;
            if (obj != null)
            {
                Console.Write("Researcher with minimum public release date with one author: \n{0}",
                    obj.ToString());
            }
            else
            {
                Console.Write("Researcher with minimum public release date with one author: null\n");
            }
        }

        public static void print_publication_name_string(ResearcherList res_list)
        {
            List<string> name_list = res_list.PublicationNameList;
            int i = 0;
            Console.Write("List of publication names, that doesn`t have " +
                "researchers, which have projects from this list and number " +
                "of author`s is more then one:\n");
            foreach (string name in name_list)
            {
                Console.Write("[{0}]: {1}\n", i, name);
                i++;
            }
        }

        public static void print_res_one_author_not_year(ResearcherList res_list)
        {
            IEnumerable<Researcher> res_list_IE = res_list.ResOneAuthorNotYear;
            Console.Write("IEnumerable <Researcher> which have publications " +
                "with one author and don`t have projects with timeframe year: \n");
            foreach (IEnumerable iter in res_list_IE)
            {
                Console.Write(iter.ToString());
            }
        }

        public static void print_res_same_authors_more_two_pub(ResearcherList res_list)
        {
            IEnumerable<Researcher> res_list_IE = res_list.ResSameAuthorsMoreTwoPub;
            Console.Write("IEnumerable <Researcher> which have more then two publications " +
                "with with the same number of authors: \n");
            foreach (IEnumerable iter in res_list_IE)
            {
                Console.Write(iter.ToString());
            }
        }

        public static void print_sorted_project_with_one_year(ResearcherList res_list)
        {
            IEnumerable<Researcher> res_list_IE = res_list.SortedProjectWithOneYear;
            Console.Write("IEnumerable <Researcher> sorted by number of projects " +
                "with time frame year: \n");
            foreach (IEnumerable iter in res_list_IE)
            {
                Console.Write(iter.ToString());
            }
        }

        public static void print_sorted_project_with_num_long(ResearcherList res_list)
        {
            var res_list_IE = res_list.SortedProjectWithNumLong;
            Console.Write("IEnumerable < IGrouping < int, Researcher >> group sorted by number of projects " +
                "with time frame long: \n");
            foreach (var iter_group in res_list_IE)
            {
                Console.Write("Num [{0}]: ", iter_group.Key);
                foreach (var iter_res in iter_group)
                {
                    Console.Write(iter_res.ToString());
                }
            }
        }

        public static void print_proj_theme_with_diff_Time(ResearcherList res_list)
        {
            var theme_list = res_list.ProjThemeWithDiffTimeFrame;
            Console.WriteLine("ienumerable<string> projet`s theme list, which have " +
                "diffrent timeframe: \n");
            foreach (var iter in theme_list)
            {
                Console.WriteLine(iter.ToString());
            }
        }
    }
}
