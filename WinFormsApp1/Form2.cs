using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;
using System.Text.Json.Nodes;
namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        Form1 f1;
        UrlQuery UrlQuery;
        JsonNode data;
        JsonNode js;
        int LengthJS = 0;
        string pred, url;
        StructClass.Liter liter = new StructClass.Liter(); 
        Boolean checkOt;
        //int ball = 0;
       // int trueOt = 0;
        //int falseOt = 0;
        //Boolean checkPredmet = false;
        public Form2(Form1 f1, string url) 
        {
            this.f1 = f1;
            this.url = url;
            InitializeComponent(); 
            UrlQuery = new UrlQuery();
            this.MaximumSize = new System.Drawing.Size(816, 489);

        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(pred == "Литература") f1.otchetLit(liter);
            if (pred == "География") f1.otchetGeo(liter);
            if (pred == "История") f1.otchetHis(liter);
                f1.Show();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            button2.Hide();
            js = JsonObject.Parse(UrlQuery.Get(url));
            var jsSetting = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            data = js![0]!;
            label1.Text  += data["name"]!.ToString();
            pred = label1.Text;
            string q = data["questions"]![LengthJS]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["vopros"]!.ToString();
            radioButton1.Text = data["questions"]![LengthJS]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet1"]["otvet"].ToString();
            radioButton2.Text = data["questions"]![LengthJS]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet2"]["otvet"].ToString();
            radioButton3.Text = data["questions"]![LengthJS]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet3"]["otvet"].ToString();
            checkOt = ((bool)data["questions"]![LengthJS]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet2"]["check"]);
            textBox1.Text = q;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if ((!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked) && liter.check != true)
            {
                MessageBox.Show("Вы не выбрали ответ");
                return;
            }
            if (!liter.check)
            {
                if (radioButton1.Checked)
                {
                    if (((bool)data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet1"]["check"]))
                    {
                        liter.ball += 10;
                        // ball += 10;
                        liter.trueOt += 1;
                    }
                    else { liter.falseOt += 1; }

                }
                if (radioButton2.Checked)
                {
                    if (((bool)data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet2"]["check"]))
                    {
                        liter.ball += 10;
                        liter.trueOt += 1;
                        // MessageBox.Show("Правильно");
                    }
                    else { liter.falseOt += 1; }

                }
                if (radioButton3.Checked == true)
                {
                    if (((bool)data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet3"]["check"]))
                    {
                        liter.ball += 10;
                        liter.trueOt += 1;
                    }
                    else { liter.falseOt += 1; }

                }
            }
                if (LengthJS == 9)
                {
                    MessageBox.Show("Вы ответили на все вопросы, результаты вы можите узнать в отчете в меню");
                    liter.check = true;
                    button2.Show();
                    return;
                }
            
            f1.LengthJS++;
            LengthJS++;
            label2.Text = LengthJS +  1 + "/" + "10";
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            string q = data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["vopros"]!.ToString();
            radioButton1.Text = data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet1"]["otvet"].ToString();
            radioButton2.Text = data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet2"]["otvet"].ToString();
            radioButton3.Text = data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet3"]["otvet"].ToString();
            checkOt = ((bool)data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet2"]["check"]);
            textBox1.Text = q;


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
