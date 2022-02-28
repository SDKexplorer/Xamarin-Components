using System;
using System.Globalization;
using Widgets.Enums;
using Xamarin.Forms;

namespace Widgets.Components.ToastMessage
{
    public class ToastMessageTypeValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var castedValue = (ToastMessageType) value;

            switch (castedValue)
            {
                case ToastMessageType.Default:
                {
                    return new Color(150d, 120d, 120d);
                }
                case ToastMessageType.Error:
                {
                    return new Color(255d, 0d, 0d);
                }

                default:
                {
                    return new Color(0d, 0d, 0d);
                }
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}