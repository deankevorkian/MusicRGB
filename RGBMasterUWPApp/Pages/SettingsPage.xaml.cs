﻿using AppExecutionManager.EventManagement;
using AppExecutionManager.State;
using Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace RGBMasterUWPApp.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SettingsPage : Page
    {
        private const string TurnOnDeviceOnCheckUserConfigKey = "TurnOnDeviceOnCheck";

        public ObservableCollection<ProviderMetadata> SupportedProviders
        {
            get
            {
                return AppState.Instance.SupportedProviders;
            }
        }

        public string AppVersion
        {
            get
            {
                return AppState.Instance.AppVersion;
            }
        }

        public bool TurnOnDeviceOnCheckUser
        {
            get
            {
                return AppState.Instance.UserSettingsCache.TryGetValue(TurnOnDeviceOnCheckUserConfigKey, out var shouldTurnOnDeviceOnCheck) ? (bool)shouldTurnOnDeviceOnCheck : true;
            }
        }

        public SettingsPage()
        {
            EventManager.Instance.LoadUserSetting(TurnOnDeviceOnCheckUserConfigKey);
            this.InitializeComponent();
        }

        private async void GitHub_Button_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("https://github.com/rgb-master-team/RGBMaster"));
        }

        private async void Discord_Button_Click(object sender, RoutedEventArgs e)
        {
            await Windows.System.Launcher.LaunchUriAsync(new Uri("https://discord.gg/zWbe3UV"));
        }

        private void Check_Turn_On_Device_When_Checked()
        {
            if (TurnOnDeviceEnabler.IsOn)
            { }
        }

        private async void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var clickedProvider = (ProviderMetadata)e.ClickedItem;

            if (clickedProvider.ProviderUrl == null)
            {
                return;
            }

            await Windows.System.Launcher.LaunchUriAsync(new Uri(clickedProvider.ProviderUrl));
        }

        private void TurnOnDeviceEnabler_Toggled(object sender, RoutedEventArgs e)
        {
            EventManager.Instance.StoreUserSetting(new Tuple<string, object>(TurnOnDeviceOnCheckUserConfigKey, TurnOnDeviceEnabler.IsOn));
        }
    }
}
