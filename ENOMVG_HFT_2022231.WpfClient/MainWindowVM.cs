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

        public ICommand beastStudentCommand { get; set; }

        public MainWindowVM()
        {
            if (!IsInDesignMode)
            {
                rest = new RestService("http://localhost:15398/");
                stewCommand = new RelayCommand(() =>
                {
                    StudentEditorWindow sw = new StudentEditorWindow();
                    sw.ShowDialog();
                });

                schwCommand = new RelayCommand(() =>
                {
                    SchoolEditorWindow sw = new SchoolEditorWindow();
                    sw.ShowDialog();
                });

                tchwCommand = new RelayCommand(() =>
                {
                    TeacherEditorWindow sw = new TeacherEditorWindow();
                    sw.ShowDialog();
                });

                mostPaidTchCommand = new RelayCommand(() =>
                {
                    MessageBox.Show($"Most paid teacher: {rest.GetSingle<Teacher>("/Statistics/Teacher_MostPaidTeacher").Name}");
                });

                leastPaidTchCommand = new RelayCommand(() =>
                {
                    MessageBox.Show($"Least paid teacher: {rest.GetSingle<Teacher>("/Statistics/Teacher_LeastPaidTeacher").Name}");
                });

                beastStudentCommand = new RelayCommand(() =>
                {
                    MessageBox.Show($"Best student: {rest.GetSingle<Student>("/Statistics/Student_BestStudent").Name}");
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
