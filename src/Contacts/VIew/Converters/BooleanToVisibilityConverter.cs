using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace View.Converters;

/// <summary>
/// Конвертер для преобразования булевых значений в Visibility и обратно.
/// </summary>
/// <remarks>
/// Используется в привязках для управления видимостью UI-элементов.
/// true → Visibility.Visible
/// false → Visibility.Collapsed
/// </remarks>
public class BooleanToVisibilityConverter : IValueConverter
{
    /// <summary>
    /// Преобразует булево значение в Visibility.
    /// </summary>
    /// <param name="value">Исходное булево значение (true/false).</param>
    /// <param name="targetType">Целевой тип (не используется).</param>
    /// <param name="parameter">Дополнительный параметр (не используется).</param>
    /// <param name="culture">Культура (не используется).</param>
    /// <returns>
    /// Visibility.Visible — если value = true;
    /// Visibility.Collapsed — если value = false или значение не является bool.
    /// </returns>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool boolValue)
        {
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    /// <summary>
    /// Преобразует Visibility обратно в булево значение.
    /// </summary>
    /// <param name="value">Значение Visibility (Visible/Collapsed/Hidden).</param>
    /// <param name="targetType">Целевой тип (не используется).</param>
    /// <param name="parameter">Дополнительный параметр (не используется).</param>
    /// <param name="culture">Культура (не используется).</param>
    /// <returns>
    /// true — если value = Visibility.Visible;
    /// false — во всех остальных случаях.
    /// </returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is Visibility visibility)
        {
            return visibility == Visibility.Visible;
        }
        return false;
    }
}