using Microsoft.Maui.Controls;
using Microsoft.Maui.Devices;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using UIKit;


namespace MauiWindowingTest
{
    public partial class IntermPage : ContentPage
    {
        public IntermPage()
        {
            InitializeComponent();
            var viewModel = new IntermPageViewModel();
            BindingContext = viewModel;
            SizeChanged += viewModel.ViewSizeChanged;
        }
    }

    public class IntermPageViewModel : INotifyPropertyChanged
    {
        private readonly double _screenWidth = DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density;
        private readonly double _screenHeight = DeviceDisplay.MainDisplayInfo.Height / DeviceDisplay.MainDisplayInfo.Density;

        private double? _currentWidth = 0;
        private double? _currentHeight = 0;

        public event PropertyChangedEventHandler? PropertyChanged;
        
        public string ScreenSize => $"{_screenWidth.ToString("F2")} X {_screenHeight.ToString("F2")}";

        public string CurrentSize => $"{_currentWidth?.ToString("F2")} X {_currentHeight?.ToString("F2")}";

        public string ScreenCurrentRatio => $"{_currentWidth / _screenWidth:F2}% X {_currentHeight / _screenHeight:F2}%";

        public ICommand NavigateToTabPageCommand { get; set; }

        public IntermPageViewModel()
        {
            NavigateToTabPageCommand = new Command(() =>
            {
                try
                {
                    Application.Current?.Windows[0]?.Page?.Navigation.PushAsync(new MainTabbedPage());
                }
                catch (Exception ex)
                {
                    Application.Current?.Windows[0]?.Page?.DisplayAlert("Error", ex.ToString(), "OK");
                }
            });
        }

        internal void ViewSizeChanged(object? sender, EventArgs e)
        {
            _currentWidth = Application.Current?.Windows[0].Width;
            _currentHeight = Application.Current?.Windows[0].Height;
            OnPropertyChanged(nameof(CurrentSize));
            OnPropertyChanged(nameof(ScreenCurrentRatio));
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}