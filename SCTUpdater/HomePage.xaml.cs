using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using MessageBox = System.Windows.Forms.MessageBox;

namespace SCTUpdater
{

    public partial class HomePage : Window
    {
        public static HomePage Main { get; set; }

        public static SolidColorBrush white = new SolidColorBrush(Colors.White);
        public static SolidColorBrush darkBlue = new SolidColorBrush(Color.FromRgb(35, 50, 68));
        public HomePage()
        {
            Config.StartupChecks();
            Paths newPath = Config.ImportPaths();
            InitializeComponent();

            string builder = "Debug. \n WIP";
            DebugBox.Text = builder;
            DebugBox.Visibility = Visibility.Visible;

            PathTextBox.Text = newPath.SctPath;
            
            
        }

        private void MouseDragAndDrop(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void HomeTabClose(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }
        private void HomeTabMinimize(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void HomeTab_Click(object sender, RoutedEventArgs e)
        {
            HomeGrid.Visibility = Visibility.Visible;
            CredentialsGrid.Visibility = Visibility.Hidden;

            HomeTabButton.Foreground = darkBlue;
            HomeTabButton.Background = white;

            CredentialsTabButton.Foreground = white;
            CredentialsTabButton.Background = darkBlue;
        }

        private void FolderSelectButton_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fileddialog = new FolderBrowserDialog();
            if (fileddialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                PathTextBox.Text = fileddialog.SelectedPath;
                Strings.IsSctPathSet = true;
                Config.SetSctPath(fileddialog.SelectedPath);
                ProcessStartButton.IsEnabled = true;
            }
        }
        private void OnContentRendered(object sender, EventArgs e)
        {
            Main = this;
        }

        private void CredentialsTab_Click(object sender, RoutedEventArgs e)
        {
            HomeGrid.Visibility = Visibility.Hidden;
            CredentialsGrid.Visibility = Visibility.Visible;

            HomeTabButton.Foreground = white;
            HomeTabButton.Background = darkBlue;

            CredentialsTabButton.Foreground = darkBlue;
            CredentialsTabButton.Background = white;
        }

        private void SaveCredsButton_Click(object sender, RoutedEventArgs e)
        {
            bool isCidEnteredValid = long.TryParse(CIDTextBox.Text, out long CidLong);

            if (isCidEnteredValid)
            {
                CredentialProcess.SaveCredentials(
                    NameTextBox.Text,
                   CidLong,
                    PasswordTextBox.Text,
                    CPDLCTextBox.Text
                );

                //Config.SetCredentialsPath();

                MessageBox.Show("Done");
            }
            else
            {
                MessageBox.Show("Invalid CID Entered");
            }

            //var credentials = new Credentials();

            //credentials.Name = NameTextBox.Text != null ? NameTextBox.Text : null; 
        }
        private void ProcessStart(object sender, RoutedEventArgs e)
        {
            bool? CopyCid = NameCidCheckBox.IsChecked;
            bool? CopyPassword = PasswordCheckBox.IsChecked;
            bool? CopyCpdlc = CpdlcCheckBox.IsChecked;
            bool? CopyHdgDrawTool = HdgDrawToolCheckBox.IsChecked;

            StartProcess.Start(CopyCid, CopyPassword, CopyCpdlc, CopyHdgDrawTool);
            MessageBox.Show("Done");
        }
    }
}
