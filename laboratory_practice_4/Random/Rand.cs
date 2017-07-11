using System;
using laboratory__practice_2;
using System.Collections;
using System.Collections.Generic;
using laboratory__practice;
using laboratory__practice.Researchers;
using laboratory__practice.Papers;
using laboratory__practice_2.Project;

namespace laboratory_practice_4
{
    static public class Rand
    {
        static Random rnd = new Random();
        public static int generate_rnd_int(int a,int b)
        {
            return rnd.Next(a, b);
        }

        public static char generate_rnd_char()
        {
            return (char)rnd.Next(0x0061, 0x007A);
        }

        public static string generate_rnd_string(int length = 6)
        {
            string name = "";
            for (int i = 0; i < length; i++)
            {
                name = name + generate_rnd_char();
            }
            return name;
        }

        public static bool generate_rnd_bool()
        {
            int res = rnd.Next(0, 2);
            if (res == 1)
            {
                return true;
            }
            return false;
        }

        public static TimeFrame generate_rnd_TimeFrame()
        {
            return (TimeFrame)rnd.Next(0, 3);
        }

        public static void generate_date(ref int day, ref int month, ref int year)
        {
            day = rnd.Next(1, 20);//To avoid a mistake with dates in february
            month = rnd.Next(1, 12);
            year = rnd.Next(1545, 2010);
        }

        public static Paper[] generate_papers(int size)
        {
            int day = 0;
            int month = 0;
            int year = 0;
            Paper[] paper_list = new Paper[size];
            for (int j = 0; j < size; j++)
            {
                generate_date(ref day, ref month, ref year);
                paper_list[j] = new Paper(generate_rnd_string() + ' ' +
                    generate_rnd_string(), rnd.Next(1, 12), new DateTime(year, month, day));
            }
            return paper_list;
        }

        public static Project[] generate_projects(int size)
        {
            Project[] project_list = new Project[size];
            for (int m = 0; m < size; m++)
            {
                project_list[m] = new Project(generate_rnd_string() + ' ' +
                    generate_rnd_string(), rnd.Next(1, 58), generate_rnd_TimeFrame());
            }
            return project_list;
        }
    }
}
