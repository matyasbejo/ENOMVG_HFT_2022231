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
    internal class TeacherEditorVM : ObservableRecipient
    {
        public RestCollection<Teacher> Teachers { get; set; }
        public RestCollection<School> Schools { get; set; }

        private Teacher selectedTeacher;

        public Teacher SelectedTeacher
        {
            get { return selectedTeacher; }
            set
            {
                if (value != null)
                {
                    selectedTeacher = new Teacher()
                    {
                        Name = value.Name,
                        SchoolId = value.SchoolId,
                        MainSubject = value.MainSubject,
                        Salary = value.Salary,
                        Id = value.Id
                    };

                    OnPropertyChanged();
                    (CreateTeacherCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteTeacherCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateTeacherCommand as RelayCommand).NotifyCanExecuteChanged();
                }            }
        }

        public School helper {
            get {
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
            set { selectedTeacher.SchoolId = value.Id; } }


        public ICommand CreateTeacherCommand { get; set; }
        public ICommand DeleteTeacherCommand { get; set; }
        public ICommand UpdateTeacherCommand { get; set; }

        public TeacherEditorVM()
        {
            if (!IsInDesignMode)
            {
                Teachers = new RestCollection<Teacher>("http://localhost:15398/", "teacher");
                Schools = new RestCollection<School>("http://localhost:15398/", "school");

                try
                {
                    CreateTeacherCommand = new RelayCommand(() =>
                    {
                        int maxId = Teachers.Max(s => s.Id);
                        SelectedTeacher.Id = maxId + 1;
                        Teachers.Add(SelectedTeacher);
                    });

                    DeleteTeacherCommand = new RelayCommand(() =>
                    {
                        Teachers.Delete(SelectedTeacher.Id);
                        SelectedTeacher = new Teacher();
                    },
                    () => SelectedTeacher.Name != null && SelectedTeacher.Name != "");


                    UpdateTeacherCommand = new RelayCommand(() =>
                    {
                        Teachers.Update(SelectedTeacher);
                    },
                    () => SelectedTeacher.Name != null && SelectedTeacher.Name != "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            SelectedTeacher = new Teacher();
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
