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
using System.Security.Cryptography;
using System.Xml.Linq;

namespace SCTUpdater
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {

            Config.StartupChecks();
            InitializeComponent();
        }


        /*Opens the Folderdialog and sets the folderpath to the global value*/
        private void folderButton(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fileddialog = new FolderBrowserDialog();
            if (fileddialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathButton.Content = fileddialog.SelectedPath;
                //Paths.GeneralPath = fileddialog.SelectedPath;
            }
        }

        //ExitButton, was soll ich sagen
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /*Starts the Credentials Saving Process*/
        private void SaveCredsButton(object sender, RoutedEventArgs e)
        {
            CredentialProcess.SaveCredentials(NameTextBox.Text, CidTextBox.Text, CidTextBox.Text, CpdlcTextBox.Text);
        }
    }
}
