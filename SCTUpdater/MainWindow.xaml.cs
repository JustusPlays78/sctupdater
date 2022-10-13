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
using MessageBox = System.Windows.Forms.MessageBox;
using SCTUpdater;

namespace SCTUpdater
{
    public class Strings
    {
        public static bool IsSctPathSet { get; set; }
    }
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
                Strings.IsSctPathSet = true;
                Config.SetSctPath(fileddialog.SelectedPath);
            }
        }

        //ExitButton, was soll ich sagen
        private void ExitButton(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        /*Starts the Credentials Saving Process*/
        private void SaveCredsButton(object sender, RoutedEventArgs e)
        {
            bool isCidEnteredValid = long.TryParse(CidTextBox.Text, out long CidLong);

            if (isCidEnteredValid)
            {
                CredentialProcess.SaveCredentials(
                    NameTextBox.Text,
                    CidLong,
                    PasswordTextBox.Text,
                    CpdlcTextBox.Text
                );

                //Config.SetCredentialsPath();

                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Invalid CID Entered");
            }
        }

        private void UIElement_OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void EdggButtonProcessStart(object sender, RoutedEventArgs e)
        {
            bool? CopyCid = EdggNameCidCheckBox.IsChecked;
            bool? CopyPassword = EdggPasswordCheckBox.IsChecked;
            bool? CopyCpdlc = EdggPasswordCpdlc.IsChecked;

            StartProcess.Start(0, CopyCid, CopyPassword, CopyCpdlc);
        }

        private void EdwwButtonProcessStart(object sender, RoutedEventArgs e)
        {
            bool? CopyCid = EdwwNameCidCheckBox.IsChecked;
            bool? CopyPassword = EdwwPasswordCheckBox.IsChecked;
            bool? CopyCpdlc = EdwwCpdlcCheckBox.IsChecked;

            StartProcess.Start(1, CopyCid, CopyPassword, CopyCpdlc);
        }

        private void EdmmButtonProcessStart(object sender, RoutedEventArgs e)
        {
            bool? CopyCid = EdmmNameCidCheckBox.IsChecked;
            bool? CopyPassword = EdmmPasswordCheckBox.IsChecked;
            bool? CopyCpdlc = EdmmCpldcPasswordCheckBox.IsChecked;

            StartProcess.Start(2, CopyCid, CopyPassword, CopyCpdlc);
        }
    }
}
