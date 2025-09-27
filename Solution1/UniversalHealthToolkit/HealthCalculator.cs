using System;
using System.Globalization;

namespace UniversalHealthToolkit
{
    public sealed class HealthCalculator
    {
        private double _weightKg;
        private double _heightCm;
        private int _age;
        private char _sex;

        public HealthCalculator() { _sex = 'M'; }

        public double WeightKg { get { return _weightKg; } set { _weightKg = value; } }
        public double HeightCm { get { return _heightCm; } set { _heightCm = value; } }
        public int Age { get { return _age; } set { _age = value; } }
        public char Sex { get { return _sex; } set { _sex = (value == 'F' || value == 'f') ? 'F' : 'M'; } }

        // Tính BMI
        public double ComputeBmi()
        {
            if (_heightCm <= 0 || _weightKg <= 0) return 0.0;
            double hM = _heightCm / 100.0;
            return _weightKg / (hM * hM);
        }

        public double ComputeBmiRounded(int decimals)
        {
            return Math.Round(ComputeBmi(), decimals);
        }

        // Phân loại BMI
        public string GetBmiCategory()
        {
            double bmi = ComputeBmi();
            if (bmi <= 0) return "N/A";
            if (bmi < 18.5) return "Thiếu cân";
            if (bmi < 25.0) return "Bình thường";
            if (bmi < 30.0) return "Thừa cân";
            if (bmi < 35.0) return "Béo phì độ I";
            if (bmi < 40.0) return "Béo phì độ II";
            return "Béo phì độ III";
        }

        // BMR
        public double ComputeBmr()
        {
            if (_weightKg <= 0 || _heightCm <= 0 || _age <= 0) return 0.0;
            double s = (_sex == 'M') ? 5.0 : -161.0;
            return 10.0 * _weightKg + 6.25 * _heightCm - 5.0 * _age + s;
        }

        // Gợi ý calo
        public CaloriePlan SuggestCalories(double activityFactor)
        {
            double bmr = ComputeBmr();
            if (bmr <= 0) return new CaloriePlan();
            if (activityFactor <= 0) activityFactor = 1.2;
            double tdee = bmr * activityFactor;
            CaloriePlan plan = new CaloriePlan();
            plan.Maintain = Math.Round(tdee);
            plan.CutSlow = Math.Round(tdee - 300);
            plan.CutFast = Math.Round(tdee - 600);
            plan.BulkSlow = Math.Round(tdee + 200);
            plan.BulkFast = Math.Round(tdee + 400);
            return plan;
        }

        // Lời khuyên
        public string GetAdvice()
        {
            string cat = GetBmiCategory();
            switch (cat)
            {
                case "Thiếu cân":
                    return "Bạn đang thiếu cân, nên bổ sung dinh dưỡng và tập luyện để tăng cân lành mạnh.";
                case "Bình thường":
                    return "Chỉ số BMI bình thường, hãy duy trì chế độ ăn uống và luyện tập cân đối.";
                case "Thừa cân":
                    return "Bạn thừa cân, nên kiểm soát khẩu phần và tăng cường vận động.";
                case "Béo phì độ I":
                case "Béo phì độ II":
                case "Béo phì độ III":
                    return "Bạn bị béo phì, nên tham khảo ý kiến bác sĩ và điều chỉnh lối sống ngay.";
                default:
                    return "Không xác định được tình trạng sức khoẻ.";
            }
        }

        public string PersonalSignature()
        {
            return "@minhluong";
        }

        // Snapshot
        public HealthSnapshot BuildSnapshot(double activityFactor)
        {
            HealthSnapshot snap = new HealthSnapshot();
            snap.Bmi = ComputeBmiRounded(2);
            snap.BmiCategory = GetBmiCategory();
            snap.Bmr = Math.Round(ComputeBmr());
            snap.Plan = SuggestCalories(activityFactor);
            snap.Advice = GetAdvice();
            snap.Sign = PersonalSignature();
            return snap;
        }

       
        public string ToJson(HealthSnapshot s)
        {
            return "{"
                + "\"bmi\":" + s.Bmi.ToString(CultureInfo.InvariantCulture)
                + ",\"bmiCategory\":\"" + Escape(s.BmiCategory) + "\""
                + ",\"bmr\":" + s.Bmr.ToString(CultureInfo.InvariantCulture)
                + ",\"plan\":{"
                    + "\"maintain\":" + s.Plan.Maintain.ToString(CultureInfo.InvariantCulture)
                    + ",\"cutSlow\":" + s.Plan.CutSlow.ToString(CultureInfo.InvariantCulture)
                    + ",\"cutFast\":" + s.Plan.CutFast.ToString(CultureInfo.InvariantCulture)
                    + ",\"bulkSlow\":" + s.Plan.BulkSlow.ToString(CultureInfo.InvariantCulture)
                    + ",\"bulkFast\":" + s.Plan.BulkFast.ToString(CultureInfo.InvariantCulture)
                + "}"
                + ",\"advice\":\"" + Escape(s.Advice) + "\""
                + ",\"sign\":\"" + Escape(s.Sign) + "\""
                + "}";
        }

        private static string Escape(string s)
        {
            if (s == null) return "";
            return s.Replace("\\", "\\\\").Replace("\"", "\\\"");
        }
    }

    public sealed class CaloriePlan
    {
        public double Maintain;
        public double CutSlow;
        public double CutFast;
        public double BulkSlow;
        public double BulkFast;
    }

    public sealed class HealthSnapshot
    {
        public double Bmi;
        public string BmiCategory;
        public double Bmr;
        public CaloriePlan Plan;
        public string Advice;
        public string Sign;
    }
}
