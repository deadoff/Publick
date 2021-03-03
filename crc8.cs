using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CRC8Calc
{

    public byte Checksum(params byte[] val)
    {

        int crl = 0;
        int crlDec = 0;
        String crlS = "00000000";
        String cf = "0";
        String cfNew = "0";
        String byteS = "";

        foreach (byte b in val)
        {
            byteS = Convert.ToString(b, 2).PadLeft(8, '0');
            for (int j = 0; j < 8; ++j)
            {
                cf = byteS.Substring(0, 1);
                byteS = byteS.Substring(1, byteS.Length - 1) + cf;

                cfNew = crlS.Substring(0, 1);
                crlS = crlS.Substring(1, byteS.Length - 1) + cf;
                cf = cfNew;

                if (cf.Trim() != "0")
                {
                    crlDec = Convert.ToInt32(crlS, 2);
                    crlDec = crlDec ^ (int)0x69;
                    crlS = Convert.ToString(crlDec, 2).PadLeft(8, '0');
                }

                else
                {
                    crlDec = Convert.ToInt32(crlS, 10);
                }
            }

        }

        crl = crlDec;

        return (byte)crl;
    }

}