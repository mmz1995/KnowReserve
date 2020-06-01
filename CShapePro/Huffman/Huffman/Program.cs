using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huffman
{
    class Program
    {
        static Node root;
        static void Main(string[] args)
        {
            int[] weights = { 25, 3, 9, 7, 18, 2 ,102,52};
            CreateHuffman(weights);
        }

        static void CreateHuffman(int[] _weights)
        {
            int length = _weights.Length;
            for(int i = 0; i < length - 1; i++)
            {
                int origin = _weights[i];
                for (int j = 0; j < length - i - 1; j++)
                {
                    if (_weights[j] > _weights[j+1]) {
                        int temp = _weights[j];
                        _weights[j] = _weights[j + 1];
                        _weights[j + 1] = temp;
                    }
                }
            }
            
            //Queue<Node> priorityQueue = new Queue<Node>();
            List<Node> priorityList = new List<Node>();
            for (int i = _weights.Length-1; i >-1; i--)
            {
                Node node = new Node(_weights[i]);               
                priorityList.Add(node);
            }

            while (priorityList.Count > 1)
            {
                Node left = priorityList.Last();
                priorityList.Remove(left);
                Node right = priorityList.Last();
                priorityList.Remove(right);
             
                Node parent = new Node(left.weight + right.weight, left, right);
                priorityList.Add(parent);
                priorityList.Sort((x,y)=> -x.weight.CompareTo(y.weight));
                //Console.WriteLine("OrderBy____________________________________________:");
                //foreach (Node node in priorityList)
                //{
                //    Console.WriteLine("OrderBy________:"+node.weight);
                //}
                //Console.WriteLine("count___:" + priorityList.Count + "___left___:" + left.weight + "___right___:" + right.weight + "___parent____:" + parent.weight);
            }

            root = priorityList.Last();

            Console.WriteLine("根节点：" + root.weight);
            ShowHuffmanTree(root);
        }

        static void ShowHuffmanTree(Node curNode)
        {
            Node child_l = curNode.left;
            if (child_l != null)
            {
                Console.WriteLine(curNode.weight+"___left child ：" + child_l.weight);
                ShowHuffmanTree(child_l);
            }

            Node child_r = curNode.right;
            if (child_r != null)
            {
                Console.WriteLine(curNode.weight + "___right child :  " + child_r.weight);
                ShowHuffmanTree(child_r);
            }
            
        }

        class Node
        {
            public int weight = 0;
            public Node left;
            public Node right;

            public Node(int _weight)
            {
                this.weight = _weight;
            }
            public Node(int _weight,Node _left,Node _right)
            {
                this.weight = _weight;
                this.left = _left;
                this.right = _right;
            }
        }
    }
}
