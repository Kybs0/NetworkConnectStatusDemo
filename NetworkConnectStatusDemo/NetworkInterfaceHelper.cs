using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace Cvte.EasiPreAssistant.Business
{
    public static class NetworkInterfaceHelper
    {
        /// <summary>
        /// 是否含有蓝牙模块
        /// </summary>
        /// <returns></returns>
        public static bool HasBluetoothNetwork()
        {
            var networkInterfaces = NetworkInterfaceHelper.GetAllAdapters();
            return networkInterfaces.Any(i => i.Description.Contains("Bluetooth"));
        }


        #region 网络适配器列表

        public static NetworkInterface[] GetAllAdapters()
        {
            //获取本地计算机上网络接口的对象
            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();
            //Debug.WriteLine("适配器个数：" + adapters.Length);
            //foreach (NetworkInterface adapter in adapters)
            //{
            //    Debug.Write("描述：" + adapter.Description);
            //    Debug.Write("标识符：" + adapter.Id);
            //    Debug.Write("名称：" + adapter.Name);
            //    Debug.Write("类型：" + adapter.NetworkInterfaceType);
            //    Debug.Write("速度：" + adapter.Speed * 0.001 * 0.001 + "M");
            //    Debug.Write("操作状态：" + adapter.OperationalStatus);
            //    Debug.Write("MAC 地址：" + adapter.GetPhysicalAddress());

            //    //格式化显示MAC地址
            //    PhysicalAddress pa = adapter.GetPhysicalAddress();//获取适配器的媒体访问（MAC）地址
            //    byte[] bytes = pa.GetAddressBytes();//返回当前实例的地址
            //    StringBuilder sb = new StringBuilder();
            //    for (int i = 0; i < bytes.Length; i++)
            //    {
            //        sb.Append(bytes[i].ToString("X2"));//以十六进制格式化
            //        if (i != bytes.Length - 1)
            //        {
            //            sb.Append("-");
            //        }
            //    }
            //    Debug.WriteLine("MAC 地址：" + sb);

            //}
            return adapters;
        }

        #endregion
    }
}
