namespace DuckAPP
{
    public partial class Form1 : Form
    {
        int quitStage = 0;
        private void DuckClick(object sender, EventArgs e)
        {
            duckSay("Quack Quack!");
            GetBrowserData.GetBrowserResponse();
        }

        public async void duckSay(string duckSpeaks)
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
            
            if (quitStage == 0)
            {
                duckSay("Please don't kill me!");
                Console.WriteLine("First attempt");
                quitStage = 1;
                button1.Image = Properties.Resources.sadduckE;
            }
            else if (quitStage == 1)
            {
                duckSay("I DON'T WANT TO DIE!!!!!");
                Console.WriteLine("second attempt");
                button1.Image = Properties.Resources.desperateduckE;
                quitStage = 2;
            }
            else if (quitStage == 2)
            {
                System.Windows.Forms.Application.Exit();
            }
        }
    }
}