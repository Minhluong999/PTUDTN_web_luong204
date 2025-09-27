using System;
using System.Windows.Forms;
using UniversalHealthToolkit;

namespace BmiDesktop
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            try
            {
                double w = double.Parse(txtWeight.Text);
                double h = double.Parse(txtHeight.Text);
                int age = int.Parse(txtAge.Text);
                double act = double.Parse(txtAct.Text);
                char sex = rbM.Checked ? 'M' : 'F';

                HealthCalculator hc = new HealthCalculator();
                hc.WeightKg = w;
                hc.HeightCm = h;
                hc.Age = age;
                hc.Sex = sex;

                HealthSnapshot s = hc.BuildSnapshot(act);

                lblOut.Text = "Chỉ số BMI: " + s.Bmi + " → " + s.BmiCategory + "\n"
                    + "Chỉ số BMR: " + s.Bmr + " kcal/ngày\n"
                    + "TDEE (duy trì): " + s.Plan.Maintain + " kcal/ngày\n"
                    + "Lời khuyên: " + s.Advice + "\n"
                    + s.Sign;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi nhập liệu: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
