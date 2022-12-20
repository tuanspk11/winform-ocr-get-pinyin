using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GetTextTool
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(List<string> textResult)
        {
            InitializeComponent();
            textBox1.Text = String.Join("", textResult);
        }

        public Form2(string chineseString, string pinyinString)
        {
            InitializeComponent();
            textBox1.Text = chineseString;
            textBox2.Text = pinyinString;
        }
    }
}
