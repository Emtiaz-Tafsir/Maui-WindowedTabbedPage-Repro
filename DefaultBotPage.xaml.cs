using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Microsoft.Maui.Accessibility;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace MauiWindowingTest
{
    public partial class DefaultBotPage : ContentPage, INotifyPropertyChanged
    {
        int count = 0;
        private Color _bindableBackgroundColor;
        private double _imageRotation;

        public Color BindableBackgroundColor
        {
            get => _bindableBackgroundColor;
            set
            {
                if (_bindableBackgroundColor != value)
                {
                    _bindableBackgroundColor = value;
                    OnPropertyChanged();
                }
            }
        }

        public double ImageRotation
        {
            get => _imageRotation;
            set
            {
                if (_imageRotation != value)
                {
                    _imageRotation = value;
                    OnPropertyChanged();
                }
            }
        }

        public DefaultBotPage()
        {
            InitializeComponent();
            BindingContext = this;

            // Default values
            BindableBackgroundColor = Colors.Brown;
            ImageRotation = 0;
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public new event PropertyChangedEventHandler PropertyChanged;
    }
}
