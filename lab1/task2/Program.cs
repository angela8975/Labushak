namespace task2
{
    class Program
    {

        public static void Function(StreamWriter writer, float xmin, float xmax, float dot)
        {
            double y = 0;
            float step = (xmax - xmin) / dot;
            for(float x=xmin; x<=xmax; x += step)
            {
                y = Math.Log(Math.PI) * Math.Sqrt(Math.Pow(x, 3)) + Math.Pow(x, 2);
                writer.WriteLine($"++++++++++++++++++++++++");
                writer.WriteLine($"+ Аргумент +  Функція  +");
                writer.WriteLine($"++++++++++++++++++++++++");
                writer.WriteLine($"+ x= {x, 5:F2} + y= {y, 10:F4} +");
                writer.WriteLine($"++++++++++++++++++++++++");

            }
        }
        static void Main(string[] args)
        {
            const string name = "Лабущак Анжела Володимирівна ";
            string[] lines = File.ReadAllLines(path: "LAB2.txt");
            Console.WriteLine($"Количество строк в файле: {lines.Length}");

            float[] value = new float[lines.Length];
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = float.Parse(lines[i]);
            }
            float y = value[0], x = value[1], xmin = value[2], xmax = value[3];
            float dot = 8;
            using (StreamWriter writer = new StreamWriter(path: "LAB2.RES.txt"))
            {
                Function(writer, xmin, xmax, dot);
                writer.WriteLine($"Таблицю сфорвувала: {name}");
            }


        }
    }
}
