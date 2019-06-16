using System;
using System.Globalization;
using Xamarin.Forms;

namespace SecretHitlerMobile.Converters
{
    public abstract class TypedValueConverter<TIn, TOut> : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TIn))
            {
                return null;
            }

            return Convert((TIn) value, targetType, parameter, culture);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is TOut))
            {
                return null;
            }

            return ConvertBack((TOut) value, targetType, parameter, culture);
        }

        public abstract TOut Convert(TIn value, Type targetType, object parameter, CultureInfo culture);

        public abstract TIn ConvertBack(TOut value, Type targetType, object parameter, CultureInfo culture);
    }
}