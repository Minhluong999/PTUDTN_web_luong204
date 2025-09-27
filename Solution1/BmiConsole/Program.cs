using System;
using System.Text;
using UniversalHealthToolkit;

namespace BmiConsole
{
    internal static class Program
    {
        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Banner();

            double w = AskDouble("Nhập cân nặng (kg): ");
            double h = AskDouble("Nhập chiều cao (cm): ");
            int age = AskInt("Nhập tuổi: ");
            char sex = AskSex("Giới tính (M/F): ");
            double act = AskDouble("Hệ số vận động ~ 1.2 .. 1.9 (mặc định 1.2): ");
            if (act <= 0) act = 1.2;

            HealthCalculator hc = new HealthCalculator();
            hc.WeightKg = w; hc.HeightCm = h; hc.Age = age; hc.Sex = sex;
            HealthSnapshot s = hc.BuildSnapshot(act);

            Console.WriteLine();
            Console.WriteLine("=== KẾT QUẢ ===");
            Console.WriteLine("Chỉ số BMI: {0} → {1}", s.Bmi, s.BmiCategory);
            Console.WriteLine("Chỉ số BMR: {0} kcal/ngày", s.Bmr);
            Console.WriteLine("TDEE (duy trì): {0} kcal/ngày", s.Plan.Maintain);
            Console.WriteLine("Lời khuyên: {0}", s.Advice);
            Console.WriteLine(s.Sign);

            Console.WriteLine();
            Console.WriteLine("Nhấn Enter để thoát...");
            Console.ReadLine();
        }

        private static void Banner()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\n===============================================");
            Console.WriteLine("      @minhluong  —  Universal Health Console    ");
            Console.WriteLine("===============================================\n");
            Console.ResetColor();
        }

        private static double AskDouble(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                double v;
                if (double.TryParse(s, out v)) return v;
                Console.WriteLine("  >> Vui lòng nhập số hợp lệ!");
            }
        }

        private static int AskInt(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                int v;
                if (int.TryParse(s, out v)) return v;
                Console.WriteLine("  >> Vui lòng nhập số nguyên!");
            }
        }

        private static char AskSex(string prompt)
        {
            while (true)
            {
                Console.Write(prompt);
                string s = Console.ReadLine();
                if (!string.IsNullOrEmpty(s))
                {
                    char c = s[0];
                    if (c == 'M' || c == 'm' || c == 'F' || c == 'f') return c;
                }
                Console.WriteLine("  >> Chỉ nhập M hoặc F!");
            }
        }
    }
}
