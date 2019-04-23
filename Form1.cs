using System;
using System.Windows.Forms;

namespace Alarm_Clock
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Window moving
            this.MouseDown += new MouseEventHandler((o, e) =>
            {
                base.Capture = false;
                Message m = Message.Create(base.Handle, 161, new IntPtr(2), IntPtr.Zero);
                this.WndProc(ref m);
            });

        }

        int hour, minute, second;
        string alarmHour, alarmMinute;

        //Window
        private void Form1_Load_1(object sender, EventArgs e)
        {
            timer1.Start();

            for (int i = 0; i < 24; i++)
            {
                comboBox1.Items.Add(i);
            }
            for (int j = 0; j < 60; j++)
            {
                comboBox2.Items.Add(j);
            }
        }
        //Timer
        private void Timer1_Tick(object sender, EventArgs e)
        {
            second = DateTime.Now.Second;
            minute = DateTime.Now.Minute;
            hour = DateTime.Now.Hour;
            label4.Text = hour.ToString();
            label5.Text = minute.ToString();
            label6.Text = second.ToString();
            Alarm();
        }
        //Function which open file with song
        void Alarm()
        {
            if (alarmHour == hour.ToString() && alarmMinute == minute.ToString() && second.ToString() == "0")
            {
                axWindowsMediaPlayer1.URL = "C:\\Users\\Алина\\source\\repos\\ISD\\Alarm Clock\\song.mp3";
            }
        }
        //Stap alarm clock
        private void Button1_Click(object sender, EventArgs e)
        {
            alarmHour = comboBox1.Text;
            alarmMinute = comboBox2.Text;
        }
        //Stop alarm clock
        private void Button2_Click(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.close();
        }
        //Exit Button
        private void Button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
