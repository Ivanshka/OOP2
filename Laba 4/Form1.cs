using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_1
{
    public partial class Form1 : Form
    {
        enum CalcState { Write, NeedToClear, Not, Xor, And, Or }
        static CalcState WriteState = CalcState.Write;
        static CalcState ActionState;

        static int a;
        static int b;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            output.Text = "";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (WriteState != CalcState.Write)
            {
                output.Text = "";
                WriteState = CalcState.Write;
            }
            output.Text += "0";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (WriteState != CalcState.Write)
            {
                output.Text = "";
                WriteState = CalcState.Write;
            }
            output.Text += "1";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (WriteState != CalcState.Write)
            {
                output.Text = "";
                WriteState = CalcState.Write;
            }
            output.Text += "2";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (WriteState != CalcState.Write)
            {
                output.Text = "";
                WriteState = CalcState.Write;
            }
            output.Text += "3";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (WriteState != CalcState.Write)
            {
                output.Text = "";
                WriteState = CalcState.Write;
            }
            output.Text += "4";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (WriteState != CalcState.Write)
            {
                output.Text = "";
                WriteState = CalcState.Write;
            }
            output.Text += "5";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (WriteState != CalcState.Write)
            {
                output.Text = "";
                WriteState = CalcState.Write;
            }
            output.Text += "6";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (WriteState != CalcState.Write)
            {
                output.Text = "";
                WriteState = CalcState.Write;
            }
            output.Text += "7";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (WriteState != CalcState.Write)
            {
                output.Text = "";
                WriteState = CalcState.Write;
            }
            output.Text += "8";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (WriteState != CalcState.Write)
            {
                output.Text = "";
                WriteState = CalcState.Write;
            }
            output.Text += "9";
        }

        private void button4_Click(object sender, EventArgs e) => ActionClick(CalcState.Not);
        private void button3_Click(object sender, EventArgs e) => ActionClick(CalcState.And);
        private void button5_Click(object sender, EventArgs e) => ActionClick(CalcState.Xor);
        private void button2_Click(object sender, EventArgs e) => ActionClick(CalcState.Or);

        private void ActionClick(CalcState state)
        {
            if (output.Text.Contains('\n'))
            {
                output.Text = "Неверные данные!";
                WriteState = CalcState.NeedToClear;
                return;
            }
            try
            {
                if (state == CalcState.Not)
                {
                    output.Text = Calculator.Not(Convert.ToInt32(output.Text));
                    WriteState = CalcState.NeedToClear;
                    return;
                }
                a = Convert.ToInt32(output.Text);
                ActionState = state;
                WriteState = CalcState.NeedToClear;
            }
            catch
            {
                output.Text = "Неверные данные!";
                WriteState = CalcState.NeedToClear;
                return;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                b = Convert.ToInt32(output.Text);
                switch (ActionState)
                {
                    case CalcState.And: output.Text = Calculator.And(a, b); break;
                    case CalcState.Or: output.Text = Calculator.Or(a, b); break;
                    case CalcState.Xor: output.Text = Calculator.Xor(a, b); break;
                }
                WriteState = CalcState.NeedToClear;
            }
            catch
            {
                output.Text = "Неверные данные!";
                Thread.Sleep(1000);
                output.Text = a.ToString();
                ActionClick(WriteState);
                return;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            new Form2().ShowDialog();
        }
    }
}
