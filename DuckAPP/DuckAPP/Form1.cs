namespace DuckAPP
{
    public partial class Form1 : Form
    {
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Visible = true;
            button3.Visible = true;
            duckSay("Go fuck yourself Elliott!");
        }

        private async void duckSay(string duckSpeaks)
        {

            ToolTip duckSpeechBalloon = new ToolTip();
            duckSpeechBalloon.IsBalloon = true;
            duckSpeechBalloon.ToolTipIcon = ToolTipIcon.None;
            duckSpeechBalloon.AutoPopDelay = 200;
            duckSpeechBalloon.AutomaticDelay = 10;
            duckSpeechBalloon.Show(duckSpeaks, button1, 330, 10);
            await Task.Delay(1500);
            duckSpeechBalloon.Show("", button1, 330, 10);



        }

        public Form1()
        {
            this.BackColor = Color.Magenta;
            this.TransparencyKey = Color.Magenta;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void quitEvent(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}