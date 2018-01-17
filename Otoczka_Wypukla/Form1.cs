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

     

        private readonly Graphics _graphics;
        Pen pen = new Pen(Color.Red, 1);

        private Point[] _pointsTab;


        private List<Point> _randomPoints = new List<Point>();

        private List<Point> _vertices;
        private List<Point> _pointsList;

        int pointsQuantity = 100;


        public Form1()

        {
            InitializeComponent();
            _graphics = pictureBox1.CreateGraphics();


        }

        private void generate_button_Click(object sender, EventArgs e)
        {
            _graphics.Clear(Color.White);
            CreatePoints();
            FindStartPoints();

            _pointsList = CountHullJarvis(_vertices[0], _vertices[1], _randomPoints);
            _pointsList.Remove(_vertices[0]);



            _pointsTab = _pointsList.ToArray();
            _graphics.DrawLines(pen, _pointsTab);
           
        }

        //Generate random points
        private void CreatePoints()
        {
            var _random = new Random();

            int size = pictureBox1.Width;

            for (int i = 0; i < pointsQuantity; i++)
            {
                int x = _random.Next(5, size - 5);
                int y = _random.Next(5, size - 5);

                var point = new Point(x, y);

                _randomPoints.Add(point);
                _graphics.FillRectangle(new SolidBrush(Color.Black), point.X, point.Y, 1, 1);
                _graphics.FillRectangle(new SolidBrush(Color.Black), point.X, point.Y, 1, 1);
                //_graphics.DrawImage(img, point.X, point.Y);

            }
        }

        private void FindStartPoints()
        {
            var P0 = new Point();
            var P1 = new Point(0, 0); //lowest point


            // Finding lowest point
            foreach (var Point in _randomPoints)
            {
                if (Point.Y > P1.Y)
                {
                    P1 = Point;
                }
            }

            P0.X = -pictureBox1.Width + 1;
            P0.Y = P1.Y;

            _graphics.FillRectangle(new SolidBrush(Color.Red), P1.X, P1.Y, 10, 10);
     

            _vertices = new List<Point>();
            _vertices.Add(P0);
            _vertices.Add(P1);
        }




        public List<Point> CountHullJarvis(Point p0, Point p1, List<Point> list)
        {

          //  Point min = p1;
            Point p2 = new Point(0, 0);
            List<Point> _hullVertices = new List<Point>();
            double angle = 0;


            for (int i = 0; i < list.Count; i++)
            {
                angle = 0;
                for (int j = 0; j < list.Count; j++)
                {
                    if (countAngle(p0, p1, list[j]) > angle)
                    {
                        p2 = list[j];
                        angle = countAngle(p0, p1, p2);
                    }
                }

                p0 = p1;
                p1 = p2;

                _hullVertices.Add(p2);
            }


            return _hullVertices;

        }

        //public List<Point> CountHullTriangles(List<Point> list)
        //{
        //    List<Point> _hullVertices = new List<Point>();
        //    _hullVertices = list;
        //    var _random = new Random();

        //    Point p0 = new Point();
        //    Point p1 = new Point();
        //    Point p2 = new Point();
        //    Point point = new Point();

        //    while (true)
        //    {
        //        p0 = _hullVertices[_random.Next(0, _hullVertices.Count)];
        //        p1 = _hullVertices[_random.Next(0, _hullVertices.Count)];
        //        p2 = _hullVertices[_random.Next(0, _hullVertices.Count)];
        //        int maxX = int.MinValue;

        //        for (int i = 0; i < _hullVertices.Count; i++)
        //        {
        //            if (list[i].X > maxX)
        //                maxX = _hullVertices[i].X;
        //        }
        //        int rx = maxX + 1;

        //        int ry = point.Y;
        //        int c = 0; // c- iloś przecięć
        //        for (int i = 0; i < _hullVertices.Count; i++)
        //        {

        //            if (IsPart(p0.X, p0.Y, p1.X, p1.Y, p2.X, p2.Y) == 1)
        //            {
        //                c++;
        //            }

        //            //if (IsCrossing(p0.X, p0.Y, p1.X, p1.Y, p2.X, p2.Y, rx, ry))
        //            //    c++;
        //        }



        //        if (c % 2 != 0)
        //        {
        //            //usun punkt z hullVertices
        //        }
        //    }
        //    return _hullVertices;

        //}





        //private int IsPart(int ax, int ay, int bx, int by, int cx, int cy)
        //{


        //    {
        //        int det = Det(ax, ay, bx, by, cx, cy);
        //        if (det != 0)
        //            return 0;
        //        if ((Math.Min(ax, bx) <= cx) && (cx <= Math.Max(ax, bx)) &&
        //            (Math.Min(ay, by) <= cy) && (cy <= Math.Min(ay, by)))
        //            return 1;
        //        return 0;
        //    }

        //   int Det(int xx, int xy, int yx, int yy, int zx, int zy)
        //   {
        //        return (xx * yy + yx * zy + zx * xy - zx * yy - xx * zy - yx * xy);
        //   }


        //    //bool IsCrossing(int ax, int ay, int bx, int by, int px, int py, int rx, int ry)
        //    //{

        //    //    return (Math.Sign(Det(px, py, rx, ry, ax, ay)) != Math.Sign(Det(px, py, rx, ry, bx, by))) &&
        //    //           (Math.Sign(Det(ax, ay, bx, by, px, py)) != Math.Sign(Det(ax, ay, bx, by, rx, ry)));
        //    //}

        //}

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
            double cos = Math.Acos(alpha) * (180 / Math.PI);

            return cos;


        }
    }
}
