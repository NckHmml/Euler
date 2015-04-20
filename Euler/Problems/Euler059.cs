using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler.Problems
{
    public static class Euler059
    {
        public static string Run()
        {
            string text = File.ReadAllText("p059_cipher.txt");
            var bytes = text.Split(',').Select(x => byte.Parse(x));

            const char start = 'a';
            const char end = 'z';

            // Use a list, as we do not know the count of bytes.
            // This so we are able to use the speed gain of IENumerable.
            List<byte> decrypted = new List<byte>();
            for (char first = start; first <= end; first++)
            {
                for (char second = start; second <= end; second++)
                {
                    for (char third = start; third <= end; third++)
                    {
                        int i = 0;
                        bool broke = false;
                        foreach (byte b in bytes)
                        {
                            byte dec = b;
                            if ((i % 3) == 0)
                                dec ^= (byte)first;
                            else if (((i + 1) % 3) == 0)
                                dec ^= (byte)second;
                            else if (((i + 2) % 3) == 0)
                                dec ^= (byte)third;
                            if (!IsValidChar(dec))
                            {
                                broke = true;
                                break;
                            }
                            if (decrypted.Count <= i)
                                decrypted.Add(dec);
                            else
                                decrypted[i] = dec;
                            i++;
                        }
                        if (!broke)
                        {
                            Console.WriteLine(Encoding.ASCII.GetString(decrypted.ToArray()));
                            return decrypted.Sum(x => x).ToString();
                        }
                    }
                }
            }
            return "Not found!";
        }

        public static bool IsValidChar(byte b)
        {
            if (b < 0x20) // Lower ASCII boundry
                return false;
            if (b > 0x7A) // Upper ASCII boundry
                return false;
            if (b == 0x23 || b == 0x2F) // # /
                return false;
            return true;
        }
    }
}
