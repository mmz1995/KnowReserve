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
            int[] weights = { 25, 3, 9, 7, 18, 2 };
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

            for (int i = 0; i < length; i++)
            {
                Console.WriteLine("priorityQueue：___ index____:" + i + "___weight___:" + _weights[i]);
            }

            Queue<Node> priorityQueue = new Queue<Node>();
            for(int i = 0; i < _weights.Length; i++)
            {
                Node node = new Node(_weights[i]);
                priorityQueue.Enqueue(node);
            }

            while (priorityQueue.Count > 1)
            {
                Node left = priorityQueue.Dequeue();
                Node right = priorityQueue.Peek();
                priorityQueue.TrimExcess();
                Node parent = new Node(left.weight + right.weight, left, right);
                priorityQueue.Enqueue(parent);               
                
                Console.WriteLine("count___:" + priorityQueue.Count + "___left___:" + left.weight + "___right___:" + right.weight + "___parent____:" + parent.weight);
            }

            root = priorityQueue.Last();

            Console.WriteLine("根节点：" + root.weight);
            ShowHuffmanTree(root);
        }

        static void ShowHuffmanTree(Node curNode)
        {
            if (curNode.left != null)
            {
                Console.WriteLine(curNode.weight+"___left child ：" + curNode.left.weight);
                if (curNode.left.left != null)
                {
                    ShowHuffmanTree(curNode.left.left);
                }
            }

            if (curNode.right != null)
            {
                Console.WriteLine(curNode.weight + "___right child :  " + curNode.right.weight);
                if (curNode.right.right != null)
                {
                    ShowHuffmanTree(curNode.right.right);
                }
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
