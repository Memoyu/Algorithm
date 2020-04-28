/*
题目名称：
二叉搜索树的后序遍历序列

题目描述：
输入一个非空整数数组，判断该数组是不是某二叉搜索树的后序遍历的结果。
如果是则输出Yes,否则输出No。假设输入的数组的任意两个数字都互不相同。

代码结构：
class Solution
{
    public bool VerifySquenceOfBST(int[] sequence)
    {
        // write code here
    }
}

补充：
二叉搜索树（Binary Search Tree）定义：
1. 可以是空树
2. 若不是空树
    若它的左子树不空，则左子树所有节点的值均小于它的根节点的值
    若它的右子树不空，则右子树所有节点的值均大于它的根节点的值
    它的左，右子树也分别为二叉搜索树   
*/
using System;
namespace VerifySquenceOfBST {

    class Solution {

        /// <summary>
        /// 解法1，递归
        /// 基本思路：
        /// 对于一个二叉搜索树的后序序列，最后一个元素一定是根
        /// 如果去掉最后一个元素，即去掉根元素，剩下的序列应该满足
        /// 前一段（左子树）都小于根元素
        /// 后一段（右子树）都大于根元素
        /// 然后这两段（子树）也必须是合法的二叉搜索树后序序列。使用递归处理。
        /// </summary>

        public bool VerifySquenceOfBST(int[] sequence)
        {
            if(sequence == null || sequence.Length == 0) return false;
            return VerifySquenceOfBSTImpl(sequence, 0, sequence.Length - 1);
        }

        public bool VerifySquenceOfBSTImpl(int[] sequence, int left, int right){
            if(left >= right) return true;
            int index = right - 1;
            for(int i = left; i < right; i ++){
                if(sequence[i] > sequence[right])
                    index = i;
                else if(index != right - 1)
                    return false;
            }
            return VerifySquenceOfBSTImpl(sequence, left, index) && VerifySquenceOfBSTImpl(sequence, index, right - 1);
        }

        public void Test() {
            
            int[] sequence = new int[]{1, 2, 3, 4, 5};
            sequence = new int[]{1, 6, 5, 9, 13, 12, 8};
            sequence = new int[]{1, 6, 5, 9, 11, 7, 8};
            // sequence = new int[]{};

            Console.WriteLine(VerifySquenceOfBST(sequence));
        }
    }
}
