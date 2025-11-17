using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System;

namespace MauiWindowingTest
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
            => new Window(new NavigationPage(new IntermPage()));
    }
}