using System;
using laboratory__practice.Researchers;
using laboratory__practice.Papers;
using System.Collections;
using laboratory__practice.Persons;
using laboratory__practice_2.Project;
using System.Collections.Generic;
using laboratory__practice_2.Interfaces;

namespace laboratory__practice
{
    class Program
    {
        static void Main(string[] args)
        {
			Researcher a=new Researcher();
			a.AddPapers (get_test_paper_arr ());
			a.AddProjects (get_test_project_arr ());
			Console.WriteLine (a.ToString ());
			project_one_partner(a);
			papers_before_2005(a);
			test_DeepCopy (a);
			print_person_list (a);
			print_list_cout (a);
        }

		static public void print_person_list(Researcher a){
			Console.WriteLine ("Print person list:");
			List<Person> persons_list = new List<Person> ();
			persons_list.Add (a.DeepCopy() as Researcher);
			persons_list.Add (a.DeepCopy() as Researcher);
			Person b = new Person ();
			persons_list.Add (b);
			for (int i = 0; i < persons_list.Count; i++) {
				Console.Write (persons_list [i].ToShortString()+'\n');
			}

		}

		static public void print_list_cout(Researcher a){
			Console.WriteLine ("Print objects in list with ITeamCount:");
			List<ITeamCount> list = new List<ITeamCount> ();
			list.Add (a.DeepCopy() as Researcher);
			list.Add (new Researcher("Mark"));
			list.Add (new Person ("honney"));
			list.Add (new Project ("homework"));
			list.Add (new Researcher("dfMark"));
			list.Add (new Person ("hofnney"));
			list.Add (new Project ("hofddmework"));
			for (int i = 0; i < list.Count; i++) {
				Console.WriteLine (list [i].Count);
			}
		}

		static public void test_DeepCopy(Researcher a){
			Researcher a_clone = a.DeepCopy () as Researcher;
			a_clone.ProjectsList [0].Theme = "my homework";
			a_clone.PapersList [0].PublicationName = "how to help";
			Console.WriteLine ("test of DeepCopy:\n");
			Console.WriteLine ("original object:");
			Console.WriteLine (a.ToString ());
			Console.WriteLine ("copied object: ");
			Console.WriteLine (a_clone.ToString ());
		}

		static public Project[] get_test_project_arr(){
			Project[] proj_arr = new Project[12];
			char c = 'a';
			for (int i = 0; i < proj_arr.Length-2; i++)
			{
				proj_arr[i] = new Project("dsfds"+c, 1,TimeFrame.Long);
				c++;
			}
			proj_arr[10] = new Project("dffz",2, TimeFrame.Long);
			proj_arr[11] = new Project();
			return proj_arr;
		}


		static public Paper[] get_test_paper_arr(){
			Paper[] paper_arr = new Paper[11];
			char c = 'a';
			for (int i = 0; i < paper_arr.Length; i++)
			{
				paper_arr[i] = new Paper("dsfds"+c, i,new DateTime(2000+i,i+1,i+1));
				c++;
			}
			return paper_arr;
		}

		static public void  project_one_partner(Researcher a,int num=1){
			for (int i = 0; i < num; i++) {
				Console.Write ("Projects with one partner:\n");
				foreach (Project projj in a) {
					Console.Write (' '+projj.ToString ());
				}
			}
		}

		static public void papers_before_2005(Researcher a,int num=1){
			for (int i = 0; i < num; i++) {
				Console.Write ("Paper published befor 2005 year:\n");
				foreach (Paper papers in a.PaperEnumerator(2005)) {
					Console.Write (' '+papers.ToString ());
				}
			}
		}
    }
}
