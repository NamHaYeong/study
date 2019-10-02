using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Closest_Pair
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    /// 

    //IComparer는 비교를 위한 인터페이스이다.
    public class XComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (int)(((Point)x).X - ((Point)y).X);
        }
    }
    public class YComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return (int)(((Point)x).Y - ((Point)y).Y);
        }
    }

    public partial class MainWindow : Window
    {
        const int p = 100;
        Point[] points = new Point[p];
        public MainWindow()
        {
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Canvas1.Children.Clear();
            MakePointArray();
        }

        private void MakePointArray()
        {
            Random r = new Random();
            for (int i = 0; i < p; i++)
            {
                points[i].X = r.Next(500);
                points[i].Y = r.Next(500);
            }
            foreach(var p in points)
            {
                Rectangle rect = new Rectangle();
                rect.Width = 3;
                rect.Height = 3;
                rect.Stroke = Brushes.Black;
                Canvas.SetLeft(rect, p.X);
                Canvas.SetTop(rect, p.Y);
                Canvas1.Children.Add(rect);
            }
        }

        private void btnFind_Click(object sender, RoutedEventArgs e)
        {
            //double min = double.MaxValue;
            //for (int i = 0; i < p; i++)

            //    for (int j = i + 1; j < p; j++)
            //    {
            //        double d = Dist(i, j);
            //        //d가 min보다 작으면
            //        //d, i, j를 저장
            //        if(d < min)
            //        {
            //            d = min;

            //        }
            //    }
            //points[] 배열에 있는 점들을
            //x좌표를 기준으로 정렬하여 출력하시오
            //int[] a = new int[100];
            //Random r = new Random();
            //for (int i = 0; i < 100; i++)
            //    a[i] = r.Next(1000);

            //foreach (var v in a)
            //    Console.WriteLine(v);
            //Console.WriteLine("...After Sort");
            //Array.Sort(a);
            //foreach (var v in a)
            //    Console.WriteLine(v);

            IComparer xComp = new XComparer();
            Array.Sort(points, xComp);
            //Array.Sort(points, new YComparer());
            PrintPoint();

           ClosestPair CP =  FindClosestPair(points, 0, 100, -1);
        }

        private ClosestPair FindClosestPair(Point[] points, int right, int left, int v3)
        {
            if (right - left <= 3)
                AlgorithmN2();
            int mid = left + (right - left) / 2; //중앙점
            ClosestPair CPL = FindClosestPair(points, left, mid);
            ClosestPair CPR = FindClosestPair(points, mid + 1, right);
            double d = Math.Min(CPL.dist, CPR.dist);
            ClosestPair CPC = FindMidRange(points, d);

            return MinCP(CPL, CPR, CPC);
        }

        class ClosestPair
        {
            //가장 가까운 거리, 두 점
        }
        private void PrintPoint()
        {
            foreach (var p in points)
                Console.WriteLine(p.X + " , " + p.Y);
        }

        //points
        //private double Dist( int i,  int j)
        //{
        //    return Math.Sqrt((points[i].X - points[j].X) * (points[i].X - points[j].X) +
        //         (points[i].Y - points[j].Y) * (points[i].Y - points[j].Y));
        //}
    }
}
