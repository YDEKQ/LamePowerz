using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace LamePowerz.Brute
{
    public class RadminPackets
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct PacketVer1
        {
            public int code;
            public int datalen;
            public byte[] data;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct SubpacketVer2
        {
            public int id;
            public int size;
            public byte[] data;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PacketDataVer2
        {
            public short id;
            public short size;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PacketVer2
        {
            public int flags;
            public int seq;
            public int count;
            public SubpacketVer2 data;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PacketHeaderVer1
        {
            public byte one;
            public int dataLen;
            public int dataCrc;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PacketHeaderVer2
        {
            public int flags;
            public int seq;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct PacketDataVer1
        {
            public int code;
            public byte[] data;
        }
    }
}
