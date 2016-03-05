using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTestApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        void CalculateAndSetSalary()
        {
            double basic = Convert.ToDouble(txtBasic.Text);
            double hra = Convert.ToDouble(txtHRA.Text);
            double da = Convert.ToDouble(txtDA.Text);
            double total = CalculateSalary(basic, hra, da);
            tbResult.Text = total.ToString();
        }

        private double CalculateSalary(double basic, double hra, double da)
        {
            PowerShell ps = PowerShell.Create();
            string command = string.Format(@"& {{param ($basic,$hra,$da);{0}}} {1} {2} {3}", txtFormulae.Text, basic, hra, da);
            ps.AddScript(command);
            Collection<PSObject> result = ps.Invoke();
            return Convert.ToDouble( result[0].BaseObject);
        }
      
        private void thi_Click ( object sender, RoutedEventArgs e )
        {
            CalculateAndSetSalary();
        }
      
    }
}
