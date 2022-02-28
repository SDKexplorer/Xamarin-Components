using System;
using Widgets.Enums;

namespace Widgets.Models
{
    public class ToastMessageModel
    {

        #region Properties

        public string Message { get; set; }
        public ToastMessageType Type { get; set; } = ToastMessageType.Default;
        public TimeSpan DisplayTime { get; set; } = new TimeSpan(0, 0, 0, 1);

        #endregion

        
        #region Constructors

        public ToastMessageModel() { }

        public ToastMessageModel(string message)
        {
            Message = message;
        }

        #endregion

    }
}