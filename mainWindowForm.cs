namespace finalProjectJA
{
    using System.Drawing;
    using System.Windows.Forms;
    using System.Runtime.InteropServices;

    public partial class mainWindowForm : Form
    {
        Bitmap image;
        private int myImageId;
        private int cellWidth;
        private int cellHeight;
        private bool[,] labirynth;
        private bool loadedLibrary;
        private int labirynthWidth;
        private int labirynthHeight;
        private int[] intTableSize = { 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37 };

        [DllImport(@"C:\Users\Rafa³\source\repos\finalProjectJA\x64\Debug\mazeCreatorC.dll")]
        public static extern bool createLabirynt(int height, int width);

        [DllImport(@"C:\Users\Rafa³\source\repos\finalProjectJA\x64\Debug\mazeCreatorAsembler.dll")]
        static extern int MyProc1(int a, int b);

        public mainWindowForm()
        {
            InitializeComponent();

            for (int i = 0; i < tableSize.GetLength(0); i++)
            {
                if (i < 6)
                {
                    comboBox1.Items.Add(tableSize.GetValue(i));
                }

                comboBox2.Items.Add(tableSize.GetValue(i));
            }

            int x = 5, y = 3;
            myImageId = MyProc1(x, y); ;
            cellWidth = 50;
            cellHeight = 50;
            loadedLibrary = createLabirynt(2,10); ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (labirynthHeight == 0)
            {
                labirynthHeight = 5;
            }

            if (labirynthWidth == 0)
            {
                labirynthWidth = 5;
            }

            labirynth = new bool[labirynthHeight, labirynthWidth];

            for (int i = 0; i < labirynthHeight; i++)
            {
                for (int j = 0; j < labirynthWidth; j++)
                {
                    labirynth[i, j] = true;
                }
            }

            int totalWidth = labirynthWidth * cellWidth;
            int totalHeight = labirynthHeight * cellHeight;

            if(loadedLibrary)
            {
                //c++

            }
            else
            {
                //asembler

            }


            image = new Bitmap(totalWidth, totalHeight);
            Graphics graphics = Graphics.FromImage(image);

            Pen blackPen = new Pen(Color.Black, 10);
            Brush whiteBrush = new SolidBrush(Color.White);
            Brush blackBrush = new SolidBrush(Color.Black);
            Rectangle rectangle;

            for (int i = 0; i < labirynthHeight; i++)
            {
                for (int j = 0; j < labirynthWidth; j++)
                {
                    rectangle = new Rectangle(j * cellWidth, i * cellHeight, cellWidth, cellHeight);
                    graphics.DrawRectangle(blackPen, rectangle);

                    if(labirynth[i, j] == true)
                    {
                        //graphics.FillRectangle(whiteBrush, rectangle);

                        graphics.DrawLine(blackPen, 0, 0, 0, totalHeight);
                        graphics.DrawLine(blackPen, 0, 0, totalWidth, 0);
                        graphics.DrawLine(blackPen, totalWidth, totalHeight, 0, totalHeight);
                        graphics.DrawLine(blackPen, totalWidth, totalHeight, totalWidth, 0);
                    }
                    else
                    {
                        //graphics.FillRectangle(blackBrush, rectangle);

                        graphics.DrawLine(blackPen, 0, 0, 0, totalHeight);
                        graphics.DrawLine(blackPen, 0, 0, totalWidth, 0);
                        graphics.DrawLine(blackPen, totalWidth, totalHeight, 0, totalHeight);
                        graphics.DrawLine(blackPen, totalWidth, totalHeight, totalWidth, 0);
                    }

                    
                }
            }



            string filePath = "image" + myImageId + ".jpg";
            image.Save(filePath);
            myImageId++;

            pictureBox1.Image = System.Drawing.Image.FromFile(filePath);

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labirynthHeight = intTableSize[comboBox1.SelectedIndex];
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label4.Text = e.NewValue.ToString();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            labirynthWidth = intTableSize[comboBox2.SelectedIndex];
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = "image" + myImageId + ".jpg";
            saveFileDialog1.Filter = "JPeg Image|*.jpg|Bitmap Image|*.bmp";
            saveFileDialog1.Title = "Save an Image File";
            saveFileDialog1.FileName = filePath;
            saveFileDialog1.ShowDialog();

            if (saveFileDialog1.FileName != "")
            {
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                
                image.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                fs.Close();
            }
        }
    }
}
