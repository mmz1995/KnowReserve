using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> origin = new List<int> { -1,101, 15, 20, 11, 10, 30, 45, 8, 25, 64, 52, 30 };
            SelectionSort(origin);
        }

        //冒泡排序
        //每次都选出最大的那个放到最后，每次比较的时候都比上次少比较最后一个
        static void BubbleSort(List<int> origin)
        {
            int right;
            int length = origin.Count;
            //一次循环可以把最大的放在最后
            for (int i = 0; i < length - 1; i++)
            {
                //下一次循环可以逐渐比上次少比较一个，直到把所有的都比较一遍
                for (int k = 0; k < length - i - 1; k++)
                {
                    if (origin[k] > origin[k + 1])
                    {
                        right = origin[k];
                        origin[k] = origin[k+1];
                        origin[k+1] = right;
                    }
                }
            }
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(origin[i]);
            }
        }

        //选择排序
        //实质上把origin分成了两部分，一部分是已经排好的，有序的；另一部分是未排序的
        static void SelectionSort(List<int> origin)
        {
            int length = origin.Count;
            int minIndex;
            int temp;
            
            //i <length-1 ---到最后一个，不用比较了，故-1
            for (int i = 0;i <length-1;i++ )
            {
                minIndex = i;  //默认最小值的index              
                for (int j = i+1; j < length; j++)
                {
                    if (origin[j] < origin[minIndex])
                    {
                        minIndex = j;       //记录未排序部分的最小值的index
                    }
                }

                //把最小的和当前替换
                temp = origin[i];
                origin[i] = origin[minIndex];
                origin[minIndex] = temp;               
            }
            for (int i = 0; i < length; i++)
            {
                Console.WriteLine(origin[i]);
            }
        }
    }
}
