namespace DuckAPP
{
    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = true;
        }

        public Form1()
        {
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}