using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Cvte.EasiPreAssistant.Business
{
    /// <summary>
    /// 网络连接状态辅助类
    /// </summary>
    public class NetworkConnectionHelper
    {
        #region 有线/无线

    /// <summary>
    /// 有线连接
    /// </summary>
    /// <returns></returns>
    public static bool IsWiredNetworkConnected()
    {
        var adaters = NetworkInterfaceHelper.GetAllAdapters();
        if (adaters.Any(i => (i.Name.ToString().Contains("以太网")||i.Name.ToString().Contains("拨号")||i.Name.ToString().Contains("宽带")) && i.OperationalStatus == OperationalStatus.Up))
        {
            return true;
        }
        return false;
    }

    /// <summary>
    /// 无线连接
    /// </summary>
    /// <returns></returns>
    public static bool IsWirelessNetworkConnected()
    {
        var adaters = NetworkInterfaceHelper.GetAllAdapters();
        if (adaters.Any(i => i.Name.ToString().Contains("WLAN") && i.OperationalStatus == OperationalStatus.Up))
        {
            return true;
        }
        return false;
    }

        #endregion

        #region WebClient

    public static bool IsWebClientConnected()
    {
        try
        {
            using (var client = new WebClient())
            using (var stream = client.OpenRead("http://www.qq.com"))
            {
                return true;
            }
        }
        catch
        {
            return false;
        }
    }

        #endregion

        #region IPHost

    public static bool IsIPHostConnected()
    {
        try
        {
            System.Net.IPHostEntry i = System.Net.Dns.GetHostEntry("www.google.com");
            return true;
        }
        catch
        {
            // ignored
        }
        return false;
    }

        #endregion

        #region Ping

    public static async Task<bool> IsPingSuccess()
    {
        try
        {
            using (Ping myPing = new Ping())
            {
                var result = await myPing.SendPingAsync("google.com", 3000 /*3 secs timeout*/, new byte[32], new PingOptions(64, true));
                return result.Status == IPStatus.Success;
            }
        }
        catch
        {
            // ignored
        }
        return false;
    }

        #endregion

        #region IsNetworkAlive

        //通过IsNetworkAlive方法，来获取电脑的联网状态
        [DllImport("sensapi.dll", SetLastError = true)]
        private static extern bool IsNetworkAlive(out int connectionDescription);

        public static bool IsNetworkAlive()
        {
            var isNetworkConnected = IsNetworkAlive(out int flags);
            return isNetworkConnected;
        }

        #endregion

        #region InternetGetConnectedState

        [DllImport("winInet.dll ")]
        private static extern bool InternetGetConnectedState(ref int flag, int dwReserved);

        //有线
        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;
        private const int INTERNET_CONNECTION_PROXY = 4;
        private const int INTERNET_CONNECTION_MODEM_BUSY = 8;

        public static bool InternetGetConnectedState()
        {
            var dwFlag = 0;
            if (InternetGetConnectedState(ref dwFlag, 0))
            {
                if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
                {
                    //采用调制解调器上网（拨号）
                    return true;
                }
                if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
                {
                    //局域网
                }
                return true;
            }
            return false;
        }

        #endregion

    }
}
