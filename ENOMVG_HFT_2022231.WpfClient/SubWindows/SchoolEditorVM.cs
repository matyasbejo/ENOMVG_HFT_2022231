using ENOMVG_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace ENOMVG_HFT_2022231.WpfClient.SubWindows
{
    internal class SchoolEditorVM : ObservableRecipient
    {
        public RestCollection<Teacher> Teachers { get; set; }
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
                    (CreateSchoolCommand as RelayCommand).NotifyCanExecuteChanged();
                    (DeleteSchoolCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateSchoolCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }


        public ICommand CreateSchoolCommand { get; set; }
        public ICommand DeleteSchoolCommand { get; set; }
        public ICommand UpdateSchoolCommand { get; set; }

        public SchoolEditorVM()
        {
            if (!IsInDesignMode)
            {
                Teachers = new RestCollection<Teacher>("http://localhost:15398/", "teacher", "hub");
                Schools = new RestCollection<School>("http://localhost:15398/", "school", "hub");

                try
                {
                    CreateSchoolCommand = new RelayCommand(() =>
                    {
                        int maxId = Schools.Max(s => s.Id);
                        SelectedSchool.Id = maxId + 1;
                        Schools.Add(SelectedSchool);
                    });

                    DeleteSchoolCommand = new RelayCommand(() =>
                    {
                        Schools.Delete(SelectedSchool.Id);
                        SelectedSchool = new School();
                    },
                    () => SelectedSchool.Name != null && SelectedSchool.Name != "");


                    UpdateSchoolCommand = new RelayCommand(() =>
                    {
                        Schools.Update(SelectedSchool);
                    },
                    () => SelectedSchool.Name != null && SelectedSchool.Name != "");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            SelectedSchool = new School();
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
