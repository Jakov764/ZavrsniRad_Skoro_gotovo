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
using System.Xml.Linq;

namespace cvekŠpraljaJakovZavrsniRad
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            string putanja = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Promet");
            XDocument dokument = XDocument.Load(putanja + "/Racuni.Xml");
            var promet =
                from Racun in dokument.Element("racunLista").Elements("Racun")
                where Racun.Element("Total").Value != ""
                select Racun;

            int total2 = 0;

            foreach (XElement total in promet)
            {
                string iznos = (string)total.Element("Total");

                int iznos2 = Int32.Parse(iznos);

                total2 += iznos2;

                richTextBox1.AppendText("Iznos računa: " + (string)total.Element("Total") + ".00 kn"
                    +  "\n\r");
            }

            richTextBox1.AppendText("Ukupan promet: " + total2 + ".00 kn");

            

            
            
          

            
        }
    }
}
