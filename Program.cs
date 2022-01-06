using System;
using System.Collections.Generic;

namespace CSh_Lab_9
{
    
    class Program
    { 
        static void Main(string[] args)
        {
            //1
            Console.WriteLine("#1"+'\n');
            Team Team1 = new Team("One", 7);
            Team Team2 = new Team("One", 7);
            Console.WriteLine(Team1.Equals(Team2));
            Console.WriteLine(Team1 == Team2);
            Console.WriteLine(string.Format(" MyTeam1: {0}, MyTeam2: {1} ", Team1.GetHashCode(), Team2.GetHashCode()));

            //2
            Console.WriteLine('\n' + "#2" + '\n');
            try
            {
                Team2.RegistrationNumber = -2;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }

            //3
            Console.WriteLine('\n' + "#3" + '\n');
            ResearchTeam Team3 = new ResearchTeam();
            Team3.AddMembers(new Person[3] { new Person("Ann", "Boguslavska", new DateTime(1992, 01, 13)), new Person("Some", "Person", new DateTime(1990, 11, 13)), new Person() });
            Team3.AddPepers(new Paper[2] { new Paper("SP", new Person("Ann", "Boguslavska", new DateTime(1992, 01, 13)), new DateTime(2016, 11, 13)), new Paper() });
            Console.WriteLine(Team3.ToString());

            //4
            Console.WriteLine('\n' + "#4" + '\n');
            Console.WriteLine(Team3.getTeamType.ToString());

            //5
            Console.WriteLine('\n' + "#5" + '\n');
            ResearchTeam Team4 = (ResearchTeam)Team3.DeepCopy();
            Team3.Organization = "SoftServe";
            Team3.RegistrationNumber = 7;
            Console.WriteLine(Team3.ToString());
            Console.WriteLine(Team4.ToString());
            
            //6
            Console.WriteLine('\n' + "#6" + '\n');
            foreach (Person pers in Team3.MembersWithoutPublications())
            {
                Console.WriteLine(pers);
            }

            //7
            Console.WriteLine('\n' + "#7" + '\n');
            foreach (Paper pap in Team3.LastPapers(2))
            {
                Console.WriteLine(pap);
            }
        }
    }
}