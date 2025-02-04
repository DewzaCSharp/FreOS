using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace FreOS
{
    public partial class ShutdownForm : Form
    {
        private static System.Timers.Timer timer1;
        public ShutdownForm()
        {
            InitializeComponent();

            timer1 = new System.Timers.Timer(5000);
            timer1.Elapsed += OnTimerElapsed;
            timer1.AutoReset = false;
            timer1.Start();
        }
        private static void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
