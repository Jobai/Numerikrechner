using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MATHE_DIAP_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        //Variablen
        float a5, a4, a3, a2, a1, a0;
        float x, yr, ya;

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void funktion(float x)
        {
            yr = a5 * (x * x * x * x * x) + a4 * (x * x * x * x) + a3 * (x * x * x) + a2 * (x * x) + a1 * x + 0;
        }

        private void abgleitet (float x)
        {
            ya = 5 * a5 * (x * x * x * x) + 4 * a4 * (x * x * x) + 3 * a3 * (x * x) + 2 * a2 * x + a1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            a5 = Convert.ToSingle(textBox1.Text);
            a4 = Convert.ToSingle(textBox2.Text);
            a3 = Convert.ToSingle(textBox3.Text);
            a2 = Convert.ToSingle(textBox4.Text);
            a1 = Convert.ToSingle(textBox5.Text);
            a0 = Convert.ToSingle(textBox6.Text);
            x = Convert.ToSingle(textBox7.Text);
            funktion(x);
            abgleitet(x);
            listBox1.Items.Add(yr);
            listBox1.SelectedIndex = listBox1.Items.Count - 1;

            label1.Text = "Das Ergebnis ist: " + yr +"!";
            ableit.Text = "Das Ergebnis der Ableitung ist: " + ya + "!";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
