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
    public partial class Form3 : Form
    {
        bool _Rc = false; 
        static int mine = 0;
        static int maxe = 0;
        public List<int> interval;
        Predicate<int> inrevvalValue = (int x) => x > mine & x < maxe;
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != string.Empty & textBox5.Text != string.Empty)
            {
                mine = Convert.ToInt32(textBox4.Text);
                maxe = Convert.ToInt32(textBox5.Text);
                interval = Form1.list.FindAll(inrevvalValue);
                _Rc = true;
                this.Close();
            }
        }

        public List<int> Interval { get { return interval; } }
        public bool Rc { get { return _Rc; } }
    }
}
