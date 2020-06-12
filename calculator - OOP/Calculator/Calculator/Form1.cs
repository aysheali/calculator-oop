using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        double resultValue = 0;
        string operation = "";
        bool isOperationCompleted = false;
        double memory = 0;
        string expression = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void button_click(object sender, EventArgs e)
        {
            if ((Result.Text == "0") || (isOperationCompleted))
                Result.Clear();
            isOperationCompleted = false;
            Button button = (Button)sender;
            if (button.Text == ",")
            {
                if (!Result.Text.Contains(","))
                    Result.Text = Result.Text + button.Text;
            }
            else
                Result.Text = Result.Text + button.Text;
            expression += button.Text;
        }

        private void CalculateOperation()
        {
            switch (operation)
            {
                case "+":
                    Result.Text = (resultValue + double.Parse(Result.Text)).ToString();
                    break;
                case "-":
                    Result.Text = (resultValue - double.Parse(Result.Text)).ToString();
                    break;
                case "*":
                    Result.Text = (resultValue * double.Parse(Result.Text)).ToString();
                    break;
                case "/":
                    Result.Text = (resultValue / double.Parse(Result.Text)).ToString();
                    break;
                default:
                    break;
            }
            resultValue = double.Parse(Result.Text);
            calculation.Text = " ";
        }

        private void operator_click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValue != 0)
            {
                expression += button.Text;

                CalculateOperation();
                operation = button.Text;
                calculation.Text = resultValue + " " + operation;
                isOperationCompleted = true;

            }
            else
            {
                expression += button.Text;
                operation = button.Text;
                resultValue = double.Parse(Result.Text);
                calculation.Text = resultValue + " " + operation;
                isOperationCompleted = true;

            }
        }

        private void Erase_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            Result.Text = "0";
            resultValue = 0;
            calculation.Text = "";
        }

        private void Equal_Click(object sender, EventArgs e)
        {
            CalculateOperation();
            expression += $"= {resultValue}";
            listBox1.Items.Add(expression);
            expression = "";
            resultValue = 0;
        }

        private void Percent_Click(object sender, EventArgs e)
        {
            Result.Text = (double.Parse(Result.Text) / 100).ToString();
        }


        private void MCbutton_Click(object sender, EventArgs e)
        {
            memory = 0;
            Result.Text = "0";
        }

        private void MRbutton_Click(object sender, EventArgs e)
        {
            Result.Text = memory.ToString();
        }

        private void MPbutton_Click(object sender, EventArgs e)
        {
            memory = memory + double.Parse(Result.Text);
            Result.Text = "0";
        }

        private void MMbutton_Click(object sender, EventArgs e)
        {
            memory = memory - double.Parse(Result.Text);
            Result.Text = "0";
        }
    }
}
