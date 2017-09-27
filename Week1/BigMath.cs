using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Week1
{
    public static class BigMath
    {
        public static string Multiply(string m1, string m2)
        {
            int sizeM1 = m1.Length,
                sizeM2 = m2.Length,
                maxSize = Math.Max(sizeM1, sizeM2),
                splitSize = Raise2ToThePowerOf((int)(Math.Ceiling(Math.Log(maxSize,2)) - 1));
            string a, b, c, d, ac, bd, ad, bc, acSuffix, adbcSuffix;
            if ((sizeM1 < 2) && (sizeM2 < 2)){
                return (Int32.Parse(m1) * Int32.Parse(m2)).ToString();
            }
            else
            {
                if (sizeM1 > splitSize)
                {
                    a = m1.Substring(0, sizeM1 - splitSize);
                    b = m1.Substring(sizeM1 - splitSize, splitSize);
                }
                else
                {
                    a = "0";
                    b = m1;
                }
                if (sizeM2 > splitSize)
                {
                    c = m2.Substring(0, sizeM2 - splitSize);
                    d = m2.Substring(sizeM2 - splitSize, splitSize);
                }
                else
                {
                    c = "0";
                    d = m2;
                }
                ac = Multiply(a, c);
                bd = Multiply(b, d);
                ad = Multiply(a, d);
                bc = Multiply(b, c);
                acSuffix = new string('0', 2*splitSize);
                adbcSuffix = new string('0', splitSize);
                string acPart = ac == "0" ? "0" : ac + acSuffix;
                return Add(Add(acPart,bd),Add(ad+adbcSuffix, bc+adbcSuffix));
            }
        }

        private static int Raise2ToThePowerOf(int exponent)
        {
            return 1 << exponent;
        }

        public static string Add(string a, string b)
        {
            if (a.Length >= b.Length) { return OrderedAdd(a, b); }
            else { return OrderedAdd(b, a); };
        }

        private static string OrderedAdd(string a, string b)
        {
            if (a=="0") { return b; };
            if (b=="0") { return a; };
            int sizeA = a.Length,
                sizeB = b.Length,
                maxResult = sizeA+1;

            char[] charArrayA = ReverseCharArray(a.ToCharArray()),
                    charArrayB = ReverseCharArray(b.ToCharArray()),
                    temp = new char[maxResult];

            for (int i=0; i<sizeA; i+=1)
            {
                temp[i] = charArrayA[i];
            }
            for (int i = 0; i < sizeB; i+=1) {
                int digitSum = SumChars(temp[i], charArrayB[i]);
                temp[i] = NumToAsciiLastDigit(digitSum);
                int j = 1;
                while (digitSum > 9) {
                    if (temp[i + j] == 0)
                    {
                        temp[i + j] = '1';
                        digitSum = 0;
                    }
                    else
                    {
                        digitSum = SumChars(temp[i + j], '1');
                        temp[i + j] = NumToAsciiLastDigit(digitSum);
                        j += 1;
                    }
                }
            }
            if (temp[maxResult-1] == 0)
            {
                char[] temp2 = new char[maxResult - 1];
                for (int i=0; i<maxResult-1; i+=1)
                {
                    temp2[i] = temp[i];
                }
                return new String(ReverseCharArray(temp2));
            }
            else
            {
                return new String(ReverseCharArray(temp));
            }
        }

        private static char NumToAsciiLastDigit(int num)
        {
            return ReverseCharArray(num.ToString().ToCharArray())[0];
        }

        private static int SumChars(char a, char b)
        {
            return (int)char.GetNumericValue(a) + (int)char.GetNumericValue(b);
        }

        private static char[] ReverseCharArray(char[] input)
        {
            int arraySize = input.Length;
            char[] reversed = new char[arraySize];
            for (int i = 0; i<arraySize; i++)
            {
                reversed[i] = input[arraySize - i - 1];
            }
            return reversed;
        }
    }
}
