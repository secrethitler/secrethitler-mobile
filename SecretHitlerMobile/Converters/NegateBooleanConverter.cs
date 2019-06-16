using System;
using System.Globalization;

namespace SecretHitlerMobile.Converters
{
    public class NegateBooleanConverter : TypedValueConverter<bool, bool>
    {
        public override bool Convert(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return !value;
        }

        public override bool ConvertBack(bool value, Type targetType, object parameter, CultureInfo culture)
        {
            return !value;
        }
    }
}