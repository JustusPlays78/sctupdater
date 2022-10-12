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
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SCTUpdater
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            configjson.startcheck();
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Changefile.startbutton();
        }

        private void savecreds_Click(object sender, RoutedEventArgs e)
        {
            Jsonfile.savecreds(name.Text, password.Text, cpdlc.Text, cid.Text);
        }

        private void Folderbutton(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fileddialog = new FolderBrowserDialog();
            if (fileddialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                SCTPath.pathdialog = fileddialog.SelectedPath;
                pathbutton.Content = SCTPath.pathdialog;
                configjson.savepath(SCTPath.pathdialog);
            }
        }

        private void MainWindow_OnContentRendered(object? sender, EventArgs e)
        {
            bool isConfigLoaded = configjson.startcheck();

            if (!isConfigLoaded)
            {
                System.Windows.Forms.MessageBox.Show("Keine Config erstellt");
            }

            else
            {
                pathbutton.Content = "";
            }
        }

        private void Exitclose(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
