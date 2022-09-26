using System;
using System.Collections.Generic;
using System.IO;
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

namespace IskolaGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            foreach (var item in File.ReadAllLines("../../../nevekGUI.txt"))
            {
                tanulok.Items.Add(item);
            }
        }

        private void törles_Click(object sender, RoutedEventArgs e)
        {
            if (tanulok.SelectedIndex == -1)
                MessageBox.Show("Nem jelölt ki tanulót!");
            else
                tanulok.Items.RemoveAt(tanulok.SelectedIndex);
        }

        private void mentes_Click(object sender, RoutedEventArgs e)
        {
            List<string> ki = new List<string>(); 
            foreach (var item in tanulok.Items)
            {
                ki.Add(item.ToString());
            }

            try
            {
                File.WriteAllLines("../../../nevekNEW.txt", ki);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
