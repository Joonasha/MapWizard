﻿using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ToastNotifications;
using ToastNotifications.Core;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;
using Application = System.Windows.Application;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;
namespace MapWizard.Service
{
    /// <summary>
    /// Dialog service class.
    /// </summary>
    public class DialogService : IDialogService
    {
        Notifier _notifier;
        double notificationYCoordinate = 520;  // Enables different coordinates for notifications.

        /// <summary>
        /// Open file dialog.
        /// </summary>
        /// <param name="initialPath">Initial path.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="checkFileExists">Check if file exists.</param>
        /// <param name="checkPathExists">Check if path exists.</param>
        /// <returns>Open file dialog.</returns>
        public string OpenFileDialog(string initialPath = "", string filter = "", bool checkFileExists = true, bool checkPathExists = true)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = initialPath,
                Filter = filter,
                CheckFileExists = checkFileExists,
                CheckPathExists = checkPathExists,
            };
            if (openFileDialog.ShowDialog() == true)
            {
                return openFileDialog.FileName;
            }
            return default(string);
        }
        /// <summary>
        /// Open files dialog.
        /// </summary>
        /// <param name="initialPath">Initial path.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="checkFileExists">Check if files exists.</param>
        /// <param name="checkPathExists">Check if path exists.</param>
        /// <returns>Open files dialog.</returns>
        public List<string> OpenFilesDialog(string initialPath = "", string filter = "", bool checkFileExists = true, bool checkPathExists = true)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                InitialDirectory = initialPath,
                Filter = filter,
                CheckFileExists = checkFileExists,
                CheckPathExists = checkPathExists,
                Multiselect = true
            };

            if (openFileDialog.ShowDialog() == true)
            {

                List<string> files = new List<string>();

                foreach (string file in openFileDialog.FileNames)
                {
                    files.Add(file);
                }
                return files;
            }
            return default(List<string>);
        }
        /// <summary>
        /// Select folder dialog.
        /// </summary>
        /// <param name="selectedPath">Select path.</param>
        /// <param name="rootFolder">Root folder.</param>
        /// <returns>Select folder dialog.</returns>
        public string SelectFolderDialog(string selectedPath = "", Environment.SpecialFolder rootFolder = Environment.SpecialFolder.MyComputer)
        {

            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog()
            {
                SelectedPath = selectedPath,
                RootFolder = rootFolder
            };

            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                return folderBrowserDialog.SelectedPath;
            }
            return default(string);
        }
        /// <summary>
        /// Save file dialog.
        /// </summary>
        /// <param name="initialPath">Initial path.</param>
        /// <param name="filter">Filter.</param>
        /// <param name="checkFileExists">Check if files exists.</param>
        /// <param name="checkPathExists">Check if path exists.</param>
        /// <returns>Save file dialog.</returns>
        public string SaveFileDialog(string initialPath = "", string filter = "", bool checkFileExists = false, bool checkPathExists = true)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog()
            {
                InitialDirectory = initialPath,
                Filter = filter,
                CheckFileExists = checkFileExists,
                CheckPathExists = checkPathExists,

            };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                saveFileDialog.FileName = saveFileDialog.FileName;
                return saveFileDialog.FileName;
            }
            return default(string);
        }
     
        /// <summary>
        /// Show ToastNotification on UI.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="level">Notification level.</param>
        /// <param name="callbackAction">Callback action.</param>
        /// <param name="timeout">Timeout.</param>
        public void ShowNotification(string message, string notificationType)
        {
            if (_notifier != null)
            {
                //_notifier.ClearMessages(new ClearAll());
                if (notificationYCoordinate == 520)
                {
                    notificationYCoordinate = 420;
                }
                else if (notificationYCoordinate == 420)
                {
                    notificationYCoordinate = 320;
                }
                else if (notificationYCoordinate == 320)
                {
                    notificationYCoordinate = 520;
                }
            }
            var mainWindow = Application.Current.MainWindow;
            _notifier = new Notifier(cfg =>
            {
                cfg.PositionProvider = new WindowPositionProvider(parentWindow: Application.Current.MainWindow, corner: Corner.TopLeft, offsetX: 350, offsetY: notificationYCoordinate);
                cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(notificationLifetime: TimeSpan.FromSeconds(10), maximumNotificationCount: MaximumNotificationCount.FromCount(1));
                cfg.Dispatcher = Application.Current.Dispatcher;
                cfg.DisplayOptions.TopMost = false;
                cfg.DisplayOptions.Width = 350;
            });
            var options = new MessageOptions
            {
                FontSize = 16, // Set notification font size.
                FreezeOnMouseEnter = false, // Set the option to prevent notification dissapear automatically if user move cursor on it.
                ShowCloseButton = true, // Set the option to show or hide close button on notifications.
                UnfreezeOnMouseLeave = true
            };
            if(notificationType == "Success")
            {
                _notifier.ShowSuccess(message, options);
            }
            else if (notificationType == "Warning")
            {
                _notifier.ShowWarning(message, options);
            }
            else if (notificationType == "Error")
            {
                _notifier.ShowError(message, options);
            }
        }
        public async void ShowMessageDialog()
        {
            var mySettings = new MetroDialogSettings()
            {
                AffirmativeButtonText = "Back",
                NegativeButtonText = "No",
            };
            var metroWindow = (Application.Current.MainWindow as MetroWindow);
            MessageDialogResult result = await metroWindow.ShowMessageAsync("", "", MessageDialogStyle.Affirmative, mySettings);

        }
    }
}