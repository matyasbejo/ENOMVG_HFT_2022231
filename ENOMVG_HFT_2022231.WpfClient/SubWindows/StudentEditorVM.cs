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
                    (DeleteStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateStudentCommand as RelayCommand).NotifyCanExecuteChanged();
                }               
            }
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

                CreateStudentCommand = new RelayCommand(() =>
                {
                    int maxId = Students.Max(s => s.Id);
                    SelectedStudent.Id = maxId + 1;
                    Students.Add(SelectedStudent);
                }) ;

                DeleteStudentCommand = new RelayCommand(() =>
                {
                    Students.Delete(selectedStudent.Id);
                },
                () => SelectedStudent != null);

                UpdateStudentCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Students.Update(SelectedStudent);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                },
                () => selectedStudent != null && selectedStudent.Age >= 6 && selectedStudent.Age <= 28 && selectedStudent.GradesAVG >= 1.00 && selectedStudent.GradesAVG <= 5.00);
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
