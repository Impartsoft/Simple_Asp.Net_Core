using Simple_Asp.Net_Core.Models;
using System.Collections.Generic;

namespace Simple_Asp.Net_Core.Data
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=Guid.NewGuid(), HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"},
                new Command{Id=Guid.NewGuid(), HowTo="Cut bread", Line="Get a knife", Platform="knife & chopping board"},
                new Command{Id=Guid.NewGuid(), HowTo="Make cup of tea", Line="Place teabag in cup", Platform="Kettle & cup"}
            };

            return commands;
        }

        public Command GetCommandById(Guid id)
        {
            return new Command { Id = Guid.NewGuid(), HowTo = "Boil an egg", Line = "Boil water", Platform = "Kettle & Pan" };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command cmd)
        {
            throw new System.NotImplementedException();
        }
    }
}