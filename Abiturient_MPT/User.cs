using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abiturient_MPT
{
    public class User
    {
        public string Name { get; set; }
        //public string Password { get; set; }
        public string Role { get; set; }
        public bool Enrollee { get; set; }
        public bool EnrolleeList { get; set; }
        public bool Disciplines { get; set; }
        public bool Specialities { get; set; }
        public bool Achievements { get; set; }
        public bool Olympiads { get; set; }
        public bool Statistics { get; set; }
    }
    public enum RoleType
    {
        ADMIN,
        GUEST
    }
}
