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
            GenauMethode = true;

        }


        //Variablen
        double a5, a4, a3, a2, a1, a0;
        double x, yr, ya;
        double xn;
        string Ergebnis;
        Int32 nZaehler, Genau;
        double Genau2;
        double ErgebnisD;
        double checker;
        Int32 Ichecker;
        bool safe;
        double Oz1, Oz2;
        decimal ErgebnisA;
        double B1, B2;
        bool BiE;
        bool NVerfahren;
        bool GenauMethode;
        
        // double k1;
        // double k2;
        

        Stopwatch swN = new Stopwatch();
        Stopwatch swB = new Stopwatch();

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

        private bool GenauEntscheidung (double a, double b)
        {
            if (GenauMethode)
            {
                Debug.WriteLine("GENAU EPSILON");
                return Genauepsilon(a, b);
               
            }
            else
            {
                Debug.WriteLine("GENAU Vergleich");
                return GenaueV(a, b);
            }
        }

        private bool Genauepsilon (double a, double b)
        {
            if (!(Math.Abs(a - b) < Genau2))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GenaueV(double a, double b)
        {
            if (Math.Floor(a * (Math.Pow(10, (Genau)))) != (Math.Floor(b * (Math.Pow(10, (Genau))))))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void funktion()
        {
            yr = a5 * Convert.ToDouble((Math.Pow(x,5))) + a4 * Convert.ToDouble((Math.Pow(x,4))) + a3 * Convert.ToDouble((Math.Pow(x,3))) + a2 * Convert.ToDouble((Math.Pow(x,2))) + a1 * x + a0;
        }
        private double funktiontest(double xt)
        {
            double yt = (a5 * Convert.ToDouble((Math.Pow(xt, 5))) + a4 * Convert.ToDouble((Math.Pow(xt, 4))) + a3 * Convert.ToDouble((Math.Pow(xt, 3))) + a2 * Convert.ToDouble((Math.Pow(xt, 2))) + a1 * xt + a0);
            return yt;
        }

        private void abgleitet ()
        {
            ya = 5 * a5 * Convert.ToDouble((Math.Pow(x, 4))) + 4 * a4 * Convert.ToDouble((Math.Pow(x, 3))) + 3 * a3 * Convert.ToDouble((Math.Pow(x, 2))) + 2 * a2 * x + a1;
        }
        private void BisektionX()
        {
            x = (B1 + B2) / 2;
        }

        private void Bisektion()
        {
            Bicheck();
            swB.Start();
            BiE = true;
            Genau2 = Convert.ToDouble(1 * (Math.Pow(10, ((-1) * (Genau)))));
            //listBox1.Items.Add("x" + (nZaehler + 1) + " " + Convert.ToString((B1 + B2) / 2) + " [" + Convert.ToDecimal(B1) + " ; " + Convert.ToDecimal(B2) + "]");
            while (BiE & safe)
            {
                BisektionX();
                funktion();

                if (yr > 0)
                    {
                    B2 = x;
                    }
                if (yr < 0)
                {
                    B1 = x;
                }
                if (yr == 0)
                {
                    Ergebnis = Convert.ToString((B1 + B2) / 2);
                    BiE = false;
                }
                if (!GenauEntscheidung(B1, B2))
                {
                    Ergebnis = Convert.ToString(B1);
                    BiE = false;
                }
               
                //listBox1.Items.Add("Ba" + (nZaehler +1) + ": " + Convert.ToDecimal(B1) + "  Bb" + (nZaehler + 1) + ": " + Convert.ToDecimal(B2) + "  yr" + (nZaehler + 1) + ": " + Convert.ToDecimal(yr));
                listBox1.Items.Add("x" + (nZaehler + 1) + " " + Convert.ToString((B1 + B2) / 2) +  " [" + Convert.ToDecimal(B1) + " , " + Convert.ToDecimal(B2) + "]");
                listBox1.SelectedIndex = listBox1.Items.Count - 1;
                nZaehler = nZaehler + 1;

                if (nZaehler > 1000)
                {
                    safe = false;
                    System.Windows.Forms.MessageBox.Show("Abbruch! Über 1000 Iliteration vergangen! Besizt diese Funktion überhaupt eine NST?");
                    break;
                }
                
            }
            swB.Stop();
            Ergebnisausgabe();

        }
        

        private void newton()
        {
            swN.Start();
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
                if (!Double.IsInfinity(xn) & safe)
                {
                    listBox1.Items.Add("xn1: " + xn);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }
                if (Double.IsInfinity(x) & safe)
                {
                    listBox1.Items.Add("xn1: " + xn);
                    listBox1.SelectedIndex = listBox1.Items.Count - 1;
                }

            }
            catch
            {
             System.Windows.Forms.MessageBox.Show("Achtung: [Fehler beim eintragen in die Liste]");
            }
            Genau2 = Convert.ToDouble(1 * (Math.Pow(10, ((-1) * (Genau)))));        //Cheat +0 oder +1 ???? Eindeutig 0! Unnötig geworden
            Debug.WriteLine("GENAU2: " + Genau2);
            //(Math.Floor(xn * (Math.Pow(10, (Genau)))) != (Math.Floor(x * (Math.Pow(10, (Genau))))))
            while ( GenauEntscheidung(xn, x) & safe == true & Oz1 != Oz2)              // HIER IST DAS NEWTON VERFAHREN   & Oz1 != Oz2
            {
                Oz2 = x;
                x = xn;
                funktion();
                abgleitet();
                Nullcheck();
                if (safe)
                {
                    xn = x - (yr / ya);
                    Oz1 = xn;
                }
                // UND HIER IST ES WIEDR ZU ENDE
/*
                k1 = Math.Floor(xn * (Math.Pow(10, (Genau))));
                k2 = Math.Floor(xn * (Math.Pow(10, (Genau))));

                Debug.WriteLine("k1:" + k1);
                Debug.WriteLine("k2:" + k2);
*/

                try
                {
                    if (!Double.IsInfinity(xn))
                    {
                        listBox1.Items.Add("xn" + (nZaehler + 2) + ": " + Convert.ToDecimal(xn));
                        listBox1.SelectedIndex = listBox1.Items.Count - 1;
                    }
                
                    if (Double.IsInfinity(x))
                    {
                        listBox1.Items.Add("xn" + (nZaehler + 2) + ": " + Convert.ToDecimal(xn));
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
                    safe = false;
                    System.Windows.Forms.MessageBox.Show("Abbruch! Über 1000 Iliteration vergangen! Besizt diese Funktion überhaupt eine NST?");
                    break;
                }
                Debug.WriteLine("DIFFERENZ:" + Math.Round(Math.Abs(xn - x), (Genau)));
                Debug.WriteLine("DIFFERENZ2:" + Math.Abs(xn - x));



            }

            Debug.WriteLine(Ergebnis);
            try
            {
                if (!Double.IsInfinity(x))
                {
                    
                    ErgebnisA = Convert.ToDecimal(x);
                    Ergebnis = Convert.ToString(ErgebnisA);
                }
                if (Double.IsInfinity(x))
                {
                    System.Windows.Forms.MessageBox.Show("Achtung: Ergbenis ist Unendlich! Kann dies Stimmen?");
                    Genau = 10;
                    Ergebnis = Convert.ToString(x);
                }
                if (Oz1 == Oz2 & safe)
                {
                   safe = false;
                   System.Windows.Forms.MessageBox.Show("Abbruch: Oszialtion erkannt! Bitte Startwert ändern!");
                } 
            }
            catch
            {
                throw;
            }

            Debug.WriteLine(ErgebnisD);

            swN.Stop();
            Ergebnisausgabe();
        }

        private void Ergebnisausgabe()
        {
            try
            {
                if (x < 0 & Genau != 14 & safe & Ergebnis.Length > (Genau + 3))
                {
                    Ergebnis = Ergebnis.Substring(0, (Genau + 3));
                }
                if (x >= 0 & Genau != 14 & safe & Ergebnis.Length > (Genau + 2))
                {
                    Ergebnis = Ergebnis.Substring(0, (Genau + 2)); // HIER GIBT ES IMMER EINEN FEHLER! FIXEN!!!! Evtl. gefixt 30.4.16
                }
            }
            catch
            {
                //throw;
                //System.Windows.Forms.MessageBox.Show("Fehler beim Ergebnis! Bitte Eingabe prüfen! (Divison durch 0?)");
            }
            if (safe)
            {
                Debug.WriteLine(Ergebnis);
                Debug.WriteLine(ErgebnisA);
                Debug.WriteLine(ErgebnisD);

                label12.Text = "Die Nullstelle ist bei: " + Ergebnis;
                //swN.Stop();
                //swB.Stop();
                if (NVerfahren)
                {
                    label10.Text = "Benötigte Zeit:" + (Convert.ToString(swN.Elapsed.TotalMilliseconds) + "ms");
                    labelZN.Text = (Convert.ToString(swN.Elapsed.TotalMilliseconds) + "ms");
                    labelAN.Text = (Convert.ToString(nZaehler+1));
                    label16.Text = "Newton-Verfahren";
                    label8.Text = "Anzahl an Iterationen: " + (nZaehler + 1);
                }
                if (!NVerfahren)
                {
                    label10.Text = "Benötigte Zeit:" + (Convert.ToString(swB.Elapsed.TotalMilliseconds) + "ms");
                    labelZB.Text = (Convert.ToString(swB.Elapsed.TotalMilliseconds) + "ms");
                    labelAB.Text = (Convert.ToString(nZaehler));
                    label16.Text = "Bisektion";
                    label8.Text = "Anzahl an Iterationen: " + (nZaehler);
                }


                
            }
        }

        
        private void Sicherheitscheck()
        {
            // Überprüfen der Eingaben auf Gültigkeit
            // Eingaben a5 -x
           

            if (!(double.TryParse(textBox1.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a5 ungültig!");
            }
            if (!(double.TryParse(textBox2.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a4 ungültig!");
            }
            if (!(double.TryParse(textBox3.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a3 ungültig!");
            }
            if (!(double.TryParse(textBox4.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a2 ungültig!");
            }
            if (!(double.TryParse(textBox5.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a1 ungültig!");
            }
            if (!(double.TryParse(textBox6.Text, out checker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei a0 ungültig!");
            }

            if (!(double.TryParse(textBox7.Text, out checker)) & NVerfahren)
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei x0 ungültig!");
            }
            if (!(double.TryParse(textBoxB1.Text, out checker)) & !NVerfahren)
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei B1 ungültig!");
            }
            if (!(double.TryParse(textBoxB2.Text, out checker)) & !NVerfahren )
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei B2 ungültig!");
            }

            if (!(Int32.TryParse(textBox8.Text, out Ichecker)))
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Eingabe bei der Genauigkeit ungültig!");
            }

            //Sonderabfragen
            if (safe)
            {
                if ((Convert.ToInt32(textBox8.Text)) > 14) // Genauer wird es nicht (double = 16 stellen 
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Genauigkeit darf nicht über 14 Nachkommastellen sein!");
            }
                if ((Convert.ToInt32(textBox8.Text)) < 0) // Genauer wird es nicht (double = 16 stellen 
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Genauigkeit darf nicht unter 0 Nachkommastelle sein!");
            }
            }

            Debug.WriteLine("safe?!");
            Debug.WriteLine(safe);
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }


        private void button4_Click(object sender, EventArgs e) //Wurzel 2
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "1";
            textBox5.Text = "0";
            textBox6.Text = "-2";
            textBox7.Text = "2";
            textBox8.Text = "2";
            textBoxB1.Text = "-1";
            textBoxB2.Text = "2";
        }

        private void button5_Click(object sender, EventArgs e) // Wuezel 2
        {
            textBox1.Text = "0";
            textBox2.Text = "0";
            textBox3.Text = "0";
            textBox4.Text = "1";
            textBox5.Text = "0";
            textBox6.Text = "-2";
            textBox7.Text = "2";
            textBox8.Text = "2";
            textBoxB1.Text = "-1";
            textBoxB2.Text = "2";
        }

        private void button6_Click(object sender, EventArgs e) //Oszilation
        {
            textBox1.Text = "0"; //a5
            textBox2.Text = "0"; //a4
            textBox3.Text = "1"; //a3
            textBox4.Text = "0"; //a2
            textBox5.Text = "-2";//a1
            textBox6.Text = "2"; //a0
            textBox7.Text = "0"; //x0
            textBox8.Text = "2" ;//genau
            textBoxB1.Text = "-2";
            textBoxB2.Text = "0";
        }

        private void button7_Click(object sender, EventArgs e) // Extrema
        {
            textBox1.Text = "0"; //a5
            textBox2.Text = "0"; //a4
            textBox3.Text = "0"; //a3
            textBox4.Text = "-1"; //a2
            textBox5.Text = "0";//a1
            textBox6.Text = "1"; //a0
            textBox7.Text = "0"; //x0
            textBox8.Text = "2";//genau
            textBoxB1.Text = "-2";
            textBoxB2.Text = "0";
        }

        private void button8_Click(object sender, EventArgs e) // Keine NST
        {
            textBox1.Text = "0"; //a5
            textBox2.Text = "0"; //a4
            textBox3.Text = "0"; //a3
            textBox4.Text = "2"; //a2
            textBox5.Text = "1";//a1
            textBox6.Text = "1"; //a0
            textBox7.Text = "0"; //x0
            textBox8.Text = "2";//genau
        }

        private void button3_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show("(c)2016 Jonas Bauer \r\n Dieses Programm wurde für die DIAP Prüfung 2016 im Fach Mathematik von Jonas Bauer erstellt.");
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            NVerfahren = false;
            //bisektion
            Reset();
            safe = true;
            Sicherheitscheck();
            Start();
            Bisektion();
        }

        private void pictureBox26_Click(object sender, EventArgs e)
        {

        }

        private void button13_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void buttonB_Click(object sender, EventArgs e)
        {
          
        }

        private void Leercheck()
        {
            if (Math.Abs(a5) + Math.Abs(a4) + Math.Abs(a3) + Math.Abs(a2) + Math.Abs(a1) == 0)
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Bitte nicht alle Koeffizienten 0 lassen.");

            }
        }
        private void Nullcheck()
        {
            // Auf Divison durch 0 Überpüfen
            if (ya ==0)
            {
                if(a5 + a4 + a3 +a2 +a1 == 0)
                    {
                    safe = false;
                    System.Windows.Forms.MessageBox.Show("Achtung: Divison durch 0! Bitte nicht alle Koeffizienten 0 lassen. (f'(x) darf nicht 0 werden!)");
                    
                }

                else
                {
                    System.Windows.Forms.MessageBox.Show("Achtung: Divison durch 0! Bitte x0 ändern. (f'(x) darf nicht 0 werden!)");
                    safe = false;
                }

            }
        }
        private void Bicheck()
        {
            /*if (B1 >= B2) // B1 ist a und B2 ist b
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Achtung: a0 ist nicht kleiner als b0! Bitte a0 und/oder b0 ändern!");
            } */

            Debug.WriteLine ("TESTSSSSSSSSSSSSS:" + funktiontest(B1) * funktiontest(B2));
            if ((funktiontest(B1) * funktiontest(B2)) >= 0) // B1 ist a und B2 ist b
            {
                //safe = false;
                System.Windows.Forms.MessageBox.Show("Achtung: Kein Vorzeichenwechsel erkannt! a0 und b0 müssen verschiedenen Vorzeichen haben!");
            }

            if ((funktiontest(B2) < 0) & (funktiontest(B1)) > 0) // B1 ist a und B2 ist b
            {
                double Bt = B1;
                B1 = B2;
                B2 = Bt;
                //safe = false;
                System.Windows.Forms.MessageBox.Show("Achtung:  (a) < 0 < f (b)  Ich tausche!");
            }
            
        }


        private void Reset()
        {
            // Auto. Zurücksetzen
            listBox1.Items.Clear();
            nZaehler = 0;
            swN.Reset();
            swB.Reset();
            label12.Text = "Nullstelle:";
            label1.Text = "f(x0) =";
            ableit.Text = "f'(x0) =";
            label10.Text = "Benötigte Zeit:";
            label8.Text = "Anzahl an Iterationen: ";



        }
        private void Resetall()
        {
            // ALLES Zurücksetzen
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
            label12.Text = "Nullstelle:";
            label1.Text = "f(x0) =";
            ableit.Text = "f'(x0) =";
            label10.Text = "Benötigte Zeit:";
            label8.Text = "Anzahl an Iterationen: ";
            safe = true;
            labelZN.Text = "Benötigte Zeit";
            labelZB.Text = "Benötigte Zeit";
            labelAN.Text = "Anzahl an Iterationen";
            labelAB.Text = "Anzahl an Iterationen";
            swN.Reset();
            swB.Reset();


        }

        private void Start()
        {
            try
            {
                a5 = Convert.ToDouble(textBox1.Text);
                a4 = Convert.ToDouble(textBox2.Text);
                a3 = Convert.ToDouble(textBox3.Text);
                a2 = Convert.ToDouble(textBox4.Text);
                a1 = Convert.ToDouble(textBox5.Text);
                a0 = Convert.ToDouble(textBox6.Text);
                if (NVerfahren)
                {
                    x = Convert.ToDouble(textBox7.Text);
                }
                if (!NVerfahren)
                {
                    B1 = Convert.ToDouble(textBoxB1.Text);
                    B2 = Convert.ToDouble(textBoxB2.Text);
                }
               
                Genau = Convert.ToInt32(textBox8.Text);
               /* if (Genau == 1)                         // HARDCORE CHEAT!!!!
                    {
                    Genau = 2;

                }
                */
                Oz1 = 5555555555;
                Oz2 = 8888888888;
                Leercheck();
            }
            catch (Exception)
            {
                safe = false;
                System.Windows.Forms.MessageBox.Show("Fehlerhafte Eingabe! Bitte Überprüfen!");
            }


            funktion();

            abgleitet();

            if (safe)
            {
                Debug.WriteLine("SAFE?");
                Debug.WriteLine(safe);
                label1.Text = "f(x0)= " + Convert.ToDecimal(yr);
                ableit.Text = "f'(x0)= " + Convert.ToDecimal(ya);
                //newton();
            }
        }

        private void button1_Click(object sender, EventArgs e)  //HIER IST DER BUTTON
        {
            NVerfahren = true;
            Reset();
            safe = true;
            Sicherheitscheck();
            Start();
            newton();

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
