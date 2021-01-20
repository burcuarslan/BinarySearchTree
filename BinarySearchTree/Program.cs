using System;

namespace BinarySearchTree
{
    public class LinkedTree
    { 
        public class Node 
        {
            public int key;
            public Node left;
            public Node right;
            public string  data;
            public Node(int key)
            {
                //data = null;
                this.key = key;
                left = right = null;
            }
        }
        public Node root;
       // public Node toDeleteChild;
        public void insert(int key)
        {
            Node parent = null;
            Node trav = root;
            while (trav != null)
            {
                parent=trav;
                if (key < trav.key)
                    trav = trav.left;
                else
                    trav = trav.right;
            }
            //Node newNode = new Node(key);
            if (parent == null)
                root = new Node(key);
            else if (key < parent.key)
                parent.left = new Node(key);
            else
                parent.right = new Node(key);
        }
        public string delete(int key)
        {
            // Find the node and its parent.
            Node parent = null;
            Node trav = root;
            while (trav != null && trav.key != key)
            {
                parent = trav;
                if (key < trav.key)
                    trav = trav.left;
                else
                    trav = trav.right;
            }
            // Delete the node (if any) and return the removed item.
            if (trav == null) // no such key
                return null;
            else
            {
                String removedData = trav.data;
                deleteNode(trav, parent);
                return removedData;
            }
        }
        public void deleteNode(Node toDelete, Node parent)
        {
            if (toDelete.left == null || toDelete.right == null)
            {

                Node toDeleteChild = null;
                if (toDelete.left != null)
                {
                    toDeleteChild = toDelete.left;
                }
                else
                {
                    toDeleteChild = toDelete.right;
                }
                if (toDelete==root)
                {
                    root = toDeleteChild;
                }
                else if (toDelete.key<parent.key)
                {
                    parent.left = toDeleteChild;
                }
                else
                {
                    parent.right = toDeleteChild;
                }
            }
            else
            {
                Node repParentParent=null;
                Node replacementParent = toDelete;
                Node replacement = toDelete.right;
                while (replacement!=null)
                {
                    repParentParent = replacementParent;
                    replacementParent = replacement;
                    replacement = replacement.left;
                }
                toDelete.key = replacementParent.key;
                deleteNode(replacementParent,repParentParent);
            }
        }
        void inorder()
        {
            inorderRec(root);
        }
        public void inorderRec(Node root)
        {
            if (root!=null)
            {
                inorderRec(root.left);
                    Console.WriteLine(root.key);
                inorderRec(root.right);
            }
        }
    
        static void Main(string[] args)
        {
            LinkedTree tree = new LinkedTree();
            tree.insert(38);
            tree.insert(17);
            tree.insert(20);
            tree.insert(18);
            tree.insert(7);
            tree.insert(9);
            tree.insert(51);
            tree.insert(50);
            tree.insert(67);
            tree.inorder();
            Console.WriteLine("****************");
            tree.delete(17);
            tree.inorder();
        }
    }
}
