namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        
        public int LengthJS = 0;
        StructClass.Liter otchetH = new StructClass.Liter();
        StructClass.Liter otchetG = new StructClass.Liter();
        StructClass.Liter otchetL = new StructClass.Liter();
        public Form1()
        {
            InitializeComponent();
            this.MaximumSize = new System.Drawing.Size(816, 489);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(otchetL.check)
            {
                MessageBox.Show("Вы уже прошли тест по литературе, рузультаты вы можите узнать в отчете");
                return;
            }
            Form2 f2 = new Form2(this, "http://83.136.232.230:7151/api//literTest");
            this.Hide();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
        public void otchetLit(StructClass.Liter liter)
        {
            otchetL = liter;
        }
        public void otchetGeo(StructClass.Liter geogr)
        {
            otchetG = geogr;
        }
        public void otchetHis(StructClass.Liter his)
        {
           otchetH = his;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (otchetH.check)
            {
                MessageBox.Show("Вы уже прошли тест по истории, рузультаты вы можите узнать в отчете");
                return;
            }
            Form2 f2 = new Form2(this, "http://83.136.232.230:7151/api//historyTest");
            this.Hide();
            f2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (otchetG.check)
            {
                MessageBox.Show("Вы уже прошли тест по географии, рузультаты вы можите узнать в отчете");
                return;
            }
            Form2 f2 = new Form2(this, "http://83.136.232.230:7151/api//geogrTest");
            this.Hide();
            f2.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (otchetH.check && otchetL.check && otchetG.check) {
                Form3 f3 = new Form3(otchetL, otchetH, otchetG);
                f3.Show();
            }
            else
            {
                string test = "";
                
                    if(!otchetH.check)
                    {
                      test += " Истории ";
                    }
                    if(!otchetL.check)
                    {
                      test += " Литературе ";
                    }
                    if(!otchetG.check)
                    {
                      test += " Географии ";
                    }

                MessageBox.Show("Прежде чем получить отчет проетите тесты по" + test);
            }
        }
    }
}