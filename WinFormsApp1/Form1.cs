namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public int LengthJS = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(this);
            this.Hide();
            f2.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text =  LengthJS.ToString();
        }
    }
}