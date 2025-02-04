using System;
using System.Drawing;
using System.Windows.Forms;

namespace FreOS
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer clockTimer,
            openNotepadAnim,
            timerStartMenu,
            taskbarTimer;
        private bool menuVisible = false;
        private int menuTargetY; // Endposition für das Startmenü
        public Form1()
        {
            InitializeComponent();
            this.Text = "Windows 11 UI";
            this.Size = new Size(800, 600);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;

            // Timer für Uhrzeit
            clockTimer = new System.Windows.Forms.Timer() { Interval = 100 };
            clockTimer.Tick += (s, e) => label1.Text = DateTime.Now.ToString("HH:mm:ss");
            clockTimer.Start();

            timerStartMenu = new System.Windows.Forms.Timer() { Interval = 10 };
            timerStartMenu.Tick += TimerStartMenu_Tick;

            taskbarTimer = new System.Windows.Forms.Timer { Interval = 10 };
            taskbarTimer.Tick += TaskbarTimer_Tick;
        }

        private void OpenNotepad()
        {
            Notepad notepad = new Notepad();
            openNotepadAnim = new System.Windows.Forms.Timer() { Interval = 10 };
            openNotepadAnim.Tick += AnimateNotepadOpen;
            openNotepadAnim.Start();

            notepad.Show();
        }

        private void AnimateNotepadOpen(object sender, EventArgs e)
        {
            Notepad notepad = new Notepad();
            if (notepad.Top > 200)
            {
                notepad.Top -= 10;
            }
            else
            {
                openNotepadAnim.Stop();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            menuVisible = !menuVisible;
            menuTargetY = menuVisible ? 244 : 400;

            panelStartMenu.Visible = true;
            timerStartMenu.Start();
        }
        private void TimerStartMenu_Tick(object sender, EventArgs e)
        {
            if (menuVisible)
            {
                // Menü nach oben bewegen
                if (panelStartMenu.Top > menuTargetY)
                {
                    panelStartMenu.Top -= 10;
                }
                else
                {
                    timerStartMenu.Stop();
                }
            }
            else
            {
                // Menü nach unten bewegen
                if (panelStartMenu.Top < menuTargetY)
                {
                    panelStartMenu.Top += 10;
                }
                else
                {
                    panelStartMenu.Visible = false; // Menü ausblenden
                    timerStartMenu.Stop();
                }
            }
        }
        private void TaskbarTimer_Tick(object sender, EventArgs e)
        {
            if (menuVisible)
            {
                if (taskbarPanel.Top < this.Height - taskbarPanel.Height)
                {
                    taskbarPanel.Top += 10;
                }
                else
                {
                    taskbarTimer.Stop();
                }
            }
            else
            {
                if (taskbarPanel.Top > this.Height)
                {
                    taskbarPanel.Top -= 10;
                }
                else
                {
                    taskbarTimer.Stop();
                }
            }
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenNotepad();
        }

        private void Sleep_Click(object sender, EventArgs e)
        {
            SleepingForm sleepingForm = new SleepingForm();
            sleepingForm.Show();
            this.Hide();
        }
        
        private void guna2Button3_Click(object sender, MouseEventArgs e)
        {
            guna2ContextMenuStrip1.Show(this, e.Location);
        }
        private void Shutdown_Click(object sender, EventArgs e)
        {
            ShutdownForm shutdownForm = new ShutdownForm();
            shutdownForm.Show();
            this.Hide();
        }
    }
}
