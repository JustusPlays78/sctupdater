﻿using System;
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
using System.Windows.Shapes;

namespace SCTUpdater
{

    public partial class HomePage : Window
    {
        public HomePage()
        {
        
        InitializeComponent();
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
            HomePage CredentialsTab = new HomePage();
            this.Content = CredentialsTab;
        }
    }
}
