using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NumberToWords;

namespace Arabic_Numbers
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string number = textBox1.Text;

            if(number.Length < 10)
            {
                label3.Text = TafqeetArabic.convertNumberToArabicWords(number, "جنية سوداني", "قرش");
            } else
            {
                MessageBox.Show("اعلي طول للرقم عشر خانات, الرجاء مراجعة البيانات.", "فشل العملية" , MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
