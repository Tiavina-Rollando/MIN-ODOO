using System;
using System.Collections.Generic;
using System.Windows;
using Gestion_RH.Services;
using Gestion_RH.Classes;
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using Gestion_RH.Pages;

namespace Gestion_RH
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MainFrame.Navigate(new Login());
        }
    }
}
