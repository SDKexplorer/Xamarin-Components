using System;
using System.Threading.Tasks;
using Widgets.Enums;
using Widgets.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Widgets.Components.ToastMessage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToastMessage : ContentView
    {
        #region Properties
        
        private TimeSpan DisplayTime { get; set; }
        private TaskCompletionSource<ToastMessage> DisplayTimeElapsedTaskCompletionSource { get; } = new TaskCompletionSource<ToastMessage>();
        public Task<ToastMessage> MessageDisplayTimeElapsed => DisplayTimeElapsedTaskCompletionSource.Task;
        public ToastMessageType ToastMessageType { get; set; }
        
        #endregion

        
        #region Constructor

        internal ToastMessage(ToastMessageModel model)
        {
            InitializeComponent();
            DisplayTime = model.DisplayTime;
            MessageText.Text = model.Message;
            ToastMessageType = model.Type;
        }

        #endregion

        #region Methods

        internal async Task Display()
        {
            await Task.Delay(DisplayTime);
            DisplayTimeElapsedTaskCompletionSource.SetResult(this);
        }
        
        #endregion

    }
}