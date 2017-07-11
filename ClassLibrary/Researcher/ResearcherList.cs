using System;
using laboratory__practice_2;
using System.Collections;
using System.Collections.Generic;
using laboratory__practice;
using laboratory__practice.Researchers;
using laboratory__practice.Papers;
using laboratory__practice_2.Project;
using System.Linq;
using laboratory_practice_4;
using static laboratory_practice_4.Rand;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace laboratory_practice_3
{
    [Serializable]
    public class ResearcherList
	{
        List<Researcher> researchers_list=new List<Researcher>();

		public override string ToString(){
			string output = "List of researchers: \n";
			int i = 0;
			while (i < researchers_list.Count) {
				output = output + researchers_list [i].ToString ()+"\n";
				i++;
			}
			return output;
		}

        void random_generate()
        {
            int day = 0;
            int month = 0;
            int year = 0;
            int researcher_size = 5;
            int arr_size = researcher_size;
            Paper[] paper_arr = generate_papers(arr_size);
            Project[] project_arr = generate_projects(arr_size);
            int tmp;
            for (int i = 0; i < researcher_size; i++)
            {
                generate_date(ref day, ref month, ref year);
                bool academic_degree = generate_rnd_bool();
                Researcher tmp_obj = new Researcher(generate_rnd_string(), generate_rnd_string(),
                                        day, month, year, academic_degree);
                for (int j = 0; j < arr_size - 1; j++)
                {
                    generate_date(ref day, ref month, ref year);
                    tmp_obj.AddPapers(new Paper(generate_rnd_string(), generate_rnd_int(1, 12),
                        new DateTime(year, month, day)));
                    tmp_obj.AddProjects(new Project(generate_rnd_string(), generate_rnd_int(1, 58),
                        generate_rnd_TimeFrame()));
                }
                tmp_obj.AddPapers(paper_arr[generate_rnd_int(0, arr_size - 1)]);
                tmp = generate_rnd_int(0, arr_size - 1);
                project_arr[tmp].TimeFrame = generate_rnd_TimeFrame();
                tmp_obj.AddProjects(project_arr[tmp]);
                researchers_list.Add(tmp_obj);
            }
        }

		public void AddDefaults () {
            Researcher r1 = new Researcher("1_res ", "1");
            r1.AddPapers(new Paper("a_1", 2));
            r1.AddProjects(new Project("p1", 3, TimeFrame.Long));
            r1.AddProjects(new Project("p2", 3, TimeFrame.Long));
            Researcher r2 = new Researcher("2_res ", "2");
            r2.AddPapers(new Paper("a_2", 2));
            r2.AddProjects(new Project("p2", 3, TimeFrame.Year));
            r2.AddProjects(new Project("p2", 3, TimeFrame.Long));
            Researcher r3 = new Researcher("3_res ", "1");
            r3.AddPapers(new Paper("a_3", 2));
            r3.AddProjects(new Project("p3", 3, TimeFrame.Year));
            r3.AddProjects(new Project("p3", 3, TimeFrame.Long));
            researchers_list.Add(r1);
            researchers_list.Add(r2);
            researchers_list.Add(r3);
        }

		public double AverageTimeFrame
		{
			get{
				var LINQ_long_project_list = (from Researcher res in researchers_list
											  orderby res descending
				                              from Project proj in res.ProjectsList
				                              where proj.TimeFrame == TimeFrame.Long
				                              select proj).Distinct ();
				var LINQ_all_project_list = (from Researcher res in researchers_list
				                             from Project proj in res.ProjectsList
				                             select proj).Distinct ();
				List<Project> long_project_list = LINQ_long_project_list.ToList ();
				List<Project> all_project_list = LINQ_all_project_list.ToList ();
				return (double)long_project_list.Count/all_project_list.Count;
			}
		}

		public DateTime MinPublicDate{
			get{
				var date_times = from Researcher res in researchers_list
				                 from Paper paper in res.PapersList
				                 where paper.PublicationAuthorAmount == 1
				                 select paper.PublicRelease;
				if (date_times.Count()==0) {
					return new DateTime ();
				}
				DateTime date_time = date_times.Max ();
				return date_time;
			}
		}

		public Researcher ResearcherMinPublicDate{
			get{
				DateTime date_time = MinPublicDate;
				var res_arr = from Researcher res in researchers_list
				              from Paper paper in res.PapersList
				              where paper.PublicationAuthorAmount == 1
				              where paper.PublicRelease == date_time
				              select res;
				if (res_arr.Count()==0) {
					return null;
				}
				return (Researcher) res_arr.ToList()[0].DeepCopy();
			}
		}

		public List<string> PublicationNameList{
			get{
				var res_arr_author_less_1 = (from Researcher res in researchers_list
				                             from Paper paper in res.PapersList
				                             where paper.PublicationAuthorAmount <= 1
				                             select paper.PublicationName).Distinct ().ToList ();
				return res_arr_author_less_1;
			}
		}

        public IEnumerable<Researcher> ResSameAuthorsMoreTwoPub
        {
            get
            {
                var res_arr_author_less_1 = (from Researcher res in researchers_list
                                             from Paper paper in res.PapersList
                                             from Paper paper1 in res.PapersList
                                             where paper.PublicationAuthorAmount == paper1.PublicationAuthorAmount
                                             && paper != paper1
                                             select res).Distinct();
                return res_arr_author_less_1;
            }
        }

        public IEnumerable<Researcher> ResOneAuthorNotYear{
			get{
                var res_one_author_1 = from Researcher res in researchers_list
                                       from Paper paper in res.PapersList
                                       where paper.PublicationAuthorAmount == 1
                                       select res;
                var res_proj_not_year = from Researcher res in researchers_list
                                        from Project proj in res.ProjectsList
                                        where proj.TimeFrame != TimeFrame.Year
                                        select res;
				return res_one_author_1.Except(res_proj_not_year);
			}
		}

        public IEnumerable<Researcher> SortedProjectWithOneYear
        {
            get
            {
                return from Researcher res in researchers_list
                       orderby (from Project proj in res.ProjectsList
                                where proj.TimeFrame == TimeFrame.Year
                                select proj).Count()
                       select res;
            }
        }

        public IEnumerable<IGrouping<int, Researcher>> SortedProjectWithNumLong
        {
            get
            {
                return from Researcher res in researchers_list
                       group res by (from Project proj in res.ProjectsList
                                     where proj.TimeFrame == TimeFrame.Long
                                     select proj).Count() into gr_count
                       select gr_count;
            }
        }

        public IEnumerable<string> ProjThemeWithDiffTimeFrame
        {
            get
            {
                var list_theme = from res in researchers_list
                                 from proj in res.ProjectsList
                                 group proj by proj.Theme;
                var proj_gr = (from gr in list_theme
                              from proj1 in gr
                              from proj2 in gr
                              where proj1.TimeFrame != proj2.TimeFrame
                              select proj1.Theme).Distinct();                 
                return proj_gr;
            }
        }

        public static bool Save(string filename, ResearcherList obj)
        {
            FileStream file_stream = null;
            try
            {
                file_stream = File.Create(filename);
                BinaryFormatter binary_formatter = new BinaryFormatter();
                binary_formatter.Serialize(file_stream, obj);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
            finally
            {
                if (file_stream != null) file_stream.Close();
            }
            return true;
        }

        public static bool Load(string filename, ref ResearcherList obj)
        {
            FileStream file_stream = null;
            try
            {
                file_stream = File.OpenRead(filename);
                BinaryFormatter binary_formatter = new BinaryFormatter();
                obj = binary_formatter.Deserialize(file_stream) as ResearcherList;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }
            finally
            {
                if (file_stream != null) file_stream.Close();
            }
            return true;
        }
    }
}

