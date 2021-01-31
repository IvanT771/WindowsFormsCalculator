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
        public bool isOperation = false;

        private string num1 = null;
        private string num2 = null;

        private string currentOperation = "";      

        private void AddNum(string txt) //Установка значения для текущего числа
        {
            if (isOperation)
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
            if (isOperation)
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
    
        private void OutputResult(string result, bool isSingle, string operation)
        {
            if(result == null) { return;}

            if (!isSingle) //Если оперируем с двумя числами 
            {
                textBoxHistory.Text = num1 + " " + operation + " " + num2+" = ";
                num1 = result; //Записываем в первое число полученный результат
                num2 = null; //Aнулируем второе число
            }
            else 
            {
                textBoxHistory.Text = operation + num1 + " = ";
                isOperation = false;
                num1 = null;
                num2 = null;
            }
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
                case "√": { result = MathOperation.Sqr(num1); isOperation = false; break; }
                case "x²": { result = MathOperation.Pow(num1); isOperation = false; break; }
                case "1/x": { result = MathOperation.OneDev(num1); isOperation = false; break; }
                default: break;
            }
            num1 = result;
            num2 = null;
            if(result != null)
            textBoxResult.Text = result;
        }
        private void ChoiceOperation(string operation)
        {
            string result = null;
            bool isSingleOperation = false; //Работаем с одним числом или двумя


            if (num1 == null) { num1 = textBoxResult.Text;}
            textBoxHistory.Text=num1+" "+operation+" ";
            
            switch (operation)
            {
                case "+": { result =  MathOperation.Add(num1,num2); break; }
                case "-": { result =  MathOperation.Sub(num1,num2); break; }
                case "x": { result =  MathOperation.Mul(num1,num2); break; }
                case "÷": { result =  MathOperation.Dev(num1,num2); break; }
                case "√": { result =  MathOperation.Sqr(num1); isSingleOperation = true; isOperation = false; break; }
                case "x²": { result =  MathOperation.Pow(num1); isSingleOperation = true; isOperation = false; break; }
                case "1/x": { result =  MathOperation.OneDev(num1); isSingleOperation = true; isOperation = false; break; }
                default: break;
            }
                OutputResult(result,isSingleOperation, operation);
                isPoint = false; //Разрешаем ставить запятую
        }
        private void buttonOperationClick(object obj, EventArgs e)
        {
            if(currentOperation != null)
            {
                SetResult(currentOperation);
            }
            isOperation = true;
            currentOperation = ((Button)obj).Text;
            ChoiceOperation(((Button)obj).Text);
             
        }
        //button "="
        private void button3_Click(object sender, EventArgs e)
        {
            ChoiceOperation(currentOperation);
            currentOperation = null;
        }

        //button clear
        private void button22_Click(object sender, EventArgs e)
        {
            textBoxResult.Text = "";
            textBoxHistory.Text = "";
            isOperation = false;
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
