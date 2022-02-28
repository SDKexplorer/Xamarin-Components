using System.Linq;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using Widgets.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Widgets.Components.ToastMessage
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToastMessageContainer : PopupPage
    {

        #region Properties

        private static bool IsBeingDisplayed { get; set; } = false;
        private static ToastMessageContainer _instance { get; set; }
        
        #endregion

        #region Constructor

        private ToastMessageContainer()
        {
            InitializeComponent();
        }
        
        public static ToastMessageContainer GetInstance()
        {
            if (_instance != null)
            {
                return _instance;
            }

            _instance = new ToastMessageContainer();

            return _instance;
        }

        #endregion

        #region Methods

        private async Task HandleMessage(ToastMessage toastMessage)
        {
            await toastMessage.Display();

            var removableMessageOnCompletion = await toastMessage.MessageDisplayTimeElapsed;
            
            if (removableMessageOnCompletion == null)
            {
                return;
            }

            var indexToastToRemove = MessagesContainer.Children.IndexOf(removableMessageOnCompletion);
            MessagesContainer.Children.RemoveAt(indexToastToRemove);
            
            if (MessagesContainer.Children.Any())
            {
                return;
            }

            if (PopupNavigation.Instance.PopupStack.Any(page => page == this))
            {
                await PopupNavigation.Instance.RemovePageAsync(this);
                IsBeingDisplayed = false;
            }
        }

        public async void Display(ToastMessageModel toastModel)
        {
            await Task.Run(async () =>
            {
                Device.BeginInvokeOnMainThread( async () =>
                {
                    var toastMessage = new ToastMessage(toastModel);
                    MessagesContainer.Children.Add(toastMessage);
                    if (IsBeingDisplayed == false)
                    {
                        IsBeingDisplayed = true;
                        await PopupNavigation.Instance.PushAsync(this);
                    }

                    await HandleMessage(toastMessage);
                });
            });
        }
        #endregion
    }
}