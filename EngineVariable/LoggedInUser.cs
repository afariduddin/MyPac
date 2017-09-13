using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EngineVariable
{
    public class LoggedInUser
    {
        public string Name { get; set; }
        public Guid ID { get; set; }
        public string SignInID { get; set; }
        //public EngineVariable.LibraryEnumeration.UserType UserType { get; set; }
        public Guid LawFirmID { get; set; }
        public Guid SessionKey { get; set; }

        public DateTime LastLogin { get; set; }
    }
}
