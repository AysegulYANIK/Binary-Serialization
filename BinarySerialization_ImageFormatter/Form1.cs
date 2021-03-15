using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Media.Imaging;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace BinarySerialization_ImageFormatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
            // Add the files to a list.
            List<Image> input_images = new List<Image>();
            input_images.Add((Bitmap)picSource1.Image);
            input_images.Add((Bitmap)picSource2.Image);
            input_images.Add((Bitmap)picSource3.Image);
            */

            List<Image> input_images = new List<Image>();

            //give a valid path as parameter below
            string path = "C:\\Images\\daisy.png";
            label3.Text = path;
            input_images.Add(Image.FromFile(path));

            // Serialize.
            byte[] bytes;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(ms, input_images);
                bytes = ms.ToArray();
            }

            // Display the serialization bytes.
            textBox1.AppendText( BitConverter.ToString(
                bytes, 0).Replace('-', ' ') );
            textBox1.Select(0, 0);
        }
    }
}
