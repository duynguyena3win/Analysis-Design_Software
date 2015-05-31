using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Prototype_Pattern
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public Barrack barrack = new Barrack();
        private void button1_Click(object sender, EventArgs e)
        {
            int idx = comboBox1.SelectedIndex;
            Unit init = barrack.Recruit(idx);
        }
    }
}
