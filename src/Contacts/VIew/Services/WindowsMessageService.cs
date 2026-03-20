using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using View.ViewModel.Services;

namespace View.Services;

/// <summary>
/// Реализация сервиса отображения сообщений.
/// </summary>
public class WindowsMessageService : IMessageService
{
    /// <summary>
    /// Отображает сообщение об успешной загрузке контакта.
    /// </summary>
    public void SuccessLoadMessage()
    {
        MessageBox.Show(
            "Контакт успешно загружен!",
            "Загрузка",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }

    /// <summary>
    /// Отображает сообщение об успешном сохранении контакта.
    /// </summary>
    public void SuccessSaveMessage()
    {
        MessageBox.Show(
            "Контакт успешно сохранен!",
            "Сохранение",
            MessageBoxButton.OK,
            MessageBoxImage.Information);
    }

    /// <summary>
    /// Отображает сообщение об ошибке с деталями исключения.
    /// </summary>
    /// <param name="ex">Исключение, содержащее информацию об ошибке.</param>
    public void FailureMessage(Exception ex)
    {
        MessageBox.Show(
            $"Ошибка при выполнении: {ex.Message}",
            "Ошибка",
            MessageBoxButton.OK,
            MessageBoxImage.Error);
    }
}