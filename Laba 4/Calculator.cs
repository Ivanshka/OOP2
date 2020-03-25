using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba_1
{
    static class Calculator
    {
        public static string And(int a, int b) => ToString(a & b);
        public static string Or(int a, int b) => ToString(a | b);
        public static string Not(int a) => ToString(~a);
        public static string Xor(int a, int b) => ToString(a ^ b);
        static string ToString(int a) => $"  2: {Convert.ToString(a, 2)}{Environment.NewLine}  8: {Convert.ToString(a, 8)}{Environment.NewLine}10: {a}{Environment.NewLine}16: {Convert.ToString(a, 16)}";
    }
}
