using System;

namespace CSh_Lab_9
{
    class Team : INameAndCopy
    {
        //Поля
        protected string organization;
        protected int registrationNumber;

        //Реализация интерфейса
        string INameAndCopy.Name
        {
            get
            {
                return organization;
            }
            set
            {
                this.organization = value;
            }
        }

        //Конструкторы
        public Team()
        {
            this.organization = "No organization";
            this.registrationNumber = 0;
        }
        public Team(string organization, int registrationNumber)
        {
            this.organization = organization;
            this.registrationNumber = registrationNumber;
        }

        //Свойства
        public string Organization
        {
            get { return this.organization; }
            set { this.organization = value; }
        }
        public int RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Registration number must be more than 0 ");
                }
                else
                {
                    registrationNumber = value;
                }
            }
        }

        //Методы
        public virtual object DeepCopy()
        {
            return new Team(this.organization, this.registrationNumber);
        }

        //Перегрузка операторов
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }
            Team objAsTeam = obj as Team;
            if (objAsTeam as Team == null)
            {
                return false;
            }
            return objAsTeam.Organization == this.Organization && objAsTeam.RegistrationNumber == this.RegistrationNumber;

        }
        static public bool operator ==(Team l_Team, Team r_Team)
        {
            return ReferenceEquals(l_Team, r_Team);
        }
        static public bool operator !=(Team l_Team, Team r_Team)
        {
            return !(l_Team == r_Team);
        }
        public override int GetHashCode()
        {
            int HashCode = 0;
            foreach (char ch in organization.ToCharArray())
            {
                HashCode += (int)Convert.ToUInt32(ch);
            }
            HashCode += registrationNumber;
            return HashCode;
        }
        public virtual new string ToString()
        {
            return string.Format("Team of organisation {0} with registration number {1}", organization, registrationNumber);
        }
    }
}
