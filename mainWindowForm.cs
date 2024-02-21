using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Windows.Forms;



namespace FinalProgramJA
{


    public partial class Labirynt : Form
    {

        [DllImport(@"C:\Users\Rafa³\source\repos\TestProgram\x64\Debug\mazeCreatorAsembler.dll")]
        static extern int MyProc1(int a, int b);

        [DllImport(@"C:\Users\Rafa³\source\repos\TestProgram\x64\Debug\mazeCreatorC.dll")]
        static extern bool createLabirynt(int coreNumber, int labiryntWidth, int labiryntHeight, int cellSize, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] out int[] arr, out int length);

        private int[] intTableSize = { 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31, 33, 35, 37 };
        private int labirynthHeight;
        private bool loadedLibrary;
        private int labirynthWidth;
        private bool[,] labirynth;
        private int cellHeight;
        private int myImageId;
        private int cellWidth;
        private int[] labi;
        Bitmap image;


        public Labirynt()
        {
            InitializeComponent();

            for (int i = 0; i < tableSize.GetLength(0); i++)
            {
                if (i < 6)
                {
                    heightBox.Items.Add(tableSize.GetValue(i));
                }

                widthBox.Items.Add(tableSize.GetValue(i));
            }

            heightBox.Text = tableSize[0];
            widthBox.Text = tableSize[0];
            cellHeight = 50;
            cellWidth = 50;


        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
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
            labi = new int[labirynthHeight * labirynthWidth * 6];

            for (int i = 0; i < labirynthHeight; i++)
            {
                for (int j = 0; j < labirynthWidth; j++)
                {
                    labirynth[i, j] = true;
                    labi[i * labirynthWidth + j] = i;
                    labi[i * labirynthWidth + j + 1] = j;
                    labi[i * labirynthWidth + j + 2] = 1;
                    labi[i * labirynthWidth + j + 3] = 1;
                    labi[i * labirynthWidth + j + 4] = 1;
                    labi[i * labirynthWidth + j + 4] = 1;
                }
            }

            int totalWidth = labirynthWidth * cellWidth;
            int totalHeight = labirynthHeight * cellHeight;

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();

            int size = labi.Length;

            if (loadedLibrary)
            {
                //c++
                bool lab = createLabirynt(hScrollBar1.Value, labirynthWidth, labirynthHeight, cellWidth, out labi, out size);

                
            }
            else
            {



            }

            stopwatch.Stop();

            label8.Text = stopwatch.ElapsedMilliseconds.ToString();


            image = new Bitmap(totalWidth, totalHeight);
            Graphics graphics = Graphics.FromImage(image);

            Pen redPen = new Pen(Color.Red, 5);
            Pen whitePen = new Pen(Color.White, 5);
            Pen blackPen = new Pen(Color.Black, 5);

            Brush whiteBrush = new SolidBrush(Color.White);
            Brush blackBrush = new SolidBrush(Color.Black);
            Rectangle rectangle;

            for (int i = 0; i < labirynthHeight; i++)
            {
                for (int j = 0; j < labirynthWidth; j++)
                {
                    rectangle = new Rectangle(j * cellWidth, i * cellHeight, cellWidth, cellHeight);
                    //TOP
                    graphics.DrawLine(blackPen, rectangle.X, rectangle.Y, rectangle.Right, rectangle.Y);
                    //LEFT
                    graphics.DrawLine(blackPen, rectangle.X, rectangle.Y, rectangle.X, rectangle.Bottom);
                    //RIGHT
                    graphics.DrawLine(blackPen, rectangle.Right, rectangle.Bottom, rectangle.Right, rectangle.Y);
                    //BOTTOM
                    graphics.DrawLine(blackPen, rectangle.Right, rectangle.Bottom, rectangle.X, rectangle.Bottom);

                    if (labirynth[i, j] == true)
                    {
                        graphics.FillRectangle(whiteBrush, rectangle);
                    }
                    else
                    {

                        graphics.DrawLine(blackPen, 0, 0, 0, totalHeight);
                        graphics.DrawLine(blackPen, 0, 0, totalWidth, 0);
                        graphics.DrawLine(blackPen, totalWidth, totalHeight, 0, totalHeight);
                        graphics.DrawLine(blackPen, totalWidth, totalHeight, totalWidth, 0);
                    }


                }
            }

            int randomvalue;
            byte[] rno = new byte[5];


            //Start
            graphics.DrawLine(whitePen, 0, 0, cellWidth, 0);

            for (int i = 0; i < labirynthHeight; i++)
            {
                for (int j = 0; j < labirynthWidth; j++)
                {
                    using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
                    {
                        rg.GetBytes(rno);
                        randomvalue = BitConverter.ToInt32(rno, 0);
                    }

                    if (labi[i * labirynthWidth + j + 2] == 1 && randomvalue > 5)
                    {
                        graphics.DrawLine(whitePen, j * cellWidth, i * cellHeight, j * cellWidth, i * cellHeight + cellHeight);
                    }

                    if (labi[i * labirynthWidth + j + 3] == 1)
                    {
                        graphics.DrawLine(whitePen, j * cellWidth + cellWidth, i * cellHeight + cellHeight, j * cellWidth, i * cellHeight + cellHeight);
                    }

                    if (labi[i * labirynthWidth + j + 4] == 1 && randomvalue < 15)
                    {
                        graphics.DrawLine(whitePen, j * cellWidth + cellWidth, i * cellHeight + cellHeight, j * cellWidth + cellWidth, i * cellHeight);
                    }

                    if (labi[i * labirynthWidth + j + 5] == 1)
                    {
                        graphics.DrawLine(whitePen, j * cellWidth, i * cellHeight, j * cellWidth + cellWidth, i * cellHeight);
                    }
                }
            }

            graphics.DrawLine(blackPen, 0, 0, 0, totalHeight);
            graphics.DrawLine(blackPen, 0, 0, totalWidth, 0);
            graphics.DrawLine(blackPen, totalWidth, totalHeight, 0, totalHeight);
            graphics.DrawLine(blackPen, totalWidth, totalHeight, totalWidth, 0);

            string filePath = "image" + myImageId + ".jpg";
            image.Save(filePath);
            myImageId++;

            pictureBox1.Image = System.Drawing.Image.FromFile(filePath);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string filePath = "solvedMaze" + myImageId + ".jpg";
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

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            labirynthHeight = intTableSize[heightBox.SelectedIndex];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string filePath = "maze" + myImageId + ".jpg";
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

        private void button2_Click(object sender, EventArgs e)
        {
            Stopwatch stopwatch = new Stopwatch();

            int size = labi.Length;

            if (loadedLibrary)
            {
                stopwatch.Start();

                //c++
                bool lab = createLabirynt(hScrollBar1.Value, labirynthWidth, labirynthHeight, cellWidth, out labi, out size);

                stopwatch.Stop();

                label9.Text = stopwatch.ElapsedMilliseconds.ToString();
            }
            else
            {

                stopwatch.Start();

                //asembler

                stopwatch.Stop();

                label9.Text = stopwatch.ElapsedMilliseconds.ToString();

            }
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            label6.Text = hScrollBar1.Value.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void widthBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            labirynthWidth = intTableSize[widthBox.SelectedIndex];
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }
    }
}
