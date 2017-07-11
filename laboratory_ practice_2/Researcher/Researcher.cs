using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using laboratory__practice.Persons;
using laboratory__practice.Papers;
using laboratory__practice_2.Project;
using System.Collections;

namespace laboratory__practice.Researchers
{
    
    public class Researcher: Person, IEnumerable
    {
        bool IsAcademicDegree { get; set; }
        List<Paper> papers_list = new List<Paper>();
        List<Project> projects_list=new List<Project>();
        public Researcher(string name = "unknown_name", string surname = "unknown_surname",
               int day_birth = 1, int month_birth = 1, int year_birth = 1, bool academic_degree=false,
                DateTime birth_day=new DateTime())
               : base(name,surname,day_birth,month_birth,year_birth)
        {
            IsAcademicDegree = academic_degree;
            Birthday = birth_day;
        }

        public Researcher(Person person_data, bool academic_degree)
        {
            PersonData = person_data;
            IsAcademicDegree = academic_degree;
        }

        Person PersonData
        {
            get
            {
                return base.DeepCopy() as Person;
            }

            set
            {
                Birthday = value.Birthday;
                Name = value.Name;
                Surname = value.Surname;
            }
        }

        public List<Paper> PapersList
        {
            get
            {
                return papers_list;
            }

            set
            {
                papers_list = value;
            }
        }

        public List<Project> ProjectsList
        {
            get
            {
                return projects_list;
            }

            set
            {
                projects_list = value;
            }
        }
        public void AddPapers(params Paper[] papers_list)
        {

            for (int i = 0; i < papers_list.Count(); i++)
            {
                PapersList.Add(papers_list[i]);
            }
        }

        public void AddProjects(params Project[] projects_list)
        {
            for (int i = 0; i < projects_list.Count(); i++)
            {
                ProjectsList.Add(projects_list[i]);
            }
        }

		public override string ToString()
        {
            string output = "Researcher is ";
            output=output+base.ToString();
            if (IsAcademicDegree)
            {
                output = output + " Has academic degree\n";
            }
            else
            {
                output = output + " Does not have academic degree\n";
            }
            output = output + "Publications: \n";
            for (int i=0;i< papers_list.Count; i++)
            {
                output = output + ' '+papers_list[i].ToString();
            }
			output = output + "Projects: \n";
			for (int i=0;i< projects_list.Count; i++)
			{
				output = output + ' '+projects_list[i].ToString();
			}			
            return output;
        }

		public override string ToShortString()
        {
            string output = "Researcher is ";
            output = output + ' '+ base.ToString();
            if (IsAcademicDegree)
            {
                output = output + " Has academic degree\n";
            }
            else
            {
                output = output + " Does not have academic degree\n";
            }
            return output;
        }

        public new int Count {
            get
            {
                return ProjectsList.Count;
            }
        }

        public new object DeepCopy()
        {
            Researcher obj = new Researcher();
            obj.PersonData = PersonData;
            obj.IsAcademicDegree = IsAcademicDegree;
			for (int i = 0; i < PapersList.Count-1; i++) {
				obj.PapersList.Add(PapersList [i].DeepCopy () as Paper);
			}
			for (int i = 0; i < ProjectsList.Count-1; i++) {
				obj.ProjectsList.Add(ProjectsList [i].DeepCopy () as Project);
			}
            return obj;
        }

        double AverageTimeFrame
        {
            get
            {
                double average_time=0;
                for (int i = 0; i < ProjectsList.Count; i++)
                {
                    if (projects_list[i].TimeFrame == TimeFrame.Long)
                    {
                        average_time++;
                    }
                }
                return average_time/ProjectsList.Count;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new IteratorResearcher(this);
        }
		///Named iterator/////////////////
		public IEnumerable PaperEnumerator(int pulic_year){
			for (int i = 0; i < papers_list.Count; i++) {
				if (papers_list[i].PublicRelease.Year <= pulic_year) {
					yield return papers_list[i];
				}
			}
		}
	}

    public class IteratorResearcher:IEnumerator
    {
        Researcher obj;
        int index = -1;
        public IteratorResearcher(Researcher obj)
        {
            this.obj = obj;
        }

        public bool MoveNext()
        {
			while (index < obj.ProjectsList.Count-1)
            {
                index++;
                Project rd = obj.ProjectsList[index] as Project;
				if (rd.Count != 1) 
				{
					this.MoveNext ();
				} 
				else 
				{
					return true;
				}
            }
            return false;
        }

        public void Reset()
        {
            index = -1;
        }

        public object Current
        {
            get{
                return obj.ProjectsList[index];
            }
        }
    }
}
