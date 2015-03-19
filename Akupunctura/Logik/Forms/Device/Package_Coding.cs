using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace Akupunctura.Logik.Forms.Device
{
    [StructLayoutAttribute(LayoutKind.Explicit, Size = 4)]
    public class bytes
    {
        [FieldOffsetAttribute(3)]
        public byte b1;
        [FieldOffsetAttribute(2)]
        public byte b2;
        [FieldOffsetAttribute(1)]
        public byte b3;
        [FieldOffsetAttribute(0)]
        public byte b4;
        [FieldOffsetAttribute(0)]
        public Int32 Int;
    }

    public class package
    {
        public package(byte[] inp)
        {
            GetInt(inp);
        }
        public package(int inp)
        {
            b = new bytes();
            b.Int = inp;
        }
        bool _isI = false;
        public bool IsI
        {
            get { return _isI; }
        }
        bytes b;
        public int Int_pack
        {
            get { return b.Int; }
        }
        public byte[] Bytes_pack
        {
            get { return GetBytes(b.Int); }
        }
        void GetInt(byte[] inp_arr)
        {
            b = new bytes();
            b.b1 = (byte)(inp_arr[1] & 0x7F); // & 0111 1111
            b.b2 = (byte)(inp_arr[2] & 0x7F); // & 0111 1111
            b.b3 = (byte)(inp_arr[3] & 0x7F); // & 0111 1111
            b.b4 = (byte)(inp_arr[4] & 0x7F); // & 0111 1111
            b.b4 |= (byte)((inp_arr[0] & 0x01) << 7); // & 0000 0001 << 7 // -*** ****
            b.b3 |= (byte)((inp_arr[0] & 0x02) << 6); // & 0000 0010 << 6 // -*** ****
            b.b2 |= (byte)((inp_arr[0] & 0x04) << 5); // & 0000 0100 << 5 // -*** ****
            b.b1 |= (byte)((inp_arr[0] & 0x08) << 4); // & 0000 1000 << 4 // -*** ****
            if ((inp_arr[0] & 0x20) != 0) _isI = true; // **1* **** & 0010 0000 != 0000 0000 (Определение ток или напряжение)
        }

        byte[] GetBytes(int input)
        {
            bytes b = new bytes();
            b.Int = input;
            byte[] output = new byte[5];
            output[0] = (byte)(0x40 | (b.b4 >> 7) & 0x01 | (b.b3 >> 6) & 0x02 | (b.b2 >> 5) & 0x04 | (b.b1 >> 4) & 0x08);
            output[1] = (byte)(b.b1 & 0x7F | 0x80);
            output[2] = (byte)(b.b2 & 0x7F | 0x80);
            output[3] = (byte)(b.b3 & 0x7F | 0x80);
            output[4] = (byte)(b.b4 & 0x7F | 0x80);
            return output;
        }
    }
}
