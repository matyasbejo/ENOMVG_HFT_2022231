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
        public ICommand stewCommand { get; set; }
        public ICommand tchwCommand { get; set; }
        public ICommand schwCommand { get; set; }

        public MainWindowVM()
        {
            if (!IsInDesignMode)
            {
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
