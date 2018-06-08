using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace Otoczka_Wypukla
{
    public partial class Form1 : Form
    {

     

        public Graphics Graphics; //Graphics to create drawing space


        Pen pen = new Pen(Color.Red, 1); //Pen for convex hull

        public Point[] PointsTab;

        public List<Point> RandomPoints = new List<Point>(); //List of randomly generated points

        public List<Point> Vertices; 
        public List<Point> PointsList;

        public int pointsQuantity; 


        public Form1()

        {
            InitializeComponent();
            

        }

        private void generate_button_Click(object sender, EventArgs e)
        {
            //Create and clear drawing space
            Graphics = pictureBox1.CreateGraphics();
            Graphics.Clear(Color.White);

            //Read quantity of random points
            try
            {
                pointsQuantity = Int32.Parse(pointsQuantitiTextBox.Text);
            }
            catch (FormatException)
            {

                throw new FormatException("Value not entered");
            }
           

            CreatePoints();

            FindStartPoints();


            PointsList = CountHullJarvis(Vertices[0], Vertices[1], RandomPoints); //Create list of hull points
            PointsList.Remove(Vertices[0]); //Remove auxiliary point from list

            Graphics.DrawLines(pen, PointsList.ToArray()); // Draw hull


            //Clear lists
            Vertices.Clear();
            RandomPoints.Clear();
            PointsList.Clear();

        }

        //Generate random points
        private void CreatePoints()
        {
            
            var Random = new Random();

            //Size of drawing space
            int size = pictureBox1.Width;

            //drawing point with random coordinates
            for (int i = 0; i < pointsQuantity; i++)
            {
                int x = Random.Next(5, size - 5);
                int y = Random.Next(5, size - 5);

                var point = new Point(x, y);

                RandomPoints.Add(point);
                Graphics.FillRectangle(new SolidBrush(Color.Black), point.X, point.Y, 2, 2);
            }
        }

        private void FindStartPoints()
        {
            
            var P0 = new Point(); // Auxiliary point 
            var P1 = new Point(0, 0); // Lowest point


            // Find lowest point
            foreach (var Point in RandomPoints)
            {
                if (Point.Y > P1.Y)
                {
                    P1 = Point;
                }
            }

            // Coordinates for auxiliary point
            P0.X = -pictureBox1.Width + 1;
            P0.Y = P1.Y;

            //Draw lowest point
            //Graphics.FillEllipse(new SolidBrush(Color.Blue), P1.X-5, P1.Y-5, 10, 10);
     
            
            Vertices = new List<Point>();  //
            Vertices.Add(P0);
            Vertices.Add(P1);
        }




        public List<Point> CountHullJarvis(Point p0, Point p1, List<Point> list)
        {


            Point p2 = new Point(0, 0);
            List<Point> HullVertices = new List<Point>();
            double angle = 0;

            // algorithm that finds the next points of the hull based on the angle with the previous two points
            for (int i = 0; i < list.Count; i++) //new pair
            {
                angle = 0;
                for (int j = 0; j < list.Count; j++) //check for all points 
                {
                    if (countAngle(p0, p1, list[j]) > angle) //compare angles saving the highest one.
                    {
                        p2 = list[j]; //new point that makes highest angle with p1 and p2
                        angle = countAngle(p0, p1, p2); //currently highest angle
                    }
                }

                
                // Swap points with the next to find the next hull point              
                p0 = p1;
                p1 = p2;

                //add new point to list of hull points
                HullVertices.Add(p2);
            }

            //return list with hull points
            return HullVertices;

        }
        

        //Count angle for three points
        public double countAngle(Point p0, Point p1, Point p2)
        {
            double alpha = 0, la = 0, lb = 0;
            Point va = new Point();
            Point vb = new Point();

            va.X = p2.X - p1.X;
            va.Y = p2.Y - p1.Y;
            vb.X = p0.X - p1.X;
            vb.Y = p0.Y - p1.Y;

            la = Math.Sqrt(Math.Pow(va.X, 2) + Math.Pow(va.Y, 2));
            lb = Math.Sqrt(Math.Pow(vb.X, 2) + Math.Pow(vb.Y, 2));

            double scal = (va.X * vb.X + va.Y * vb.Y);

            alpha = scal / (la * lb);
            double cos = Math.Acos(alpha) * (180 / Math.PI); //Cosinus converted to degrees

            return cos;


        }
    }
}
