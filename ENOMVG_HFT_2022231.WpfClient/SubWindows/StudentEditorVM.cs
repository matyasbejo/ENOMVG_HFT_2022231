using ENOMVG_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.DependencyInjection;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ENOMVG_HFT_2022231.WpfClient.SubWindows
{
    class StudentEditorVM
    {
        public RestCollection<Student> Students { get; set; }

        public ICommand CreateStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }

        public StudentEditorVM()
        {
            if (!IsInDesignMode)
            {
                Students = new RestCollection<Student>("http://localhost:15398/", "student");
                CreateStudentCommand = new RelayCommand(() =>
                    {
                        Student s = new Student();
                        s.Name = "sfl";
                        Students.Add(s);
                    });
            }
        }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
    }
}
