using ENOMVG_HFT_2022231.Models;
using ENOMVG_HFT_2022231.WpfClient.SubWindows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ENOMVG_HFT_2022231.WpfClient
{
    class MainWindowVM : ObservableRecipient
    {
        RestService rest;
        public ICommand stewCommand { get; set; }
        public ICommand tchwCommand { get; set; }
        public ICommand schwCommand { get; set; }

        public ICommand mostPaidTchCommand { get; set; }
        public ICommand leastPaidTchCommand { get; set; }
        public ICommand bestStudentCommand { get; set; }
        public ICommand avgAgeCommand { get; set; }
        public ICommand youngStudentsCommand { get; set; }
        public ICommand bestStudentsCommand { get; set; }

        public RestCollection<School> Schools { get; set; }
        private School selectedSchool;
        public School SelectedSchool
        {
            get { return selectedSchool; }
            set
            {
                if (value != null)
                {
                    selectedSchool = new School()
                    {
                        Name = value.Name,
                        Type = value.Type,
                        Age = value.Age,
                        Students = value.Students,
                        Teachers = value.Teachers,
                        Id = value.Id
                    };

                    OnPropertyChanged();
                    (teachersOfSchCommand as RelayCommand).NotifyCanExecuteChanged();
                    (avgGradesOfSchCommand as RelayCommand).NotifyCanExecuteChanged();
                    (avgSalaryOfSchCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand teachersOfSchCommand { get; set; }
        public ICommand avgGradesOfSchCommand { get; set; }
        public ICommand avgSalaryOfSchCommand { get; set; }

        public MainWindowVM()
        {
            if (!IsInDesignMode)
            {
                rest = new RestService("http://localhost:15398/");
                Schools = new RestCollection<School>("http://localhost:15398/", "school");

                stewCommand = new RelayCommand(() =>
                {
                    StudentEditorWindow sw = new StudentEditorWindow();
                    sw.Show();
                });

                schwCommand = new RelayCommand(() =>
                {
                    SchoolEditorWindow sw = new SchoolEditorWindow();
                    sw.Show();
                });

                tchwCommand = new RelayCommand(() =>
                {
                    TeacherEditorWindow sw = new TeacherEditorWindow();
                    sw.Show();
                });


                mostPaidTchCommand = new RelayCommand(() =>
                {
                    MessageBox.Show($"Most paid teacher: {rest.GetSingle<Teacher>("/Statistics/Teacher_MostPaidTeacher").Name}");
                });

                leastPaidTchCommand = new RelayCommand(() =>
                {
                    MessageBox.Show($"Least paid teacher: {rest.GetSingle<Teacher>("/Statistics/Teacher_LeastPaidTeacher").Name}");
                });

                bestStudentCommand = new RelayCommand(() =>
                {
                    MessageBox.Show($"Best student: {rest.GetSingle<Student>("/Statistics/Student_BestStudent").Name}");
                });

                avgAgeCommand = new RelayCommand(() =>
                {
                    MessageBox.Show($"Avarage age: {rest.GetSingle<double>("/Statistics/Student_AvarageAge")}");
                });

                youngStudentsCommand = new RelayCommand(() =>
                {
                    ListWindow lw = new ListWindow(rest.GetSingle<IEnumerable<Student>>("/Statistics/Student_YoungStudents"));
                    lw.ShowDialog();
                });

                teachersOfSchCommand = new RelayCommand(() =>
                {
                    ListWindow lw = new ListWindow(rest.GetSingle<IEnumerable<Teacher>>($"/Statistics/School_TeachersOfSchool/{SelectedSchool.Id}"));
                    lw.ShowDialog();
                }, () => SelectedSchool != null);

                avgGradesOfSchCommand = new RelayCommand(() =>
                {
                    MessageBox.Show(rest.GetSingle<double>($"/Statistics/School_GradesAvg/{SelectedSchool.Id}").ToString());
                }, () => SelectedSchool != null);

                avgSalaryOfSchCommand = new RelayCommand(() =>
                {
                    MessageBox.Show(rest.GetSingle<double>($"/Statistics/School_SalaryAVG/{SelectedSchool.Id}").ToString());
                }, () => SelectedSchool != null);
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
