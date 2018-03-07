using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace Lab1IP2
{
    public partial class Form1 : Form
    {
        #region Values for formula constants, limits for x and the step for the graph

        /// <summary>
        /// The value of a from formula
        /// </summary>
        private float a = 0;
        /// <summary>
        /// The value of b from formula
        /// </summary>
        private float b = 0;
        /// <summary>
        /// The value of c from formula
        /// </summary>
        private float c = 0;

        /// <summary>
        /// The step value for the graph
        /// </summary>
        private float counter = 1;

        /// <summary>
        /// Minimum value of x
        /// </summary>
        private float xMin = -5;
        /// <summary>
        /// Maximum value of x
        /// </summary>
        private float xMax = 5;
        /// <summary>
        /// Minimum value of y
        /// </summary>
        private float yMin = -5;
        /// <summary>
        /// Maximum value of y
        /// </summary>
        private float yMax = 5;

        #endregion

        #region Validation functions for textBoxes and rules file.
        /// <summary>
        /// This function validates that the textBox contains only numbers
        /// And numbers with decimals (ex: 0.52341)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoxValidateInput(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar) || e.KeyChar == '.'))
                e.Handled = e.KeyChar != (char)Keys.Back;
        }


        /// <summary>
        /// Function that checks that rules.txt file exists / has valid data into it.
        /// </summary>
        private void ValidateRules()
        {
            string line;
            try
            {
                StreamReader file = new StreamReader("rules.txt");
                while ((line = file.ReadLine()) != null)
                {
                    var nameValue = line.Split('=');
                    if ("counter".Equals(nameValue[0]))
                        counter = float.Parse(nameValue[1]);
                    else if ("xMin".Equals(nameValue[0]))
                        xMin = float.Parse(nameValue[1]);
                    else if ("xMax".Equals(nameValue[0]))
                        xMax = float.Parse(nameValue[1]);
                    else if ("yMin".Equals(nameValue[0]))
                        yMin = float.Parse(nameValue[1]);
                    else if ("yMax".Equals(nameValue[0]))
                        yMax = float.Parse(nameValue[1]);
                }
            }
            catch
            {
                MessageBox.Show("Invalid format / file for rules.txt please input correct step, min, max!");
            }
        }



        #endregion

        #region Class constructor

        /// <summary>
        /// Constructor for the Form1 class.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        #endregion

        #region Buttons click actions: Calculate / Save Img / Save txt

        /// <summary>
        /// This function is called when "Re/Calculate" button is pressed.
        /// It will process the data inputed into textBoxes and it will create the graph
        /// after that it will make buttons for save visible.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CalculateButtonClicked(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxValueA.Text) || String.IsNullOrEmpty(textBoxValueB.Text) || String.IsNullOrEmpty(textBoxValueC.Text))
            {
                MessageBox.Show("Please input values for A B C");
            }
            else
            {
                a = float.Parse(textBoxValueA.Text);
                b = float.Parse(textBoxValueB.Text);
                c = float.Parse(textBoxValueC.Text);
                MakeGraph();
                MakeSaveButtonsVisible();

            }
        }

        /// <summary>
        /// This function makes saveImageButton & saveTextButton visible and change text from
        /// calcultateButton to "Recalculate"
        /// </summary>
        private void MakeSaveButtonsVisible()
        {
            saveImageButton.Visible = true;
            saveTextButton.Visible = true;
            calculateButton.Text = "Recalculate";
        }

        /// <summary>
        /// A function that is called when pressing "Save txt" button.
        /// It starts an new windows object of type SaveFileDialog.
        /// It saves a list of Points in format: "Point: (x, F(x)) \n"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextSaveGraph(object sender, EventArgs e)
        {
            System.Text.UnicodeEncoding uniEncoding = new System.Text.UnicodeEncoding();
            Stream streamToSaveText = new MemoryStream();
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;

            String points = "";
            for (float x = xMin; x <= xMax; x = x + counter)
            {
                points += "Point: (" + Math.Round(x, 2) + ", " + Math.Round(F(x), 2) + ")\n";
            }

            byte[] messageBytes = uniEncoding.GetBytes(points);
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if ((streamToSaveText = saveDialog.OpenFile()) != null)
                {
                    streamToSaveText.Write(messageBytes, 0, messageBytes.Length);
                    streamToSaveText.Position = 0;
                    streamToSaveText.Close();
                }
            }

        }

        /// <summary>
        /// A function that is called when button "Save img" is pressed.
        /// It starts an new windows object of type SaveFileDialog.
        /// It saves the graph.Image as an png.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageSaveGraph(object sender, EventArgs e)
        {
            Stream streamToSaveImage = new MemoryStream();
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.Filter = "png files (*.png)|*.png|All files (*.*)|*.*";
            saveDialog.FilterIndex = 1;
            saveDialog.RestoreDirectory = true;

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if ((streamToSaveImage = saveDialog.OpenFile()) != null)
                {
                    pictureGraph.Image.Save(streamToSaveImage, System.Drawing.Imaging.ImageFormat.Png);
                    streamToSaveImage.Position = 0;
                    streamToSaveImage.Close();
                }
            }
        }
        #endregion

        #region Drawning functions and F(X) calculation
        /// <summary>
        /// This function is the Graph draw logic
        /// </summary>
        private void MakeGraph()
        {

            ValidateRules();

            // Make the Bitmap.
            int width = pictureGraph.ClientSize.Width;
            int hight = pictureGraph.ClientSize.Height;
            Bitmap bitMap = new Bitmap(width, hight);
            using (Graphics graph = Graphics.FromImage(bitMap))
            {
                graph.SmoothingMode = SmoothingMode.AntiAlias;
                graph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graph.PixelOffsetMode = PixelOffsetMode.HighQuality;
                graph.TextRenderingHint = TextRenderingHint.AntiAliasGridFit;
                //graph.ScaleTransform(1, -1);

                // Transform to map the graph bounds to the Bitmap.
                RectangleF rectangle = new RectangleF(xMin, yMin, xMax - xMin, yMax - yMin);
                PointF[] fPoints =
                {
                    new PointF(0, hight),
                    new PointF(width, hight),
                    new PointF(0, 0),
                };

                graph.Transform = new Matrix(rectangle, fPoints);

                // Draw the graph.
                using (Pen graphPen = new Pen(Color.Blue, 0))
                {
                    // Draw the axes.
                    graph.DrawLine(graphPen, xMin, 0, xMax, 0);
                    graph.DrawLine(graphPen, 0, yMin, 0, yMax);
                    graphPen.Color = Color.Green;


                    bool lastNumberColor = true;
                    for (float x = xMin; x <= xMax; x = x + counter)
                    {
                        graph.DrawLine(graphPen, x, -0.05f, x, 0.05f);
                        if (lastNumberColor)
                            graph.DrawString(Math.Round(x, 2).ToString(), new Font("Arial", counter / 3, FontStyle.Regular), Brushes.Black, new PointF(x, yMax - counter / 2));
                        else
                            graph.DrawString(Math.Round(x, 2).ToString(), new Font("Arial", counter / 3, FontStyle.Regular), Brushes.Red, new PointF(x, yMax - counter / 2));
                        lastNumberColor = !lastNumberColor;
                    }
                    lastNumberColor = true;
                    for (float y = yMin; y <= yMax; y = y + counter)
                    {
                        graph.DrawLine(graphPen, -0.05f, y, 0.05f, y);
                        if (lastNumberColor)
                            graph.DrawString(Math.Round(y, 2).ToString(), new Font("Arial", counter / 3, FontStyle.Regular), Brushes.Black, new PointF(xMin, y));
                        else
                            graph.DrawString(Math.Round(y, 2).ToString(), new Font("Arial", counter / 3, FontStyle.Regular), Brushes.Red, new PointF(xMin, y));
                        lastNumberColor = !lastNumberColor;
                    }
                    bitMap.RotateFlip(RotateFlipType.Rotate180FlipX);
                    //bitMap.RotateFlip(RotateFlipType.RotateNoneFlipNone);

                    graphPen.Color = Color.Red;

                    // See how big 1 pixel is horizontally.
                    Matrix inverse = graph.Transform;
                    inverse.Invert();
                    PointF[] PixelPoints =
                    {
                        new PointF(0, 0),
                        new PointF(1, 0)
                    };
                    inverse.TransformPoints(PixelPoints);
                    float dx = PixelPoints[1].X - PixelPoints[0].X;
                    dx /= 2;

                    // Loop over x values to generate points.
                    List<PointF> points = new List<PointF>();
                    for (float x = xMin; x <= xMax; x += dx)
                    {
                        bool validPoint = false;
                        try
                        {
                            // Get the next point.
                            float y = F(x);

                            // If the slope is reasonable, this is a valid point.
                            if (points.Count == 0)
                                validPoint = true;
                            else
                            {
                                float dy = y - points[points.Count - 1].Y;
                                if (Math.Abs(dy / dx) < 1000)
                                    validPoint = true;
                            }
                            if (validPoint) points.Add(new PointF(x, y));
                        }
                        catch
                        {
                        }

                        // If the new point is invalid, draw
                        // the points in the latest batch.
                        if (!validPoint)
                        {
                            if (points.Count > 1)
                                graph.DrawLines(graphPen, points.ToArray());
                            points.Clear();
                        }

                    }

                    // Draw the last batch of points.

                    if (points.Count > 1)
                        graph.DrawLines(graphPen, points.ToArray());
                }
            }


            // Display the result
            
            pictureGraph.Image = bitMap;

        }

        /// <summary>
        /// This is the core function it calculates the F(x) 
        /// </summary>
        /// <param name="x">The param for the F(x) function</param>
        /// <returns></returns>
        private float F(float x)
        {
            return (float)(a * Math.Pow(x, 2) + x * b + c);
        }

        #endregion
    }
}
