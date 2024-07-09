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
    public partial class Form2 : Form
    {
        Random random = new Random();
        List<string> answers = new List<string>();
        List<string> corrects = new List<string>();
        List<string> mistaken = new List<string>();

        int operand1;
        int operand2;
        int randOperator;

        string primer;
        char[] opps = { '+' , '-', '*', '/'};
        int count;
        int numberOfQues = 1;

        public Form2()
        {

            InitializeComponent();
        }

        delegate int lambda(int a, int b);

        lambda minus = (x, y) => x - y;
        lambda plus = (x, y) => x + y;
        lambda inc = (x, y) => x * y;
        lambda del = (x, y) => x / y;

        public int randomPrimer()
        {

            switch (randOperator)
            {
                case 0:
                    return plus(operand1, operand2);
                case 1:
                    return minus(operand1, operand2);
                case 2:
                    return inc(operand1, operand2);
                case 3:
                    return del(operand1, operand2);

                default:
                    throw new ArgumentException("Invalid operator");
            }

        }

        void predrandomPrimer()
        {
            label3.Text = $" Вопрос {numberOfQues} / 5 ";
            randOperator = random.Next(0, 4);

            if (randOperator == 3)
            {
                do 
                {
                    operand1 = random.Next(1, 20);
                    operand2 = random.Next(1, 20);

                } while(operand1 % operand2 != 0);
            }

            else
            {
                operand1 = random.Next(1, 20);
                operand2 = random.Next(1, 20);
            }

            primer = $"{operand1} {opps[randOperator]} {operand2} = ";
            label1.Text = primer ;

        }

        void checkItRight()
        {
            if (textBox1.Text != string.Empty)
            {
                string currentAnswear = textBox1.Text;
                if (Int32.Parse(currentAnswear) == randomPrimer())
                {
                    corrects.Add($" Вопрос № {numberOfQues} пример: {primer}  {currentAnswear} - Правильно ");
                    answers.Add(corrects[corrects.Count - 1]);
                    count++;
                }
                else
                {
                    mistaken.Add($" Вопрос № {numberOfQues} пример: {primer}  {currentAnswear} - Ошибка ");
                    answers.Add(mistaken[mistaken.Count - 1]);
                }
            }
            else
            {
                 answers.Add($" Вопрос № {numberOfQues} пример: {primer}  Без ответа ");
                 mistaken.Add(answers[answers.Count - 1]);
            }
               


        }


        private void Form2_Load(object sender, EventArgs e)
        {
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            radioButton3.Enabled = false;
            predrandomPrimer();
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            checkItRight();

            numberOfQues += 1;
            if (numberOfQues == 5)
                button1.Enabled = false;
            textBox1.Clear();
            predrandomPrimer() ;

        }

        private void button2_Click(object sender, EventArgs e)
        {

            checkItRight();
            label4.Text = $"Ваш результат: {count} ";

            radioButton1.Enabled = true;
            radioButton2.Enabled = true;
            radioButton3 .Enabled = true;
            radioButton3.Checked = true;
            button2.Enabled = false;
            button1.Enabled = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = corrects;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = mistaken;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            listBox1.DataSource= null;
            listBox1.DataSource = answers;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }
        }

        
    }
}
