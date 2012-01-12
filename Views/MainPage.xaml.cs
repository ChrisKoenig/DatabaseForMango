using System;
using System.Collections.Generic;
using System.Linq;
using DatabaseForMango.ViewModels;
using Microsoft.Phone.Controls;

namespace DatabaseForMango.Views
{
    public partial class MainPage : PhoneApplicationPage
    {
        MainViewModel viewModel;

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += (sender, e) => viewModel = this.DataContext as MainViewModel;
        }

        private void AddFromWidgetSideButton_Click(object sender, EventArgs e)
        {
            viewModel.AddFromWidgetSide();
        }

        private void AddFromCategorySideButton_Click(object sender, EventArgs e)
        {
            viewModel.AddFromCategorySide();
        }

        private void RefreshViewMenu_Click(object sender, EventArgs e)
        {
            viewModel.Refresh();
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            viewModel.Update();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            viewModel.Delete();
        }

        private void RefreshDataabaseMenu_Click(object sender, EventArgs e)
        {
            viewModel.RecreateDatabase();
        }
    }
}