using StopWatch.Application.Services;
using StopWatch.Application.ViewModels;
using System;
using System.Linq;
using System.Threading;
using System.Windows;
using System.Windows.Input;

namespace StopWatch.UI.Views
{
    /// <summary>
    /// Interaction logic for StopWatchUI.xaml
    /// </summary>
    public partial class StopWatchUI : Window
    {
        StopWatchService _service;

        Timer _timer;

        public StopWatchUI()
        {
            InitializeComponent();
            _service = new StopWatchService();
            _timer = new Timer(LoadAllStopWatches, null, 0, 1000);
        }

        public async void LoadAllStopWatches(object? state = null)
        {
            try
            {
                await Dispatcher.Invoke(async () =>
                {
                    StopWatchGrid.Items.Clear();
                    (await _service.GetAll()).ToList().ForEach(x =>
                    {
                        StopWatchGrid.Items.Add(x);
                    });
                });
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void StartNewWatchButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                StopWatchViewModel obj = await _service.StartNew();

                StopWatchGrid.Items.Add(obj);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void StopStopWatch(object sender, RoutedEventArgs e)
        {
            try
            {
                StopWatchViewModel? viewModel = StopWatchGrid.SelectedItem as StopWatchViewModel;

                if (StopWatchGrid.SelectedItem != null && viewModel != null)
                {
                    StopWatchViewModel stoppedViewModel = await _service.Stop(viewModel.Id);
                    LoadAllStopWatches();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async void DeleteStopWatch(object sender, RoutedEventArgs e)
        {
            try
            {
                StopWatchViewModel? viewModel = StopWatchGrid.SelectedItem as StopWatchViewModel;

                if (StopWatchGrid.SelectedItem != null && viewModel != null)
                {
                    await _service.Delete(viewModel.Id);
                    LoadAllStopWatches();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}