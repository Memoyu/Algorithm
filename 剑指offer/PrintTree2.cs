/*
题目名称：
把二叉树打印成多行

题目描述：
从上到下按层打印二叉树，同一层结点从左至右输出。每一层输出一行

代码结构：
class Solution
{
    public List<List<int>> Print(TreeNode pRoot)
    {
        // write code here
    }
}
*/
using System;
using System.Collections.Generic;
namespace PrintTree2 {

    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode (int x)
        {
            val = x;
        }
    }

    class Solution {

        /// <summary>
        /// 解法1，层次遍历
        /// 基本思路：
        /// 利用一个辅助队列，队列中依次保存二叉树每一层的所有节点。
        /// </summary>

        public List<List<int>> Print(TreeNode pRoot)
        {
            List<List<int>> lists = new List<List<int>>();
            Queue<TreeNode> queue = new Queue<TreeNode>();
            queue.Enqueue(pRoot);
            while(queue.Count > 0){
                int count = queue.Count;
                List<int> list = new List<int>();
                for(int i = 0; i < count; i ++){
                    TreeNode node = queue.Dequeue();
                    if(node != null){
                        list.Add(node.val);
                        queue.Enqueue(node.left);
                        queue.Enqueue(node.right);
                    }
                }
                if(list.Count > 0){
                    lists.Add(list);
                }
            }
            return lists;
        }

        public void Dump(List<List<int>> lists) {
            foreach(List<int> list in lists){
                foreach(int i in list){
                    Console.Write(i + " ");
                }
                Console.WriteLine();
            }
        }

        public void Test() {
            TreeNode pRoot = null;
            pRoot = new TreeNode(0);
            pRoot.left = new TreeNode(1);
            pRoot.left.left = new TreeNode(2);
            pRoot.left.right = new TreeNode(3);
            pRoot.right = new TreeNode(4);
            pRoot.right.left = new TreeNode(5);
            pRoot.right.right = new TreeNode(6);
            pRoot.right.right.left = new TreeNode(7);
            pRoot.right.right.right = new TreeNode(8);
            
            Dump(Print(pRoot));
        }
    }
}
