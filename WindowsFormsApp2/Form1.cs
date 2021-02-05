using System;
using System.Drawing;
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
        private bool isNum2 = false;

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

            { 
                if (isPoint && txt == ",") { return; }
                if(txt == ",") { isPoint = true; }
            }

           
            if(txt == "+/-" )
            {
                if(textBoxResult.Text.Length > 0)
                if(textBoxResult.Text[0] == '-') 
                { 
                   textBoxResult.Text = textBoxResult.Text.Substring(1, textBoxResult.Text.Length-1);
                }else
                {
                   textBoxResult.Text ="-" +textBoxResult.Text;
                } 
                SetNum(textBoxResult.Text);
                return;
            }

            AddNum(txt);

        }
    
        private void OutputResult(string result, string operation)
        {

                switch (operation)
                {
                    case "√": { if(num1!=null)textBoxHistory.Text = "√" + num1 + " = "; break; }
                    case "x²": { if (num1 != null) textBoxHistory.Text = num1+ "²" + " = "; break; }
                    case "1/x": { if (num1 != null) textBoxHistory.Text = "1/" + num1 + " = "; break; }
                    default:  { 
                        if(num2 != null)
                        textBoxHistory.Text = num1 + " " + operation + " " + num2 + " = ";
                        else
                            if(num1 != null)
                        textBoxHistory.Text = num1 + " " + operation + " ";
                        break; }
                }
                
                num2 = null;
            if (result != null) { 
                textBoxResult.Text = result; } //Выводим результат               
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
                case "√": { result = MathOperation.Sqr(num1); isNum2 = false; break; }
                case "x²": { result = MathOperation.Pow(num1); isNum2 = false; break; }
                case "1/x": { result = MathOperation.OneDev(num1); isNum2 = false; break; }
                default: break;
            }

            OutputResult(result, operation);

            if (isNum2 ){ if(result != null) num1 = result; } else { num1 = null;}
            isPoint = false; //Разрешаем ставить запятую
        }
       
        private void buttonOperationClick(object obj, EventArgs e)
        {
            if(num1 == null) {if(textBoxResult.Text.Length>0) num1 = textBoxResult.Text; else return;}

            isNum2 = true;
            currentOperation = ((Button)obj).Text;

            SetResult(currentOperation);
             
        }
        //button "="
        private void button3_Click(object sender, EventArgs e)
        {
            SetResult(currentOperation);
            isNum2 = false;
            num1 = null;
            num2 = null;
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

        private void button24_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool isMove = false;
        private Point currentPosition = new Point(0,0);
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            isMove = true;
            currentPosition = new Point(e.X,e.Y);
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            isMove = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isMove) { return;}
            Point tmp = new Point(this.Location.X,this.Location.Y);
            tmp.X+=e.X-currentPosition.X;
            tmp.Y+=e.Y-currentPosition.Y;
            this.Location = tmp;

        }
    }
}
