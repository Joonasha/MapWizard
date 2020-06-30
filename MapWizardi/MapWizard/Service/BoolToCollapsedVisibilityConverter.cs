﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace MapWizard.Service
{
    public class BoolToCollapsedVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((bool)value)
            {
                case false:
                    return "Collapsed";
                case true:
                    return "Visible";
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}