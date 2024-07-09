using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pr_3_sharp
{
    public partial class Form1 : Form
    {

        public static List<int> list;
        List<int> positive;
        List<int> list_onlyPlus = new List<int>();
        

        public Form1()
        {
            list = new List<int>();
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            list.Add(12);
            list.Add(17);
            list.Add(-9);
            list.Add(0);
            list.Add(144);
            list.Add(-3);
            list.Add(-8);
            list.Add(101);
            list.Add(184);
            list.Add(-1024);


            list_onlyPlus.AddRange(list);
            list_onlyPlus.RemoveAll(isNigative);

            positive = list.FindAll(isPositive);
            



        }

        Predicate<int> isPositive = (int x) => x > 0;
        Predicate<int> isNigative = (int x) => x < 0;
        
        

        static int addition(int x, int y)
        {
            return x + y;
        }

        static int subtraction(int x, int y)
        {
            return x - y;
        }

        delegate int mydelegate(int a, int b);
        delegate int lambda(int a, int b);

        lambda minus = (x, y) => x - y;
        lambda plus = (x, y) => x + y;

        static int myarithmetic(int a, int b, mydelegate f)
        {
            return f(a, b);
        }


        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if ( textBox1.Text != string.Empty & textBox2.Text != string.Empty)
            {
                int res = myarithmetic(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), addition);
                textBox3.Text = Convert.ToString(res);
            }
            
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty & textBox2.Text != string.Empty)
            {
                int res = myarithmetic(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), subtraction);
                textBox3.Text = Convert.ToString(res);
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty & textBox2.Text != string.Empty)
            {
                int res = plus(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                textBox3.Text = Convert.ToString(res);
            }

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != string.Empty & textBox2.Text != string.Empty)
            {
                int res = minus(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text));
                textBox3.Text = Convert.ToString(res);
            }
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            if (positive != null)
            {
                MessageBox.Show($"Сумма всех положительных: {Convert.ToString(positive.Sum())} ");
            }
            
        }

        

        private void button5_Click(object sender, EventArgs e)
        {
            Form TGK = new Form2();
            TGK.ShowDialog();
        }

        

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox5.SelectedIndex == 0)
            {
                
                listBox1.DataSource = list;
            }
            if (listBox5.SelectedIndex == 1)
            {
                
                listBox1.DataSource = positive;
            }
            if (listBox5.SelectedIndex == 2)
            {
                
                listBox1.DataSource = list_onlyPlus;
            }
            if (listBox5.SelectedIndex == 3)
            {
                listBox1.DataSource = positive;
                MessageBox.Show($"Сумма всех положительных: {Convert.ToString(positive.Sum())} ");
            }
            if( listBox5.SelectedIndex == 4)
            {
                Form3 new_form = new Form3();
                new_form.ShowDialog();
                if(new_form.Rc == true)
                {
                    listBox1.DataSource = new_form.Interval;
                }
                
            }


        }

    }
}
