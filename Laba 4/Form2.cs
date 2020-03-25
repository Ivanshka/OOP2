using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba_1
{
    public partial class Form2 : Form
    {
        static Collection Col;
        public Form2()
        {
            InitializeComponent();
            Col = new Collection();
            // чтобы избежать исключений из-за действий до
            // генерации коллекции, сразу ее сгенерируем
            button3_Click(null, new EventArgs());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Col.Generate((int) numericUpDown1.Value);
            richTextBox1.Text = Col.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Col.Sort((a) => a);
            richTextBox1.Text = Col.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Col.Sort((a) => -a);
            richTextBox1.Text = Col.ToString();
        }

        private void button4_Click(object sender, EventArgs e) => richTextBox1.Text = Col.Min().ToString();

        private void button5_Click(object sender, EventArgs e) => richTextBox1.Text = Col.Max().ToString();

        private void button6_Click(object sender, EventArgs e) => richTextBox1.Text = Col.Sum().ToString();
    }
}
