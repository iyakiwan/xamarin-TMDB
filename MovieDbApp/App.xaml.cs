﻿using MovieDbApp.Data;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MovieDbApp
{
    public partial class App : Application
    {
        private static DataAccess dbUtils;
        public static DataAccess DBUtils
        {
            get
            {
                if (dbUtils == null)
                {
                    dbUtils = new DataAccess();
                }
                return dbUtils;
            }
        }


        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
