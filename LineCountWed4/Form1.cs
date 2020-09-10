using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LineCountWed4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = LineCount(textBox1.Text).ToString();

            LocalWcfs.ServiceClient serviceClient = new LocalWcfs.ServiceClient();
            label4.Text = serviceClient.LineCount(textBox1.Text).ToString();

            AwsLineCount.ServiceClient aws = new AwsLineCount.ServiceClient();
            label8.Text = aws.LineCount(textBox1.Text).ToString();
        }

        public int LineCount(string filename)
        {
            int count = 0;

            WebClient webClient = new WebClient();
            Stream stream = webClient.OpenRead(filename);
            StreamReader streamReader = new StreamReader(stream);

            while (!streamReader.EndOfStream)
            {
                streamReader.ReadLine();
                count++;
            }

            return (count);
        }
    }
}
