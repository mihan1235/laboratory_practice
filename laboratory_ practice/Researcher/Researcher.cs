using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using laboratory__practice.Persons;
using laboratory__practice.Papers;

namespace laboratory__practice.Researchers
{
    
    class Researcher
    {
        Person person_data;
        bool IsAcademicDegree { get; set; }
        Paper[] papers_list=new Paper[0];
        public Researcher(string name = "unknown_name", string surname = "unknown_surname",
               int day_birth = 1, int month_birth = 1, int year_birth = 1, bool academic_degree=false)
        {
            person_data = new Person(name,surname,day_birth,month_birth,
                              year_birth);
            IsAcademicDegree = academic_degree;
        }

        public Researcher(Person person_data, bool academic_degree)
        {
            this.person_data = person_data;
            IsAcademicDegree = academic_degree;
        }

        Person PersonData
        {
            get
            {
                return person_data;
            }

            set
            {
                person_data = value;
            }
        }

        Paper[] PaperList
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
        public void AddPapers(params Paper[] papers_list)
        {
            Paper[] old_paper_list = this.papers_list;
            this.papers_list = new Paper[old_paper_list.Length+ papers_list.Length];
            old_paper_list.CopyTo(this.papers_list, 0);
            papers_list.CopyTo(this.papers_list, old_paper_list.Length);
        }

        public override string ToString()
        {
            string output = "Researcher:\n";
            output=output+person_data.ToString();
            if (IsAcademicDegree)
            {
                output = output + " Has academic degree\n";
            }
            else
            {
                output = output + " Does not have academic degree\n";
            }
            output = output + "Publications: \n";
            for (int i=0;i< papers_list.Length; i++)
            {
                output = output + papers_list[i].ToString();
            }
            return output;
        }

        public string ToShortString()
        {
            string output = "Researcher:\n";
            output = output + ' '+ person_data.ToString();
            if (IsAcademicDegree)
            {
                output = output + " Has academic degree\n";
            }
            else
            {
                output = output + " Does not have academic degree\n";
            }
            output = output + "Publications: \n";
            return output;
        }
    }
}
