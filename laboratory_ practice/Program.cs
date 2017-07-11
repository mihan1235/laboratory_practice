using System;
using laboratory__practice.Researchers;
using laboratory__practice.Papers;
using System.Collections;


namespace laboratory__practice
{
    class Program
    {
        static void Main(string[] args)
        {

            Researcher a = new Researcher("boris", "dfgov", 23, 04, 1934, false);
            Console.WriteLine(a.ToShortString());
            Paper[] paper_list = new Paper[5];
            for (int i = 0; i < paper_list.Length; i++)
            {
                paper_list[i] = new Paper("how to tell", 23);
            }
            a.AddPapers(paper_list);
            Console.WriteLine(a.ToString());
            int nrow, ncolumn;
            read_size(out nrow, out ncolumn);
            compare_time_1D(nrow, ncolumn);
            compare_time_2D(nrow, ncolumn);
            compare_time_2D_jagged(nrow, ncolumn);
            compare_time_array_list(nrow, ncolumn);
        }


        static void compare_time_1D(int nrow, int ncolumn)
        {
            ///Compare time of operation of one-dimensional array
            Paper[] paper_list_1 = new Paper[nrow * ncolumn];
            Paper b = new Paper();
            int time = Environment.TickCount;
            for (int i = 0; i < paper_list_1.Length; i++)
            {
                paper_list_1[i] = b;
            }
            time = Environment.TickCount - time;
            double time_d = time * 0.001;
            Console.WriteLine("sec time of operation of one-dimensional array: {0}", time_d);
            time = Environment.TickCount;
            for (int i = 0; i < paper_list_1.Length; i++)
            {
                paper_list_1[i].PublicationAuthorAmount = 5;
            }
            time = Environment.TickCount - time;
            time_d = time * 0.001;
            Console.WriteLine("sec time of operation of one-dimensional array: {0}", time_d);
            //////////////////////////////////////////////////////
        }

        static void read_size(out int nrow, out int ncolumn)
        {
            Console.Write("Введите число строк и столбцов в массиве в виде \"[nrow] [ncolumn]\": ");
            string size_arr_str = Console.ReadLine();
            string[] token_arr = size_arr_str.Split(' ');
            nrow = Convert.ToInt32(token_arr[0]);
            ncolumn = Convert.ToInt32(token_arr[1]);
            Console.WriteLine("{0} {1}", nrow, ncolumn);
        }

        static void compare_time_2D(int nrow, int ncolumn)
        {
            ///Compare time of operation of two-dimensional array
            Paper[,] paper_list_2 = new Paper[nrow, ncolumn];
            Paper b = new Paper();
            int time = Environment.TickCount;
            for (int t = 0; t < nrow; t++)
            {
                for (int i = 0; i < ncolumn; i++)
                {
                    paper_list_2[t, i] = b;
                }
            }
            time = Environment.TickCount - time;
            double time_d = time * 0.001;
            Console.WriteLine("sec time of operation of two-dimensional array: {0}", time_d);
            time = Environment.TickCount;
            for (int t = 0; t < nrow; t++)
            {
                for (int i = 0; i < ncolumn; i++)
                {
                    paper_list_2[t, i].PublicationAuthorAmount = 5;
                }
            }
            time = Environment.TickCount - time;
            time_d = time * 0.001;
            Console.WriteLine("sec time of operation of two-dimensional array: {0}", time_d);
            //////////////////////////////////////////////////////
        }

        static void compare_time_2D_jagged(int nrow, int ncolumn)
        {
            Paper[][] paper_list_3 = new Paper[nrow][];
            Paper b = new Paper();
            for (int t = 0; t < nrow; t++)
            {
                paper_list_3[t] = new Paper[ncolumn];
            }
            int time = Environment.TickCount;
            for (int t = 0; t < nrow; t++)
            {
                for (int i = 0; i < ncolumn; i++)
                {
                    paper_list_3[t][i] = b;
                }
            }
            time = Environment.TickCount - time;
            double time_d = time * 0.001;
            Console.WriteLine("sec time of operation of two-dimensional jagged array: {0}", time_d);
            time = Environment.TickCount;
            for (int t = 0; t < nrow; t++)
            {
                for (int i = 0; i < ncolumn; i++)
                {
                    paper_list_3[t][i].PublicationAuthorAmount = 5;
                }
            }
            time = Environment.TickCount - time;
            time_d = time * 0.001;
            Console.WriteLine("sec time of operation of two-dimensional jagged array: {0}", time_d);
        }

        static void compare_time_array_list(int nrow, int ncolumn)
        {
            ArrayList papers = new ArrayList(nrow * ncolumn);
            Paper b = new Paper();
            for (int t = 0; t < nrow * ncolumn; t++)
            {
                papers.Add(b);
            }
            int time = Environment.TickCount;
            for (int t = 0; t < papers.Count; t++)
            {
                ((Paper)papers[t]).PublicationAuthorAmount = 5;
            }
            time = Environment.TickCount - time;
            double time_d = time * 0.001;
            Console.WriteLine("sec time of operation of ArrayList array: {0}", time_d);

        }
    }
}
