using System.Collections.Generic;

namespace PersonsInfo
{
    public class Team
    {
        //---------------------------Fields---------------------------
        private readonly string name;
        private readonly List<Person> firstTeam;
        private readonly List<Person> reserveTeam;

        //---------------------------Properties---------------------------
        public IReadOnlyCollection<Person> FirstTeam
        { 
            get { return this.firstTeam.AsReadOnly(); }
        }
        public IReadOnlyCollection<Person> ReserveTeam
        {
            get { return this.reserveTeam.AsReadOnly(); }
        }

        //---------------------------Constructors---------------------------
        public Team(string name)
        {
            this.name = name;
            this.firstTeam = new List<Person>();
            this.reserveTeam = new List<Person>();
        }

        //---------------------------Methods---------------------------
        public void AddPlayer(Person person)
        {
            if (person.Age < 40)
            {
                firstTeam.Add(person);
            }
            else
            {
                reserveTeam.Add(person);
            }
        }
    }
}
