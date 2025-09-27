using System;
using System.Text;
using UniversalHealthToolkit;

public partial class api : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.ContentEncoding = Encoding.UTF8;

        try
        {
            double w = double.Parse(Request["w"]);
            double h = double.Parse(Request["h"]);
            int age = int.Parse(Request["age"]);
            char sex = Request["sex"][0];
            double act = double.Parse(Request["act"]);

            HealthCalculator hc = new HealthCalculator();
            hc.WeightKg = w;
            hc.HeightCm = h;
            hc.Age = age;
            hc.Sex = sex;

            HealthSnapshot s = hc.BuildSnapshot(act);

            Response.ContentType = "application/json";
            Response.Write(hc.ToJson(s));
        }
        catch (Exception ex)
        {
            Response.ContentType = "application/json";
            Response.Write("{\"error\":\"" + ex.Message.Replace("\"", "'") + "\"}");
        }
        Response.End();
    }
}
