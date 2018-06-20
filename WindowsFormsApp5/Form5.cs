using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
        Windows1cs form1;
        public Form5(Windows1cs form):this()
        {
            this.form1 = form;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form7 form = new Form7();
            this.Hide();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {           
            Form4 form = new Form4(form1);
            this.Hide();
                //Application.Run();
                form.Show();                         
        }
    }
}
