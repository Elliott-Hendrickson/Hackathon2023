namespace DuckAPP
{
    public partial class Form1 : Form
    {
        private void DuckClick(object sender, EventArgs e)
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
            duckSpeechBalloon.Show(duckSpeaks, button1, 0, -20);
            await Task.Delay(1500);
            duckSpeechBalloon.Show("", button1, 330, 10);
        }

        public Form1()
        {
            this.BackColor = Color.Black;
            this.TransparencyKey = Color.Black;
            FormBorderStyle = FormBorderStyle.None;
            TopMost = true;
            InitializeComponent();
        }

        private void quitEvent(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }
    }
}