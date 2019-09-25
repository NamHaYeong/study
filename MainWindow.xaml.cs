﻿using System;
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

namespace Quick
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        const int SIZE = 100000;  // 데이터 갯수
        const int MAX = 1000000; // 랜덤 숫자의 상한

        int[] a = new int[SIZE];
        Random r = new Random();
        public MainWindow()
        {
            InitializeComponent();
            MakeRandomArray();
            PrintArray();
        }

        private void PrintArray()
        {
            textBox.Text += "\n";
            for (int i = 0; i < 10; i++)
                textBox.Text += a[i] + " ";
            textBox.Text += "...";
            for (int i = SIZE - 10; i < SIZE; i++)
                textBox.Text += a[i] + " ";


        }

        private void MakeRandomArray()
        {
            for (int i = 0; i < SIZE; i++)
                a[i] = r.Next(MAX);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            QuickSort(a, 0, SIZE - 1);
            watch.Stop();
            textBox.Text += " \n " + watch.ElapsedMilliseconds + " ms ";
            PrintArray();
        }

        private void QuickSort(int[] a, int left, int right)
        {
            if(left < right)
            {
                int p = Partition(a, left, right);

                QuickSort(a, left, p - 1);
                QuickSort(a, p + 1, right);
            }
        }

        private int Partition(int[] a, int left, int right)
        {
            // 피봇을 A[left]~A[right] 중에서 선택하고, 
            int pivot = a[left];
            // 피봇을 A[left]와 자리를 바꾼 후, 
            // 피봇과  배열의 각 원소를 비교하여 피봇보다 
            // 작은  숫자들은 A[left]~A[p - 1]로 옮기고, 
            // 피봇보다  큰 숫자들은 A[p + 1]~A[right]로 옮기며,
            int p = left++;
            int upper = right;
            int lower = left;

            while(true)
            {
                while (left <= upper && a[left] <= pivot)
                    left++;
                while (right >= lower && a[right] >= pivot)
                    right--;
                //left 와 right 인덱스의 값을 바꿈
                if (left < right)
                {
                    int t = a[left];
                    a[left] = a[right];
                    a[right] = t;
                }
                else
                    break;
            }
            // 피봇은 A[p]에 놓는다.
            int tmp = a[p];
            a[p] = a[right];
            a[right] = tmp;
            return right;

        }

        private void SlowSort_Click(object sender, RoutedEventArgs e)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            SlowSort(a, 0, SIZE - 1);
            watch.Stop();
            textBox.Text += " \n " + watch.ElapsedMilliseconds + " ms ";
            PrintArray();
        }

        private void SlowSort(int[] a, int left, int right)
        {
            for (int i = 0; i < SIZE-1; i++)
                for (int j = i+1; j < SIZE; j++)
                    if(a[i]> a[j])
                {
                        int t = a[i];
                        a[i] = a[j];
                        a[j] = t;
                }

            
        }
    }
}