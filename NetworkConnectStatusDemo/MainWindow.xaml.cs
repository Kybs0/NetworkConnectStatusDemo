using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Cvte.EasiPreAssistant.Business;

namespace NetworkConnectStatusDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty IsConnectedByWebClientProperty = DependencyProperty.Register(
            "IsConnectedByWebClient", typeof(bool), typeof(MainWindow), new PropertyMetadata(default(bool)));

        public bool IsConnectedByWebClient
        {
            get { return (bool) GetValue(IsConnectedByWebClientProperty); }
            set { SetValue(IsConnectedByWebClientProperty, value); }
        }
        
        public static readonly DependencyProperty IsConnectedByWebClientTimeProperty = DependencyProperty.Register(
            "IsConnectedByWebClientTime", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));

        public double IsConnectedByWebClientTime
        {
            get { return (double) GetValue(IsConnectedByWebClientTimeProperty); }
            set { SetValue(IsConnectedByWebClientTimeProperty, value); }
        }
        public static readonly DependencyProperty IsIpHostConnectedProperty = DependencyProperty.Register(
            "IsIpHostConnected", typeof(bool), typeof(MainWindow), new PropertyMetadata(default(bool)));

        public bool IsIpHostConnected
        {
            get { return (bool) GetValue(IsIpHostConnectedProperty); }
            set { SetValue(IsIpHostConnectedProperty, value); }
        }

        public static readonly DependencyProperty IsIpHostConnectedTimeProperty = DependencyProperty.Register(
            "IsIpHostConnectedTime", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));

        public double IsIpHostConnectedTime
        {
            get { return (double) GetValue(IsIpHostConnectedTimeProperty); }
            set { SetValue(IsIpHostConnectedTimeProperty, value); }
        }

        public static readonly DependencyProperty IsPingSuccessProperty = DependencyProperty.Register(
            "IsPingSuccess", typeof(bool), typeof(MainWindow), new PropertyMetadata(default(bool)));

        public bool IsPingSuccess
        {
            get { return (bool) GetValue(IsPingSuccessProperty); }
            set { SetValue(IsPingSuccessProperty, value); }
        }

        public static readonly DependencyProperty IsPingSuccessTimeProperty = DependencyProperty.Register(
            "IsPingSuccessTime", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));

        public double IsPingSuccessTime
        {
            get { return (double) GetValue(IsPingSuccessTimeProperty); }
            set { SetValue(IsPingSuccessTimeProperty, value); }
        }

        public static readonly DependencyProperty IsNetworkAliveProperty = DependencyProperty.Register(
            "IsNetworkAlive", typeof(bool), typeof(MainWindow), new PropertyMetadata(default(bool)));

        public bool IsNetworkAlive
        {
            get { return (bool) GetValue(IsNetworkAliveProperty); }
            set { SetValue(IsNetworkAliveProperty, value); }
        }

        public static readonly DependencyProperty IsNetworkAliveTimeProperty = DependencyProperty.Register(
            "IsNetworkAliveTime", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));

        public double IsNetworkAliveTime
        {
            get { return (double) GetValue(IsNetworkAliveTimeProperty); }
            set { SetValue(IsNetworkAliveTimeProperty, value); }
        }

        public static readonly DependencyProperty InternetGetConnectedStateProperty = DependencyProperty.Register(
            "InternetGetConnectedState", typeof(bool), typeof(MainWindow), new PropertyMetadata(default(bool)));

        public bool InternetGetConnectedState
        {
            get { return (bool) GetValue(InternetGetConnectedStateProperty); }
            set { SetValue(InternetGetConnectedStateProperty, value); }
        }

        public static readonly DependencyProperty InternetGetConnectedStateTimeProperty = DependencyProperty.Register(
            "InternetGetConnectedStateTime", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));

        public double InternetGetConnectedStateTime
        {
            get { return (double) GetValue(InternetGetConnectedStateTimeProperty); }
            set { SetValue(InternetGetConnectedStateTimeProperty, value); }
        }

        public static readonly DependencyProperty IsWiredConnectedByAdapterProperty = DependencyProperty.Register(
            "IsWiredConnectedByAdapter", typeof(bool), typeof(MainWindow), new PropertyMetadata(default(bool)));

        public bool IsWiredConnectedByAdapter
        {
            get { return (bool) GetValue(IsWiredConnectedByAdapterProperty); }
            set { SetValue(IsWiredConnectedByAdapterProperty, value); }
        }

        public static readonly DependencyProperty IsWiredConnectedByAdapterTimeProperty = DependencyProperty.Register(
            "IsWiredConnectedByAdapterTime", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));

        public double IsWiredConnectedByAdapterTime
        {
            get { return (double) GetValue(IsWiredConnectedByAdapterTimeProperty); }
            set { SetValue(IsWiredConnectedByAdapterTimeProperty, value); }
        }

        public static readonly DependencyProperty IsWirelessConnectedByAdapterProperty = DependencyProperty.Register(
            "IsWirelessConnectedByAdapter", typeof(bool), typeof(MainWindow), new PropertyMetadata(default(bool)));

        public bool IsWirelessConnectedByAdapter
        {
            get { return (bool) GetValue(IsWirelessConnectedByAdapterProperty); }
            set { SetValue(IsWirelessConnectedByAdapterProperty, value); }
        }

        public static readonly DependencyProperty IsWirelessConnectedByAdapterTimeProperty = DependencyProperty.Register(
            "IsWirelessConnectedByAdapterTime", typeof(double), typeof(MainWindow), new PropertyMetadata(default(double)));

        public double IsWirelessConnectedByAdapterTime
        {
            get { return (double) GetValue(IsWirelessConnectedByAdapterTimeProperty); }
            set { SetValue(IsWirelessConnectedByAdapterTimeProperty, value); }
        }

        private async void RefreshButton_OnClick(object sender, RoutedEventArgs e)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            IsConnectedByWebClient = NetworkConnectionHelper.IsWebClientConnected();
            IsConnectedByWebClientTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            await Task.Delay(TimeSpan.FromSeconds(2));

            //单独定时器，防止网络测试被获取干扰
            stopwatch = new Stopwatch();
            stopwatch.Start();
            IsIpHostConnected = NetworkConnectionHelper.IsIPHostConnected();
            IsIpHostConnectedTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            await Task.Delay(TimeSpan.FromSeconds(2));

            stopwatch = new Stopwatch();
            stopwatch.Start();
            IsPingSuccess = await NetworkConnectionHelper.IsPingSuccess();
            IsPingSuccessTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            await Task.Delay(TimeSpan.FromSeconds(2));

            stopwatch = new Stopwatch();
            stopwatch.Start();
            IsNetworkAlive = NetworkConnectionHelper.IsNetworkAlive();
            IsNetworkAliveTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            await Task.Delay(TimeSpan.FromSeconds(2));

            stopwatch = new Stopwatch();
            stopwatch.Start();
            InternetGetConnectedState = NetworkConnectionHelper.InternetGetConnectedState();
            InternetGetConnectedStateTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            await Task.Delay(TimeSpan.FromSeconds(2));

            stopwatch = new Stopwatch();
            stopwatch.Start();
            IsWiredConnectedByAdapter = NetworkConnectionHelper.IsWiredNetworkConnected();
            IsWiredConnectedByAdapterTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();
            await Task.Delay(TimeSpan.FromSeconds(2));
                        
            stopwatch = new Stopwatch();
            stopwatch.Start();
            IsWirelessConnectedByAdapter = NetworkConnectionHelper.IsWirelessNetworkConnected();
            IsWirelessConnectedByAdapterTime = stopwatch.ElapsedMilliseconds;
            stopwatch.Stop();

        }
    }
}
