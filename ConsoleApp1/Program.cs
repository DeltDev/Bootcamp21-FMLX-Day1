using System;
using System.Numerics;
using System.Security.Cryptography;

namespace Test
{
    public struct Vector3Struct {public double X,Y,Z;}

    class Vector3Class
    {
        public double X{get; set;}
        public double Y {get; set;}
        public double Z {get; set;}
    }

    class Program
    {
        static void Main()
        {
            //struct vs class difference

            // di struct, yang dipass ke variabel lain adalah nilai asli sehingga nilai
            //p1structnya tidak berubah
            Vector3Struct p1Struct = new()
            {
                X = 7.8,
                Y = 8,
                Z = 6.7
            };

            Vector3Struct p2Struct = p1Struct;
            p2Struct.X = 3;

            Console.WriteLine("p1Struct X: {0}",p1Struct.X);
            Console.WriteLine("p2Struct X: {0}",p2Struct.X);

            Vector3Class p1Class = new()
            {
                X = 7.8,
                Y = 8,
                Z = 6.7
            };
            // di class, yang dipass ke variabel lain adalah object reference sehingga nilai
            //p1classnya berubah
            Vector3Class p2Class = p1Class;
            p2Class.X = 3;
            Console.WriteLine("p1Class X: {0}",p1Class.X);
            Console.WriteLine("p2Class X: {0}",p2Class.X);
        }
    }
}