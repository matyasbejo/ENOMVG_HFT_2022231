using ENOMVG_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ENOMVG_HFT_2022231.WpfClient.SubWindows
{
    /// <summary>
    /// Interaction logic for ListWindow.xaml
    /// </summary>
    public partial class ListWindow : Window
    {
        public ObservableCollection<IModel> Items { get; private set; }
        public ListWindow(IEnumerable<IModel> list)
        {
            InitializeComponent();

            this.DataContext = this;
            Items = new ObservableCollection<IModel>();
            foreach (var item in list)
            {
                Items.Add(item);
            }
        }

    }
}
