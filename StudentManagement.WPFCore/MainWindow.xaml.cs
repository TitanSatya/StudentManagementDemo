﻿using StudentManagement.WPFCore.DataProvider;
using StudentManagement.WPFCore.ViewModels;

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

namespace StudentManagement.WPFCore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IStudentDataProvider studentAPIDataProvider;
        MainViewModel vm;
        public MainWindow()
        {
            InitializeComponent();
            studentAPIDataProvider = new StudentAPIDataProvider();
            vm = new MainViewModel(studentAPIDataProvider);
            DataContext = vm;
        }
    }
}
