using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratory__practice_2.Interfaces
{
    public interface IDeepCopy
    {
        object DeepCopy();
    }

    public interface ITeamCount
    {
        int Count
        {
            get;
        }
    }
}
