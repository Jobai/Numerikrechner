using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

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
        float xn;
        string Ergebnis;
        Int32 nZaehler, Genau;
        float Genau2;
        decimal ErgebnisD;
        float checker;
        bool safe;
        Int64 Oz1, Oz2;

        Stopwatch sw = new Stopwatch();

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

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void funktion()
        {
            yr = a5 * Convert.ToSingle((Math.Pow(x,5))) + a4 * Convert.ToSingle((Math.Pow(x,4))) + a3 * Convert.ToSingle((Math.Pow(x,3))) + a2 * Convert.ToSingle((Math.Pow(x,2))) + a1 * x + a0;
        }

        private void abgleitet ()
        {
            ya = 5 * a5 * Convert.ToSingle((Math.Pow(x, 4))) + 4 * a4 * Convert.ToSingle((Math.Pow(x, 3))) + 3 * a3 * Convert.ToSingle((Math.Pow(x, 2))) + 2 * a2 * x + a1;
        }
        private void newton()
        {
            sw.Start();
            funktion();
            abgleitet();
            Nullcheck();
            if (safe)
            {
                xn = x - (yr / ya);
            }
            
            Debug.WriteLine(xn);
            try
            {
                if (!Double.IsInfinity(xn))
                {
                    listBox1.Items.Add("xn1: " + Convert.ToDecimal(xn));
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                if (Double.IsInfinity(x))
                {
                    listBox1.Items.Add("xn1: " + xn);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }

            }
            catch
            {
             System.Windows.Forms.MessageBox.Show("Achtung: [Fehler beim eintragen in die Liste]");
            }
            Genau2 = Convert.ToSingle((Math.Pow(10, ((-1) * (Genau + 1)))));        //Cheat +0 oder +1 ????
            Debug.WriteLine("GENAU2" + Genau2);
            while ( Math.Abs(xn - x) > Genau2 & safe == true)              // HIER IST DAS NEWTON VERFAHREN   & Oz1 != Oz2
            {
                Oz2 = Convert.ToInt64(x);
                x = xn;
                funktion();
                abgleitet();
                Nullcheck();
                if (safe)
                {
                    xn = x - (yr / ya);
                    Oz1 = Convert.ToInt64(xn);
                }
                // UND HIER IST ES WIEDR ZU ENDE
                
                try
                {
                    if (!Double.IsInfinity(xn))
                    {
                        listBox1.Items.Add("xn" + (nZaehler + 2) + ": " + Convert.ToDecimal(xn));
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    }
                
                    if (Double.IsInfinity(x))
                    {
                        listBox1.Items.Add("xn" + (nZaehler + 2) + ": " + xn);
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    }
                
                }
                catch
                {

                    System.Windows.Forms.MessageBox.Show("Achtung:  [Fehler beim eintragen in die Liste]");
                }
                nZaehler = nZaehler + 1;
                if (nZaehler > 1000)
                {
                    System.Windows.Forms.MessageBox.Show("Abbruch! Über 10000 Iliteration vergangen! Besizt diese Funktion überhaupt eine NST?");
                    break;
                }
            }

            Debug.WriteLine(Ergebnis);
            try
            {
                if (!Double.IsInfinity(x))
                {
                    
                    ErgebnisD = Convert.ToDecimal(x);
                    Ergebnis = Convert.ToString(ErgebnisD);
                }
                if (Double.IsInfinity(x))
                {
                    System.Windows.Forms.MessageBox.Show("Achtung: Ergbenis ist Unendlich! Kann dies Stimmen?");
                    Genau = 10;
                    Ergebnis = Convert.ToString(x);
                }
                /*if (Oz1 == Oz2)
                {
                   safe = false;
                   System.Windows.Forms.MessageBox.Show("Achtung: Oszialtion erkann! Abbruch!");
                } */
            }
            catch
            {
                throw;
            }

            Debug.WriteLine(ErgebnisD);
            try
            {
                if (x <0)
                {
                    Ergebnis = Ergebnis.Substring(0, (Genau + 3));
                }
                if (x >= 0)
                {
                    Ergebnis = Ergebnis.Substring(0, (Genau + 2));
                }
            }
            catch
            {
                //System.Windows.Forms.MessageBox.Show("Fehler beim Ergebnis! Bitte Eingabe prüfen! (Divison durch 0?)");
            }
            if (safe)
            {
                label10.Text = "Das Ergebnis ist: " + Ergebnis + "!";
                sw.Stop();
                label12.Text = (Convert.ToString(sw.Elapsed.TotalMilliseconds) + "ms");
            }


        }
        private void Sicherheitscheck()
        {
                // Eingaben a5 -x
            if ((Convert.ToInt32(textBox8.Text)) > 24)
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Genauigkeit darf nicht über 24 Stellen sein!");
             }

            if (!(float.TryParse(textBox1.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a5 ungültig!");
            }
            if (!(float.TryParse(textBox2.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a4 ungültig!");
            }
            if (!(float.TryParse(textBox3.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a3 ungültig!");
            }
            if (!(float.TryParse(textBox4.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a2 ungültig!");
            }
            if (!(float.TryParse(textBox5.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a1 ungültig!");
            }
            if (!(float.TryParse(textBox6.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a0 ungültig!");
            }

            if (!(float.TryParse(textBox7.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei x0 ungültig!");
            }

            if (safe)
            {
                Start();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Resetall();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void Newtontcheck()
        {
            // Konvergenzüberprüfung


        }


        private void Zeitkontroller ()
        {
            // Zeitmessen
            
        }

        private void Nullcheck()
        {
            // Auf Divison durch 0 Überpüfen
            if (ya ==0)
            {
                if(a5 + a4 + a3 +a2 +a1 == 0)
                    {
                    System.Windows.Forms.MessageBox.Show("Achtung: Divison durch 0! Bitte nicht alle Koeffizienten 0 lassen. (f'(x) darf nicht 0 werden!)");
                    safe = false;
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("Achtung: Divison durch 0! Bitte x0 ändern. (f'(x) darf nicht 0 werden!)");
                    safe = false;
                }

            }
        }
        private void Reset()
        {
            // Auto. Zurücksetzen
            listBox1.Items.Clear();
            nZaehler = 0;
            sw.Reset();


        }
        private void Resetall()
        {
            // Auto. ALLES Zurücksetzen
            listBox1.Items.Clear();
            nZaehler = 0;

            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "0";
            textBox6.Text = "0";
            textBox7.Text = "0";
            textBox8.Text = "2";
            label12.Text = "";
            label1.Text = "";
            ableit.Text = "";
            label10.Text = "";
            safe = true;
            sw.Reset();


        }

        private void Start()
        {
            try
            {
                a5 = Convert.ToSingle(textBox1.Text);
                a4 = Convert.ToSingle(textBox2.Text);
                a3 = Convert.ToSingle(textBox3.Text);
                a2 = Convert.ToSingle(textBox4.Text);
                a1 = Convert.ToSingle(textBox5.Text);
                a0 = Convert.ToSingle(textBox6.Text);
                x = Convert.ToSingle(textBox7.Text);
                Genau = Convert.ToInt32(textBox8.Text);
                Oz1 = 5555555555;
                Oz2 = 8888888888;
            }
            catch (Exception)
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Fehlerhafte Eingabe! Bitte Überprüfen!");
            }


            funktion();

            abgleitet();

            label1.Text = "Das 1. Ergebnis ist: " + yr + "!";
            ableit.Text = "Das 1. Ergebnis der Ableitung ist: " + ya + "!";
            if (safe)
            {
                newton();
            }
        }

        private void button1_Click(object sender, EventArgs e)  //HIER IST DER BUTTON
        {
            Reset();
            safe = true;
            Sicherheitscheck();
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
