using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using laboratory__practice_2.Interfaces;

namespace laboratory__practice_2.Project
{
    public enum TimeFrame
    {
        Year,
        TwoYears,
        Long
    }

    [Serializable]
    public class Project: IDeepCopy, ITeamCount
    {
        public string Theme { get; set; }
        public int NumberPartner { get; set; }
        public TimeFrame TimeFrame { get; set; }
        public Project(string theme="unknown theme", int num_partner=0,
            TimeFrame time_frame=default(TimeFrame))
        {
            Theme = theme;
            NumberPartner = num_partner;
            TimeFrame = time_frame;
        }
        public int Count
        {
            get
            {
                return NumberPartner;
            }
        }
        public object DeepCopy()
        {
            Project obj = new Project();
            obj.NumberPartner = NumberPartner;
            obj.Theme = Theme;
            obj.TimeFrame = TimeFrame;
            return obj;
        }

        public override string ToString()
        {
            return "Project \"" + Theme +
                   "\" with " + NumberPartner +
                   " partners " + TimeFrame.ToString() + "\n";
        }
    }
}
