using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Threading;
using Microsoft.Win32;


namespace Common
{


    /*[StructLayout(LayoutKind.Sequential)]
    public struct CpuInfo
    {
        /// <summary>
        /// OEM ID
        /// </summary>
        public uint dwOemId;

        /// <summary>
        /// 页面大小
        /// </summary>
        public uint dwPageSize;
        public uint lpMinimumApplicationAddress;
        public uint lpMaximumApplicationAddress;
        public uint dwActiveProcessorMask;

        /// <summary>
        /// CPU等级
        /// </summary>
        public uint dwProcessorLevel;
        public uint dwProcessorRevision;
    }*/

    [StructLayout(LayoutKind.Sequential)]
    public struct MemoryInfo
    {
        public uint dwLength;
        /// <summary>
        /// 已经使用的内存大小
        /// </summary>
        public uint dwMemoryLoad;

        /// <summary>
        /// 总的内存大小
        /// </summary>
        public uint dwTotalPhys;


        /// <summary>
        /// 可用的内存大小
        /// </summary>
        public uint dwAvailPhys;

        /// <summary>
        /// 交换文件总大小
        /// </summary>
        public uint dwTotalPageFile;

        /// <summary>
        /// 可用交换文件大小
        /// </summary>
        public uint dwAvailPageFile;

        /// <summary>
        /// 总虚拟内存大小
        /// </summary>
        public uint dwTotalVirtual;

        /// <summary>
        /// 可用虚拟内存大小
        /// </summary>
        public uint dwAvailVirtual;

    }



    class RuntimeInfo
    {

        CpuUsage cpuUsage;

        MemoryInfo memInfo;

        internal sealed class CpuUsage
        {
            PerformanceCounter pc;

            public CpuUsage()
            {
                pc = new PerformanceCounter();
                pc.CategoryName = "Processor";
                pc.CounterName = "% Processor Time";
                pc.InstanceName = "_Total";
            }

            public string GetCpuUsage()
            {
                string CpuUsage = null;
                while (CpuUsage == "0" || CpuUsage == null)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Thread.Sleep(200);
                        try
                        {
                            CpuUsage = pc.NextValue().ToString();
                        }
                        catch (Exception)
                        { }
                    }
                }

                return CpuUsage;
                
            }
        }

        public RuntimeInfo()
        {
            cpuUsage = new CpuUsage();
            memInfo = new MemoryInfo();
        }

        [DllImport("kernel32")]
        private static extern void GlobalMemoryStatus(ref MemoryInfo memInfo);


        public string GetCpuUsage()
        {
            return cpuUsage.GetCpuUsage();
        }

        public string GetMemUsage()
        {
            GlobalMemoryStatus(ref memInfo);
            uint totalMB = (memInfo.dwTotalPhys) / 1024 / 1024;
            uint availMB = (memInfo.dwAvailPhys) / 1024 / 1024;
            return ((totalMB - availMB) * 1.0 / totalMB * 100).ToString();

        }

    }
}
