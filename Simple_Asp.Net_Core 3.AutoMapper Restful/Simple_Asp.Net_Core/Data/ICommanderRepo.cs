using Simple_Asp.Net_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Simple_Asp.Net_Core.Data
{
    public interface ICommanderRepo
    {
        IEnumerable<Command> GetAllCommands();
    }
}
