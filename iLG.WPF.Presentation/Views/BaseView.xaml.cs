﻿using iLG.WPF.Presentation.Components.Common;
using iLG.WPF.Presentation.Views;
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
using System.Windows.Shapes;

namespace iLG.WPF.Presentation.Views
{
    /// <summary>
    /// Interaction logic for BaseView.xaml
    /// </summary>
    public partial class BaseView : Window
    {
        private iLGSystem? _iLGSystem;

        public BaseView()
        {
            InitializeComponent();
            CreateAndInitializeSystemUserControl();
        }

        private void CreateAndInitializeSystemUserControl()
        {
            _iLGSystem = new iLGSystem();
            this.Content = _iLGSystem;
        }
    }
}

