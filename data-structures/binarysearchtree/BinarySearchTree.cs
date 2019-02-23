using System;
using System.Collections.Generic;
using System.Linq;

namespace binarysearchtree
{
    public class BinarySearchTree
    {
        public int Value { get; private set; }

        public BinarySearchTree Parent { get; set; }

        public BinarySearchTree Left { get; set; }

        public BinarySearchTree Right { get; set; }

        public bool IsRoot => Parent == null;

        public bool IsLeaf => Left == null && Right == null;

        public bool IsLeftChild => Parent?.Left == this;

        public bool IsRightChild => Parent?.Right == this;

        public bool HasLeftChild => Left != null;

        public bool HasRightChild => Right != null;

        public bool HasAnyChild => Left == null || Right == null;

        public bool HasBothChildren => Left != null && Right != null;

        public int Count => (Left?.Count ?? 0) + 1 + (Right?.Count ?? 0);

        public BinarySearchTree(int value) => Value = value;

        public BinarySearchTree(List<int> values) => values.ForEach((value) => Insert(value));

        public void Insert(int newValue)
        {
            if (newValue < Value)
            {
                if (Left != null)
                {
                    Left.Insert(newValue);
                }
                else
                {
                    Left = new BinarySearchTree(newValue);
                    Left.Parent = this;
                }
            }
            else
            {
                if (Right != null)
                {
                    Right.Insert(newValue);
                }
                else
                {
                    Right = new BinarySearchTree(newValue);
                    Right.Parent = this;
                }
            }
        }

        public BinarySearchTree Search(int value)
        {
            if (value < Value)
                return Left?.Search(value);
            else if (value > Value)
                return Right?.Search(value);
            else
                return this;
        }

        public void Traverse(TraverseOrder traverseOrder)
        {
            switch (traverseOrder)
            {
                case TraverseOrder.In:
                    TraverseInOrder();
                    break;
                case TraverseOrder.Pre:
                    TraversePreOrder();
                    break;
                case TraverseOrder.Post:
                    TraversePostOrder();
                    break;
            }
        }

        private void TraverseInOrder()
        {
            Left?.TraverseInOrder();
            Console.WriteLine(Value);
            Right?.TraverseInOrder();
        }

        private void TraversePreOrder()
        {
            Console.WriteLine(Value);
            Left?.TraverseInOrder();
            Right?.TraverseInOrder();
        }

        private void TraversePostOrder()
        {
            Left?.TraverseInOrder();
            Right?.TraverseInOrder();
            Console.WriteLine(Value);
        }
    }
}