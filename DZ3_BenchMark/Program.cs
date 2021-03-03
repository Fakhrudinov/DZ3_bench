using System;
using System.Collections.Generic;
using System.Threading;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace DZ3_BenchMark
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * Alerxander Fakhrudinov = Александр Фахрудинов
             * asbuka@gmail.com
             * 
             * Протестируйте разные методы расчёта дистанции
             * Напишите тесты производительности для расчёта дистанции между точками с помощью BenchmarkDotNet. 
             * Рекомендуем сгенерировать заранее массив данных, чтобы расчёт шёл с различными значениями, 
             * но сам код генерации должен происходить вне участка кода, время которого будет тестироваться.
             * 
             * Для каких методов потребуется написать тест:
             * 1.	Обычный метод расчёта дистанции со ссылочным типом (PointClass — координаты типа float).
             * 2.	Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа float).
             * 3.	Обычный метод расчёта дистанции со значимым типом (PointStruct — координаты типа double).
             * 4.	Метод расчёта дистанции без квадратного корня со значимым типом (PointStruct — координаты типа float).
             */

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }

    public class ClassFloat
    {
        public float X { get; set; }
        public float Y { get; set; }
    }


    public struct StructFloat
    {
        public float X { get; set; }
        public float Y { get; set; }
    }


    public struct StructDouble
    {
        public double X { get; set; }
        public double Y { get; set; }
    }


    public class BechmarkClass
    {
        public static float CalcClassDistanceFloat(ClassFloat point1, ClassFloat point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static float CalcStructDistanceFloat(StructFloat point1, StructFloat point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        public static double CalcStructDistanceDouble(StructDouble point1, StructDouble point2)
        {
            double x = point1.X - point2.X;
            double y = point1.Y - point2.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        public static float CalcStructDistanceFloatShort(StructFloat point1, StructFloat point2)
        {
            float x = point1.X - point2.X;
            float y = point1.Y - point2.Y;
            return (x * x) + (y * y);
        }


        [Params(2345234213.12F, 0.00000002F, 1)]
        public float setX_float { get; set; }
        public double setX_double{ get; set; }

        [Params(456345634.99F, 0.00000012F, 1)]
        public float setY_float { get; set; }
        public double setY_double { get; set; }

        [Benchmark]
        public void GetDistanceFromClassFloat()
        {
            var pointEnd = new ClassFloat() { X = setX_float, Y = setY_float };
            var pointStart = new ClassFloat() { X = 42.6498F, Y = 42.12385612F };

            CalcClassDistanceFloat(pointStart, pointEnd);
        }


        [Benchmark]
        public void GetDistanceFromStructFloat()
        {
            var pointEnd = new StructFloat() { X = setX_float, Y = setY_float };
            var pointStart = new StructFloat() { X = 42.6498F, Y = 42.12385612F };

            CalcStructDistanceFloat(pointStart, pointEnd);
        }

        [Benchmark]
        public void GetDistanceFromStructDouble()
        {
            var pointEnd = new StructDouble() { X = setX_double, Y = setY_double };
            var pointStart = new StructDouble() { X = 42.6498, Y = 42.12385612 };

            CalcStructDistanceDouble(pointStart, pointEnd);
        }

        [Benchmark]
        public void GetDistanceFromStructFloatShort()
        {
            var pointEnd = new StructFloat() { X = setX_float, Y = setY_float };
            var pointStart = new StructFloat() { X = 42.6498F, Y = 42.12385612F };

            CalcStructDistanceFloatShort(pointStart, pointEnd);

        }
    }

}
