namespace mvc_basic.Models
{
    public static class DoctorModel
    {
        public static string FeverCheck(string temp, string unit)
        {
            // if someone uses .
            double temperature = double.Parse(temp.Replace(".", ","));
            string result = $"Your temperature is {temp}{unit}: ";
            result += unit != "°F" ? temperature > 38 ? "You have a fever."
                : temperature < 35 ? "Your temperature is low, you have hypothermia."
                : "Everything looks in order, normal body temperature."
                : temperature > 99.6 ? "You have a fever."
                : temperature < 95 ? "Your temperature is low, you have hypothermia."
                : "Everything looks in order, normal body temperature.";

            return result;
        }
    }
}