using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public partial class Form3 : Form
    {
        StructClass.Liter lit;
        StructClass.Liter his;
        StructClass.Liter geo;
        public Form3(StructClass.Liter lit, StructClass.Liter his, StructClass.Liter geo)
        {
            this.lit = lit;
            this.his = his;
            this.geo = geo;
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(928, 319);
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text += " Вы ответили верно на " + lit.trueOt + " из " + 10 + " вопросов " + "Баллы: " + lit.ball;
            label2.Text += " Вы ответили верно на " + his.trueOt + " из " + 10 + " вопросов " + "Баллы: " + his.ball;
            label3.Text += " Вы ответили верно на " + geo.trueOt + " из " + 10 + " вопросов " + "Баллы: " + geo.ball;

            label4.Text += " Вам нужно подтянуть знания по ";

            if (lit.ball < 70)
            {
                label4.Text +=  "Литераруте " + lit.falseOt + " неправильных ответов.";
            }
            if (his.ball < 70)
            {
                label4.Text +=  "Истории " + his.falseOt + " неправильных ответов.";
            }
            if (geo.ball < 70)
            {
                label4.Text +=  "Географии " + geo.falseOt + " неправильных ответов.";
            }
            if(geo.ball > 70 && his.ball > 70 && his.ball > 70)
            {
                label4.Text += " Вы успешно сзади предметы ";
            }


        }
    }
}
