﻿using System;
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

        private void AddButton_Click(object sender, EventArgs e)
        {
            viewModel.Add();
        }

        private void RefreshButton_Click(object sender, EventArgs e)
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