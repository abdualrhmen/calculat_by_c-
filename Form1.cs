using System;
using System.Windows.Forms;

namespace calculate
{
    public partial class from1 : Form
    {
        double n1;
        double n2;
        double results;
        string pro;

        public from1()
        {
            InitializeComponent();
        }

        private void calc_Load(object sender, EventArgs e)
        {
            num1.BringToFront();
            num2.BringToFront();
            num3.BringToFront();
            num4.BringToFront();
            num5.BringToFront();
            num6.BringToFront();
            textBox1.ForeColor = System.Drawing.Color.Black;
            textBox3.ForeColor = System.Drawing.Color.Black;
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (textBox3.Text == "0")
                textBox3.Text = "";

            textBox3.Text += btn.Text;
            textBox1.Text += btn.Text;
        }

        private void pro_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (double.TryParse(textBox3.Text, out n1))
            {
                pro = btn.Text;
                textBox1.Text += pro;
                textBox3.Clear();
            }
            else
            {
                MessageBox.Show("الرجاء إدخال رقم صحيح قبل اختيار العملية.");
            }
        }

        private void delet_Click(object sender, EventArgs e)
        {
            textBox3.Clear();
            textBox1.Clear();
            n1 = n2 = results = 0;
            pro = "";
        }

        private void result_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(textBox3.Text, out n2))
            {
                MessageBox.Show("الرجاء إدخال الرقم الثاني بشكل صحيح.");
                return;
            }

            switch (pro)
            {
                case "+":
                    results = n1 + n2;
                    pro = "";
                    break;
                case "-":
                    results = n1 - n2;
                    pro = "";
                    break;
                case "*":
                    results = n1 * n2;
                    pro = "";
                    break;
                case "/":
                    if (n2 != 0)
                    {
                        results = n1 / n2;
                        pro = "";
                    }
                    else
                    {
                        MessageBox.Show("لا يمكن القسمة على صفر.");
                        return;
                    }
                    break;
                default:
                    MessageBox.Show("لم يتم اختيار عملية حسابية.");
                    return;
            }

            textBox3.Text = results.ToString();
            textBox1.Clear();
        }

        private void close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ac_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Length > 0)
            {
                textBox3.Text = textBox3.Text.Substring(0, textBox3.Text.Length - 1);
            }

            // تحديث textBox1 أيضًا إذا أردت أن يعكس التغيير
            if (textBox1.Text.Length > 0)
            {
                textBox1.Text = textBox1.Text.Substring(0, textBox1.Text.Length - 1);
            }
        }

       /* private void nextbtn_Click(object sender, EventArgs e)
        {
            this.SelectNextControl(this.ActiveControl, true, true, true, true);
        }*/
       /*
        private void prevbtn_Click(object sender, EventArgs e)
        {
            this.SelectNextControl(this.ActiveControl, false, true, true, true);
        }*/
    }
}
