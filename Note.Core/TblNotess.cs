using System;
using System.Collections.Generic;
using System.Text;

namespace Note.Core
{
    public partial class TblNotess
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NoteContent { get; set; }
        public string UpdateDate { get; set; }
        public DateTime? InsertDate { get; set; }
        public int UserId { get; set; }
    }
}
