using RealTimeBikesWpf.ViewModel;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RealTimeBikesWpf
{
    /// <summary>
    /// Interaction logic for BikeGrid.xaml
    /// </summary>
    public partial class BikeGrid : UserControl
    {
        public BikeGrid()
        {
            InitializeComponent();
            DataContext = new BikeGridViewModel();
        }
    }
}
