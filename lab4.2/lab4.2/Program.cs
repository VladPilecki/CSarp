using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4._2
{
    public class LibImport
    {
        [DllImport("Dll.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, EntryPoint = "Sum")]
        public static extern int Sum1(int a, int b);
        public int Sum(int a, int b)
        {
            return Sum1(a, b);
        }

        [DllImport("Dll.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, EntryPoint = "Sub")]
        public static extern int Sub1(int a, int b);
        public int Sub(int a, int b)
        {
            return Sub1(a, b);
        }

        [DllImport("Dll.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, EntryPoint = "Mult")]
        public static extern int Mult1(int a, int b);
        public int Mult(int a, int b)
        {
            return Mult1(a, b);
        }

        [DllImport("Dll.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, EntryPoint = "Div")]
        public static extern float Div1(int a, int b);
        public float Div(int a, int b)
        {
            return Div1(a, b);
        }

        [DllImport("Dll.dll", CallingConvention = CallingConvention.Cdecl, ExactSpelling = false, EntryPoint = "Mod")]
        public static extern int Mod1(int a, int b);
        public int Mod(int a, int b)
        {
            return Mod1(a, b);
        }




    }
    class Program
    {
        public static int Check()
        {
            int a;
            while (!int.TryParse(Console.ReadLine(), out a))
            {
                Console.Write("Incorrect data, repeat: ");
            }
            return a;
        }
        static void Main(string[] args)
        {
            LibImport import = new LibImport();
            Console.Write("Enter a: ");
            int a = Check();
            Console.Write("Enter b: ");
            int b = Check();
            Console.WriteLine($"a = {a}\nb = {b}");
            Console.WriteLine("a + b = " + import.Sum(a, b));
            Console.WriteLine("a - b = " + import.Sub(a, b));
            Console.WriteLine("a * b = " + import.Mult(a, b));
            Console.WriteLine("a mod b = " + import.Mod(a, b));
            Console.WriteLine("a / b = " + import.Div(a, b));
            Console.ReadLine();
        }
    }
}