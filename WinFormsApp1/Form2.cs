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
        int LengthJS;
        Boolean checkOt;
        int ball = 0;
        int trueOt = 0;
        int falseOt = 0;
        public Form2(Form1 f1) 
        {
            this.f1 = f1;
            this.LengthJS = LengthJS;
            InitializeComponent(); 
            UrlQuery = new UrlQuery();
          
        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            f1.Show();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            js = JsonObject.Parse(UrlQuery.Get("http://83.136.232.230:7151/api//literTest"));
            var jsSetting = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            data = js![0]!;
            label1.Text  += data["name"]!.ToString();
            string q = data["questions"]![LengthJS]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["vopros"]!.ToString();
            radioButton1.Text = data["questions"]![LengthJS]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet1"]["otvet"].ToString();
            radioButton2.Text = data["questions"]![LengthJS]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet2"]["otvet"].ToString();
            radioButton3.Text = data["questions"]![LengthJS]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet3"]["otvet"].ToString();
            checkOt = ((bool)data["questions"]![LengthJS]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet2"]["check"]);
            textBox1.Text = q;


        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(LengthJS == 10)
            {

            }
            if(radioButton1.Checked)
            {
                if(((bool)data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet1"]["check"]))
                { 
                  ball += 10;
                  trueOt += 1;
                }
                else { falseOt += 1; }
               
            }
            if (radioButton2.Checked)
            {
                if(((bool)data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet2"]["check"]))
                {
                 ball += 10;
                 trueOt += 1;
                 MessageBox.Show("Правильно");
                }
                else { falseOt += 1; }
               
            }
            if (radioButton3.Checked == true)
            {
                if(((bool)data["questions"]![0]!["vopros" + Convert.ToString(LengthJS + 1)]![0]!["otvets"]![0]!["otvet3"]["check"]))
                {
                    ball += 10;
                    trueOt += 1;
                }
                else { falseOt += 1; }
               
            }
            f1.LengthJS++;
            LengthJS++;
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
    }
}
