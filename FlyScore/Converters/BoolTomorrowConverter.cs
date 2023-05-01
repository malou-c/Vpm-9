﻿using Avalonia;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;
using System.Globalization;
using System.Reflection;

namespace FlightScoreboard.Converters
{
    public class BoolTodayConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool flag && targetType.IsAssignableFrom(typeof(Bitmap)))
            {
                Uri uri;
                string assemblyName = Assembly.GetEntryAssembly().GetName().Name;
                uri = flag ? new Uri($"avares://{assemblyName}/Assets/today_yes.jpg") : new Uri($"avares://{assemblyName}/Assets/today_no.jpg");

                var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
                var asset = assets.Open(uri);

                return new Bitmap(asset);
            }

            throw new NotSupportedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
