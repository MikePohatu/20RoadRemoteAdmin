﻿#region license
// Copyright (c) 2021 20Road Limited
//
// This file is part of 20Road Remote Admin.
//
// 20Road Remote Admin is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, version 3 of the License.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
//
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using WindowsHelpers;

namespace _20RoadRemoteAdmin.Tabs
{
    /// <summary>
    /// Interaction logic for WindowsClientTab.xaml
    /// </summary>
    public partial class WindowsClientTab : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(object sender, string name)
        {
            PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(name));
        }

        public double InfoMaxWidth
        {
            get
            {
                return this.propsColumn.ActualWidth - this.toolsGroup.Margin.Left - this.toolsGroup.Margin.Right;
            }
        }

        public WindowsClientTab()
        {
            InitializeComponent();
            this.SizeChanged += (object sender, SizeChangedEventArgs e) => { this.OnPropertyChanged(this, "InfoMaxWidth"); };
            this.OnPropertyChanged(this, "InfoMaxWidth");
        }

        public void onCDollorClicked(object sender, RoutedEventArgs e)
        {
            RemoteSystem.Current?.OpenCDollar();
        }

        public async void onGPUpdateClicked(object sender, RoutedEventArgs e)
        {
            await RemoteSystem.Current?.GpUpdateAsync();
        }
    }
}
