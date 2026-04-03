using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace View.Converters;

/// <summary>
/// Конвертер для привязки булевых значений к свойству Visibility.
/// </summary>
public class BooleanToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Конвертор в невидимость кнопки.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    /// <summary>
    /// Конвертор в видимость кнопки.
    /// </summary>
    /// <param name="value"></param>
    /// <param name="targetType"></param>
    /// <param name="parameter"></param>
    /// <param name="culture"></param>
    /// <returns></returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Visibility visibility)
        {
            return visibility == Visibility.Visible;
        }
        return false;
    }
}