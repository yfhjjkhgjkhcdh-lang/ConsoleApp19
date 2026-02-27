using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp19
{
    internal class Owner
    {
        public int OwnerID { get;  }
        private string name;
        public string Name
        {
            get { return name; }

        }

        public Owner(string name,int id)
        {
            this.name = name;
            this.OwnerID = id;

        }
       
    }
}
