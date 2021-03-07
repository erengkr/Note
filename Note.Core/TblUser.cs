using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Core
{
    public partial class TblUser
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Tel { get; set; }
        public DateTime? Birthday { get; set; }
        public bool Gender { get; set; }

    }
}
