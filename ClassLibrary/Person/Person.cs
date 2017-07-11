using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laboratory__practice_2.Interfaces;

namespace laboratory__practice.Persons
{
    [Serializable]
    public class Person : ITeamCount, IDeepCopy
    {
        protected string[] init_arr;
        protected DateTime birth_day;
        public Person(string name="unknown_name", string surname="unknown_surname", 
               int day_birth=1, int month_birth=1, int year_birth=1)
        {
            init_arr = new string[2];
            init_arr[0] = name;
            init_arr[1] = surname;
            birth_day = new DateTime(year_birth,month_birth,day_birth);
        }

        public string Name
        {
            get
            {
                return init_arr[0];
            }
   
            set
            {
                init_arr[0] = value;
            }
        }

        public string Surname
        {
            get
            {
                return init_arr[1];
            }

            set
            {
                init_arr[1] = value;
            }
        }

        public DateTime Birthday
        {
            get
            {
                return birth_day;
            }

            set
            {
                birth_day = value;
            }
        }

        public override string ToString()
        {
            return "Person " + init_arr[0] + ' ' +
                   init_arr[1] + ' ' + birth_day.ToString() + " of type Person\n";
        }

        public virtual string ToShortString()
        {
            return "Person " + init_arr[1] + ' ' + init_arr[0][0] + ".\n";
        }

        public object DeepCopy()
        {
            Person obj = new Person(init_arr[0],init_arr[1]);
            obj.Birthday = this.Birthday;
            return obj;           
        }

        public int Count { get; }
    }
}
