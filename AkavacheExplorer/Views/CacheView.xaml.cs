﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using AkavacheExplorer.ViewModels;
using ReactiveUI.Routing;
using ReactiveUI.Xaml;

namespace AkavacheExplorer.Views
{
    /// <summary>
    /// Interaction logic for CacheView.xaml
    /// </summary>
    public partial class CacheView : UserControl, IViewForViewModel<CacheViewModel>
    {
        public CacheView()
        {
            InitializeComponent();

            Observable.Merge(
                textRadio.ObservableFromDP(x => x.IsChecked).Where(x => x.Value == true).Select(x => x.Sender.Tag),
                jsonRadio.ObservableFromDP(x => x.IsChecked).Where(x => x.Value == true).Select(x => x.Sender.Tag)
            ).Subscribe(x => ViewModel.SelectedViewer = (string)x);
        }

        public CacheViewModel ViewModel {
            get { return (CacheViewModel)GetValue(ViewModelProperty); }
            set { SetValue(ViewModelProperty, value); }
        }
        public static readonly DependencyProperty ViewModelProperty =
            DependencyProperty.Register("ViewModel", typeof(CacheViewModel), typeof(CacheView), new UIPropertyMetadata(null));

        object IViewForViewModel.ViewModel { 
            get { return ViewModel; }
            set { ViewModel = (CacheViewModel) value; } 
        }
    }
}
