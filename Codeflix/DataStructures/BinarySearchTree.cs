using System;
using System.Collections.Generic;
using Codeflix.Models;

namespace Codeflix.DataStructures
{
    public class BinarySearchTree
    {
        private BSTNode root;

        public BinarySearchTree()
        {
            root = null;
        }

        public bool Insert(MediaItem item)
        {
            bool inserted = false;
            root = InsertRecursive(root, item, ref inserted);
            return inserted;
        }

        private BSTNode InsertRecursive(BSTNode node, MediaItem item, ref bool inserted)
        {
            if (node == null)
            {
                inserted = true;
                return new BSTNode(item);
            }

            int comparison = string.Compare(item.Title, node.Data.Title, StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
            {
                node.Left = InsertRecursive(node.Left, item, ref inserted);
            }
            else if (comparison > 0)
            {
                node.Right = InsertRecursive(node.Right, item, ref inserted);
            }

            return node;
        }

        public MediaItem Search(string title)
        {
            BSTNode result = SearchRecursive(root, title);
            return result?.Data;
        }

        private BSTNode SearchRecursive(BSTNode node, string title)
        {
            if (node == null)
            {
                return null;
            }

            int comparison = string.Compare(title, node.Data.Title, StringComparison.OrdinalIgnoreCase);

            if (comparison == 0)
            {
                return node;
            }
            else if (comparison < 0)
            {
                return SearchRecursive(node.Left, title);
            }
            else
            {
                return SearchRecursive(node.Right, title);
            }
        }

        public void DisplayInOrder()
        {
            if (root == null)
            {
                Console.WriteLine("Library is empty.");
                return;
            }

            InOrderTraversal(root);
        }

        private void InOrderTraversal(BSTNode node)
        {
            if (node != null)
            {
                InOrderTraversal(node.Left);
                Console.WriteLine(node.Data);
                InOrderTraversal(node.Right);
            }
        }

        public bool Delete(string title)
        {
            bool deleted;
            root = DeleteRecursive(root, title, out deleted);
            return deleted;
        }

        private BSTNode DeleteRecursive(BSTNode node, string title, out bool deleted)
        {
            deleted = false;

            if (node == null)
            {
                return null;
            }

            int comparison = string.Compare(title, node.Data.Title, StringComparison.OrdinalIgnoreCase);

            if (comparison < 0)
            {
                node.Left = DeleteRecursive(node.Left, title, out deleted);
            }
            else if (comparison > 0)
            {
                node.Right = DeleteRecursive(node.Right, title, out deleted);
            }
            else
            {
                deleted = true;

                if (node.Left == null)
                    return node.Right;

                if (node.Right == null)
                    return node.Left;

                BSTNode minNode = FindMin(node.Right);
                node.Data = minNode.Data;
                node.Right = DeleteRecursive(node.Right, minNode.Data.Title, out bool tempDeleted);
            }

            return node;
        }

        private BSTNode FindMin(BSTNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }
            return node;
        }
        public void Clear()
        {
            root = null;
        }
        public List<MediaItem> GetAllItems()
        {
            List<MediaItem> items = new List<MediaItem>();
            CollectInOrder(root, items);
            return items;
        }

        private void CollectInOrder(BSTNode node, List<MediaItem> items)
        {
            if (node != null)
            {
                CollectInOrder(node.Left, items);
                items.Add(node.Data);
                CollectInOrder(node.Right, items);
            }
        }
    }
}