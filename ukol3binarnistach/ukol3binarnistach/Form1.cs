using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ukol3binarnistach
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            FileStream fs = new FileStream("texty.dat",FileMode.OpenOrCreate,FileAccess.ReadWrite);
            BinaryReader br = new BinaryReader(fs, Encoding.GetEncoding("windows-1250"));
            BinaryWriter bw = new BinaryWriter(fs, Encoding.GetEncoding("windows-1250"));
            bw.Write("Ahoj, dneska je pekne.");
            bw.Write("Doufam ze mi to nebude davat chybu.");
            bw.Write("Opravdu v to doufam.");
            br.BaseStream.Seek(0, SeekOrigin.Begin);
            while(br.BaseStream.Length > br.BaseStream.Position)
            {
                listBox1.Items.Add(br.ReadString());
            }
            fs.Close();
            fs = new FileStream("texty.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            br = new BinaryReader(fs, Encoding.GetEncoding("windows-1250"));
            bw = new BinaryWriter(fs, Encoding.GetEncoding("windows-1250"));
            foreach (string x in listBox1.Items)
            {
                bw.Write(x.Replace('.','!'));
            }

            br.BaseStream.Seek(0,SeekOrigin.Begin);
            while (br.BaseStream.Length > br.BaseStream.Position)
            {
                listBox2.Items.Add(br.ReadString());
            }
            fs.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
