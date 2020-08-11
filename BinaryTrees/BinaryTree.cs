using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace BinaryTrees
{
    public class BinaryTree<T> : IEnumerable<T>
        where T : IComparable
    {
        class Node
        {
            public T Value { get; set; }
            public Node Parent { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
            public int mostLeftIndex { get; set; }
            public Node(T value)
            {
                Value = value;
            }
        }

        Node Root { get; set; }
        public int Count { get; private set; }

        public T this[int index]
        {
            get { return GetIndex(index, Root); }
        }

        private T GetIndex(int index, Node root)
        {
            if (root == null || index > Count - 1 || index < 0)
                throw new IndexOutOfRangeException();

            if (root.mostLeftIndex == index) return root.Value;

            var tempIndex = 0;
            while (true)
            {
                if (root.mostLeftIndex + tempIndex > index)
                    root = root.Left;
                else if (tempIndex + root.mostLeftIndex == index)
                    return root.Value;
                else
                {
                    tempIndex += root.mostLeftIndex + 1;
                    root = root.Right;
                }
            }            
        }

        public void Add(T value)
        {
            if (Root == null)
            {
                Root = new Node(value);
                Count++;
            }
            else AddToRoot(value, Root);
        }

        private void AddToRoot(T value, Node root)
        {
            while (true)
            {
                if (value.CompareTo(root.Value) < 0)
                {
                    root.mostLeftIndex++;
                    if (root.Left == null)
                    {
                        var newRoot = new Node(value);
                        newRoot.Parent = root;
                        root.Left = newRoot;
                        Count++;
                        break;
                    }
                    root = root.Left;
                }
                else
                {
                    if (root.Right == null)
                    {
                        var newRoot = new Node(value);
                        newRoot.Parent = root;
                        root.Right = newRoot;
                        Count++;
                        break;
                    }
                    root = root.Right;
                }
            }
        }

        public bool Contains(T value)
        {
            if (Root == null) return false;
            if (value.CompareTo(Root.Value) == 0) return true;

            var root = Root;
            while (true)
            {
                if (value.CompareTo(root.Value) == 0)
                    return true;
                else if (value.CompareTo(root.Value) < 0)
                {
                    if (root.Left == null)
                        return false;
                    root = root.Left;
                }
                else
                {
                    if (root.Right == null)
                        return false;
                    root = root.Right;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            if (Root == null) return null;
            return InOrder(Root).GetEnumerator();
        }

        private IEnumerable<T> InOrder(Node root)
        {
            int count = 0;
            var visitedRoots = new HashSet<Node>();
            while (count != Count)
            {
                while (root.Left != null &&
                      !visitedRoots.Contains(root.Left))
                    root = root.Left;
                if (!visitedRoots.Contains(root))
                {
                    yield return root.Value;
                    visitedRoots.Add(root);
                    count++;
                }

                if (root.Right != null && !visitedRoots.Contains(root.Right))
                    root = root.Right;
                else if (root.Parent != null) root = root.Parent;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}