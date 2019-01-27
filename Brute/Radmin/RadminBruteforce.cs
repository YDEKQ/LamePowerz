/* 
   LamePowerz (C) Dz3n 2019
   GitHub: https://github.com/feel-the-dz3n/lamepowerz
   
   File: RadminBruteforce.cs
   Why:  Bruteforce tool for Radmin.

         Based on Lamescan source code.
         Lamescan by redsh
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace LamePowerz.Brute
{
    public class Radmin
    {
        public const int MaxDataBlock = 1048576;

        public enum RadminAuth
        {
            Unknown,
            Native_2,
            NTLM_2,
            None_2,
            Native_3,
            NTLM_3,
            None_3,
        }

        public enum RadminStatus
        {
            Error,
            Success,
            ProtoErr,
            PassErr,
            NameErr,
            AlgoErr
        }

        /// <summary>
        /// Tasks examples for Help
        /// </summary>
        public static string[] Tasks =
        {
            "brute \"cfg=FileName\" ",
            "brute \"ip=FileNameOrSingleIp\" *\"threads=5\" *\"timeout=5000\""
        };

        public static bool CheckCombination(string host, int port, string UserName, string Password, int Timeout = 2000)
        {
            var Version = GetVersion(host, port, Timeout);

            return false;
        }

        private static RadminAuthInfo GetVersion(string host, int port, int timeout = 2000)
        {
            RadminAuthInfo radmin = new RadminAuthInfo();
            RadminPackets.PacketVer1 request = new RadminPackets.PacketVer1(), response = new RadminPackets.PacketVer1();

            TcpClient tcp = new TcpClient()
            {
                ReceiveTimeout = timeout,
                SendTimeout = timeout
            };

            tcp.Connect(host, port);

            request.code = 0x08;
            request.datalen = 0;
            request.data = null;

            SendPacketVer1(tcp, request);

            tcp.Close();

            return radmin;
        }

        private static bool ReceivePacketVer1(TcpClient client, out RadminPackets.PacketVer1 response)
        {
            bool status = false;
            int blocklen, datalen;
            response = new RadminPackets.PacketVer1();

            RadminPackets.PacketHeaderVer1 header = new RadminPackets.PacketHeaderVer1();
            RadminPackets.PacketDataVer1 block = new RadminPackets.PacketDataVer1();

            response.code = 0;
            response.datalen = 0;
            response.data = null;

            byte[] buffer = GetBytesFromTcp(client);
            header = ByteTools.ByteArrayToStructure<RadminPackets.PacketHeaderVer1>(buffer);



            return status;
        }

        private static byte[] GetBytesFromStream(NetworkStream stream)
        {
            List<byte> buffer = new List<byte>();

            while (true)
            {
                int b = stream.ReadByte();

                if (b == -1)
                    break;

                buffer.Add((byte)b);
            }

            return buffer.ToArray();
        }

        private static byte[] GetBytesFromTcp(TcpClient client)
        {
            using (var stream = client.GetStream())
            {
                return GetBytesFromStream(stream);
            }
        }

        private static bool SendPacketVer1(TcpClient client, RadminPackets.PacketVer1 packet)
        {
            bool status = false;
            RadminPackets.PacketHeaderVer1 header = new RadminPackets.PacketHeaderVer1();
            RadminPackets.PacketDataVer1 block = new RadminPackets.PacketDataVer1();

            block.code = packet.code;
            header.one = 1;

            using (var stream = client.GetStream())
            { 
                byte[] headerBytes = ByteTools.ToByteArray(header);
                stream.Write(headerBytes, 0, headerBytes.Length);

                byte[] blockBytes = ByteTools.ToByteArray(block);
                stream.Write(blockBytes, 0, blockBytes.Length);

                status = true;
            }

            return status;
        }

        public static int GetPasswordMinLen(Version ver)
        {
            if (ver.Major == 2)
                return 8;
            else if (ver.Major == 3)
                return 6;

            else return 0;
        }
    }
    public class RadminAuthInfo
    {
        public Version version = new Version(0, 0);
        public Radmin.RadminAuth Auth = Radmin.RadminAuth.Unknown;
    }
}
