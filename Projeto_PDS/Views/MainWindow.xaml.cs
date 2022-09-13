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

namespace Projeto_PDS.Views
{
    /// <summary>
    /// Lógica interna para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.setPageMain();
        }

        public  void setPage(string page)
        {
            var pack = "pack://application:,,,/Views";
            framePage.Source = new Uri($"{pack}/{page}.xaml");
        }

        public void setPageMain()
        {
            framePage.Source = new Uri("pack://application:,,,/Views/PageMain.xaml");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var frame = framePage;
            var pack = "pack://application:,,,/Views";



            switch (button.Name)
            {
                case "MN_Funcionario":
                    framePage.NavigationService.Navigate(new PageFornecedor(this)); //Uri($"{pack}/PageFornecedor.xaml");
                    break;
                case "MN_Cliente":
                    framePage.Source = new System.Uri($"{pack}/PageCliente.xaml");
                    break;
            }
        }

    }
}