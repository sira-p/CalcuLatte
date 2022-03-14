namespace CalcuLatte
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        bool calced = false;
        bool justOpted = false;

        private void button1_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = ""; textBox2.AppendText("-----"); textBox2.AppendText(Environment.NewLine); calced = false; }
            textBox1.AppendText("1");
            justOpted = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = ""; textBox2.AppendText("-----"); textBox2.AppendText(Environment.NewLine); calced = false; }
            textBox1.AppendText("2");
            justOpted = false;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = ""; textBox2.AppendText("-----"); textBox2.AppendText(Environment.NewLine); calced = false; }
            textBox1.AppendText("3");
            justOpted = false;
        }

        private void button0_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = ""; textBox2.AppendText("-----"); textBox2.AppendText(Environment.NewLine); calced = false; }
            textBox1.AppendText("0");
            justOpted = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = ""; textBox2.AppendText("-----"); textBox2.AppendText(Environment.NewLine); calced = false; }
            textBox1.AppendText("7");
            justOpted = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = ""; textBox2.AppendText("-----"); textBox2.AppendText(Environment.NewLine); calced = false; }
            textBox1.AppendText("8");
            justOpted = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = ""; textBox2.AppendText("-----"); textBox2.AppendText(Environment.NewLine); calced = false; }
            textBox1.AppendText("9");
            justOpted = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = ""; textBox2.AppendText("-----"); textBox2.AppendText(Environment.NewLine); calced = false; }
            textBox1.AppendText("4");
            justOpted = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = ""; textBox2.AppendText("-----"); textBox2.AppendText(Environment.NewLine); calced = false; }
            textBox1.AppendText("5");
            justOpted = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = ""; textBox2.AppendText("-----"); textBox2.AppendText(Environment.NewLine); calced = false; }
            textBox1.AppendText("6");
            justOpted = false;
        }

        private void buttonEq_Click(object sender, EventArgs e)
        {
            string line = textBox1.Text + " = " + calc(textBox1.Text.Replace(" ", string.Empty));
            textBox1.Text = line;
            textBox2.AppendText(line);
            textBox2.AppendText(Environment.NewLine);
            calced = true;
            justOpted = false;
        }

        private void buttonDiv_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = textBox1.Text.Split(" = ")[1]; calced = false; }
            if (justOpted) { textBox1.Text.Remove(textBox1.Text.Length - 3); }
            textBox1.AppendText(" / ");
            justOpted = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labelTime.Text = DateTime.Now.ToLongTimeString();
            labelDate.Text = DateTime.Now.ToLongDateString();
        }

        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = textBox1.Text.Split(" = ")[1]; calced = false; }
            try
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1);
            }
            catch (ArgumentOutOfRangeException)
            {

            }
        }

        private void buttonMod_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = textBox1.Text.Split(" = ")[1]; calced = false; }
            if (justOpted) { textBox1.Text.Remove(textBox1.Text.Length - 3); }
            textBox1.AppendText(" % ");
            justOpted = false;
        }

        private void buttonMul_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = textBox1.Text.Split(" = ")[1]; calced = false; }
            if (justOpted) { textBox1.Text.Remove(textBox1.Text.Length - 3); }
            textBox1.AppendText(" * ");
            justOpted = false;
        }

        private void buttonSubtract_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = textBox1.Text.Split(" = ")[1]; calced = false; }
            if (justOpted) { textBox1.Text.Remove(textBox1.Text.Length - 3); }
            textBox1.AppendText(" - ");
            justOpted = false;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (calced) { textBox1.Text = textBox1.Text.Split(" = ")[1]; calced = false; }
            if (justOpted) { textBox1.Text.Remove(textBox1.Text.Length - 3); }
            textBox1.AppendText(" + ");
            justOpted = false;
        }

        private void buttonClr_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private static string calc(string mathStr)
        {
            char[] operators = { '+', '-', '*', '/', '%' };
            if (mathStr[0] == '-')
            {
                mathStr = "0" + mathStr;
            }
            float[] nums = Array.ConvertAll<string, float>(ReplaceAll(mathStr, operators).Split("|"), float.Parse);
            float output = nums[0];
            int index = 1;

            foreach (char character in mathStr)
            {
                switch (character)
                {
                    case '+':
                        output += nums[index];
                        index++;
                        break;
                    case '-':
                        output -= nums[index]; ;
                        index++;
                        break;
                    case '*':
                        output *= nums[index];
                        index++;
                        break;
                    case '/':
                        output /= nums[index];
                        index++;
                        break;
                    case '%':
                        output %= nums[index];
                        index++;
                        break;
                }
                
            }

            return output.ToString();
        }

        public static string ReplaceAll(string str, char[] re)
        {
            string output = str;
            foreach (char i in re)
            {
                output = output.Replace(i, '|');
            }
            return output;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}