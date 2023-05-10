using ENOMVG_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENOMVG_HFT_2022231.WpfClient.SubWindows
{
    class StudentEditorVM
    {
        public RestCollection<Student> Students { get; set; }
        public StudentEditorVM()
        {
            Students = new RestCollection<Student>("http://localhost:15398/", "student");
        }
    }
}
