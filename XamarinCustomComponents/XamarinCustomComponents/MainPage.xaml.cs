using System;
using Widgets.Components.ToastMessage;
using Widgets.Enums;
using Widgets.Models;
using Xamarin.Forms;

namespace XamarinCustomComponents
{
    public partial class MainPage : ContentPage
    {
        public static int Count { get; set; } = default;
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnShowToastMessageClicked(object sender, EventArgs e)
        {
            Count++;
            
            var random = new Random();
            var seconds = random.Next(0, 4);
            
            var alertType = random.Next((int) ToastMessageType.Default, (int) ToastMessageType.Info);
            
            var message = new ToastMessageModel
            {
                Message = $"Test no# {Count}",
                DisplayTime = new TimeSpan(0,0,0, seconds),
                Type = (ToastMessageType) alertType
            };

            ToastMessageContainer.GetInstance().Display(message);
        }
    }
}