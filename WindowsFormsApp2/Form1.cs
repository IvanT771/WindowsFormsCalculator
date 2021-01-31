using System;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool isPoint = false;
        public bool isNum2 = false;

        private string num1 = null;
        private string num2 = null;

        private string currentOperation = "";      

        private void AddNum(string txt) //Установка значения для текущего числа
        {
            if (isNum2)
            {
                num2 += txt;
                textBoxResult.Text=num2;
            }
            else
            {
                num1 += txt;
                textBoxResult.Text = num1;
            }
        }

        private void SetNum(string txt)
        {
            if (isNum2)
            {
                num2 = txt;
                textBoxResult.Text = num2;
            }
            else
            {
                num1 = txt;
                textBoxResult.Text = num1;
            }
        }
        private void buttonNumberClick(object obj, EventArgs e)
        {
            var txt = ((Button)obj).Text;

            if (isPoint && txt == ",") { return; }
            if(txt == ",") { isPoint = true; }

            AddNum(txt);
        }
    
        private void OutputResult(string result, string operation)
        {
            if(result == null) { return;}

                switch (operation)
                {
                    case "√": { textBoxHistory.Text = "√" + num1 + " = "; break; }
                    case "x²": { textBoxHistory.Text = num1+ "²" + " = "; break; }
                    case "1/x": { textBoxHistory.Text = "1/" + num1 + " = "; break; }
                default: { textBoxHistory.Text = num1 + " " + operation + " " + num2 + " = "; break;}
                }
                
                num2 = null;
           
                textBoxResult.Text = result; //Выводим результат               
        } 
        
        private void SetResult(string operation)
        {
            string result = null;

            switch (operation)
            {
                case "+": { result = MathOperation.Add(num1, num2); break; }
                case "-": { result = MathOperation.Sub(num1, num2); break; }
                case "x": { result = MathOperation.Mul(num1, num2); break; }
                case "÷": { result = MathOperation.Dev(num1, num2); break; }
                case "√": { result = MathOperation.Sqr(num1);  break; }
                case "x²": { result = MathOperation.Pow(num1); break; }
                case "1/x": { result = MathOperation.OneDev(num1); break; }
                default: break;
            }

            if(result != null) 
            { 
            OutputResult(result, operation);
            num1 = result; 
            }
        }
        private void ChoiceOperation(string operation)
        {
            SetResult(operation);
            isPoint = false; //Разрешаем ставить запятую
        }
        private void buttonOperationClick(object obj, EventArgs e)
        {
            if(num1 == null) { return;}

            isNum2 = true;
            currentOperation = ((Button)obj).Text;

            ChoiceOperation(currentOperation);
             
        }
        //button "="
        private void button3_Click(object sender, EventArgs e)
        {
            ChoiceOperation(currentOperation);
        }

        //button clear
        private void button22_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            textBoxHistory.Text = "";
            isNum2 = false;
            currentOperation = null;
            num1 = null;
            num2 = null;
            isPoint = false;
        }

        //Button "<--"
        private void button23_Click(object sender, EventArgs e)
        {
            if(textBoxResult.Text.Length <= 0) { return;}
            textBoxResult.Text = textBoxResult.Text.Substring(0, textBoxResult.Text.Length-1);
            SetNum(textBoxResult.Text);
        }
    }
}
