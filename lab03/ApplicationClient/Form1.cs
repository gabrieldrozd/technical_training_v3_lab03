using MathServiceLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApplicationClient
{
    public partial class Form1 : Form
    {
        private readonly IMathService _client = ChannelFactory<IMathService>.CreateChannel(
            new BasicHttpBinding(),
            new EndpointAddress("http://localhost:4444/MathService")
            );

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(textBox1.Text);
            int number2 = Convert.ToInt32(textBox2.Text);

            int result = _client.Add(new MyNumbers() { Number1 = number1, Number2 = number2 });
            textBox3.Text = result.ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            int number1 = Convert.ToInt32(textBox1.Text);
            int number2 = Convert.ToInt32(textBox2.Text);

            int result = _client.Substract(new MyNumbers() { Number1 = number1, Number2 = number2 });
            textBox3.Text = result.ToString();
        }
    }
}
