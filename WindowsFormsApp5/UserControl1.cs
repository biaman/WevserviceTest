using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp5
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        Form6 form6;
        MessageModel mModel;
        public UserControl1(Form6 form6):this()
        {
            this.form6 = form6;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form6.fun2();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            form6.fun3();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            mModel.IsLockKeyboard = false;
            form6.Close();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {
            mModel = MessageModel.instance();
        }
    }
}
