using System;


namespace WindowsFormsApp2
{
   public static class MathOperation
    {
        private static double ConvertToDouble(string numStr)
        {
            double number;
            try
            {
                number = Convert.ToDouble(numStr);
            }
            catch (Exception)
            {

                number = 0;
            }
            return number;
        }
        public static string Add(string num1, string num2)
        {
            if(num1==null || num2 == null) { return null;}
            double result = ConvertToDouble(num1) + ConvertToDouble(num2);
            return result.ToString();
        }

        public static string Sub(string num1, string num2)
        {
            if (num1 == null || num2 == null) { return null; }
            double result = ConvertToDouble(num1) - ConvertToDouble(num2);
            return result.ToString();
        }

        public static string Mul(string num1, string num2)
        {
            if (num1 == null || num2 == null) { return null; }
            double result = ConvertToDouble(num1) * ConvertToDouble(num2);
            return result.ToString();
        }

        public static string Dev(string num1, string num2)
        {
            if (num1 == null || num2 == null) { return null; }
            double b = ConvertToDouble(num2);
            if (b == 0) { return "Попытка деления на 0!";}
            return (ConvertToDouble(num1)/b).ToString();
        }

        public static string Sqr(string num1)
        {
            if (num1 == null) { return null; }
            double b = ConvertToDouble(num1);
            b = Math.Sqrt(b);
            return b.ToString();
        }
        public static string Pow(string num1)
        {
            if (num1 == null) { return null; }
            double b = ConvertToDouble(num1);
            return (b*b).ToString();

        }

        public static string OneDev(string num1)
        {
            if (num1 == null) { return null; }
            double b = ConvertToDouble(num1);
            if(b == 0) { return "Попытка деления на 0!";}
            return (1/b).ToString();
        }
    }
}
