using ENOMVG_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    class StudentEditorVM : ObservableRecipient
    {
        public RestCollection<Student> Students { get; set; }
        public RestCollection<School> Schools { get; set; }

        private Student selectedStudent;
        public Student SelectedStudent
        {
            get { return selectedStudent; }
            set { 
                if(value != null)
                {
                    selectedStudent = new Student()
                    {
                        Age = value.Age,
                        Name = value.Name,
                        GradesAVG = value.GradesAVG,
                        SchoolId = value.SchoolId,
                        Id = value.Id
                    };

                    OnPropertyChanged();
                    (CreateStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                }               
            }
        }
        public School helper
        {
            get
            {
                return null; //kitalálni
                             //try
                             //{
                             //    Schools.GetEnumerator().Reset();
                             //    while (Schools.GetEnumerator().Current.Id != selectedTeacher.SchoolId)
                             //        Schools.GetEnumerator().MoveNext();
                             //    School s = Schools.GetEnumerator().Current;
                             //    Schools.GetEnumerator().Reset();
                             //    return s;
                             //}
                             //catch(Exception e) { return null; }
            }
            set { selectedStudent.SchoolId = value.Id; }
        }


        public ICommand CreateStudentCommand { get; set; }
        public ICommand DeleteStudentCommand { get; set; }
        public ICommand UpdateStudentCommand { get; set; }

        public StudentEditorVM()
        {
            if (!IsInDesignMode)
            {
                Students = new RestCollection<Student>("http://localhost:15398/", "student");
                Schools = new RestCollection<School>("http://localhost:15398/", "school");

                try
                {
                    CreateStudentCommand = new RelayCommand(() =>
                    {
                        int maxId = Students.Max(s => s.Id);
                        SelectedStudent.Id = maxId + 1;
                        Students.Add(SelectedStudent);
                    });

                    DeleteStudentCommand = new RelayCommand(() =>
                    {
                        Students.Delete(selectedStudent.Id);
                        SelectedStudent = new Student();
                    },
                    () => SelectedStudent.Name != null && SelectedStudent.Name != "");


                    UpdateStudentCommand = new RelayCommand(() =>
                    {
                        Students.Update(SelectedStudent);
                    },
                    () => SelectedStudent.Name != null && SelectedStudent.Name != "");
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            SelectedStudent = new Student();
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
