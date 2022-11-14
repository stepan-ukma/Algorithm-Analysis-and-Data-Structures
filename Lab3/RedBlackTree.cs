using static Lab3.ColorEnum;

namespace Lab3
{
    public class RedBlackTree : IRedBlackTree
    {
        private RBNode _rootNode;
        public static RBNode leaf;

        public Boolean IsEmpty
        {
            get { return (_rootNode == null); }
        }

        public RBNode MinValue
        {
            get
            {
                if (IsEmpty)
                    throw new Exception("Error: Cannot find minimum value of an empty tree");

                var node = _rootNode;
                while (node.left != null)
                    node = node.left;

                return node;
            }
        }

        private void LeftRotate(RBNode current)
        {
            RBNode newItme = current.right;
            current.right = newItme.left;

            if (newItme.left != leaf)
            {
                newItme.left.parent = current;
            }

            newItme.parent = current.parent;

            if (current.parent == leaf)
            {
                _rootNode = newItme;
            }
            else if (current.parent.left == current)
            {
                current.parent.left = newItme;
            }
            else
            {
                current.parent.right = newItme;
            }

            newItme.left = current;
            current.parent = newItme;

        }

        private void RightRotate(RBNode current)
        {
            RBNode newItem = current.left;
            current.left = newItem.right;

            if (newItem.right != leaf)
            {
                newItem.right.parent = current;
            }

            newItem.parent = current.parent;

            if (current.parent == leaf)
            {
                _rootNode = newItem;
            }
            else if (current.parent.right == current)
            {
                current.parent.right = newItem;
            }
            else
            {
                current.parent.left = newItem;
            }

            newItem.right = current;
            current.parent = newItem;
        }

        public void DisplayTree()
        {
            if (_rootNode == null)
            {
                Console.WriteLine("Nothing in the tree!");
                return;
            }
            if (_rootNode != null)
            {
                InOrderDisplay(_rootNode);
            }
        }

        public RBNode Find(int key)
        {
            RBNode temp = _rootNode;    

            while (temp != null)
            {
                if (key < temp.value)
                {
                    temp = temp.left;
                }
                else if (key > temp.value)
                {
                    temp = temp.right;
                }
                else
                {
                    return temp;
                }
            }

            return null;
        }

        public void Insert(int item)
        {
            RBNode newItem = new RBNode();
            newItem.parent = null;
            newItem.value = item;
            newItem.left = leaf;
            newItem.right = leaf;
            newItem.color = Color.Red;
            RBNode y = leaf;
            RBNode r = _rootNode;

            while (r != leaf)
            {
                y = r;

                if (newItem.value.CompareTo(r.value) < 0)
                {
                    r = r.left;
                }
                else if (newItem.value.CompareTo(r.value) > 0)
                {
                    r = r.right;
                }
                else if (newItem.value.CompareTo(r.value) == 0)
                {
                    Console.WriteLine($"{item} is already in the tree");
                    return;
                }
            }

            newItem.parent = y;

            if (y == leaf)
            {
                _rootNode = newItem;
            }
            else if (newItem.value.CompareTo(y.value) < 0)
            {
                y.left = newItem;
            }
            else if (newItem.value.CompareTo(y.value) > 0)
            {
                y.right = newItem;
            }
            else if (newItem.value.CompareTo(y.value) == 0)
            {
                Console.WriteLine($"{item} is already in the tree");
                return;
            }

            if (newItem.parent == leaf)
            {
                newItem.color = Color.Black;
                return;
            }

            if (newItem.parent.parent == leaf)
            {
                return;
            }

            InsertFixUp(newItem);
        }
        private void InOrderDisplay(RBNode current)
        {
            if (current != null)
            {
                InOrderDisplay(current.left);
                if (current.color == Color.Black)
                {
                    Console.Write("({0}, {1}) ", current.value, current.color);
                }
                else
                {
                    Console.Write("({0}, {1})   ", current.value, current.color);
                }

                InOrderDisplay(current.right);
            }
        }
        private void InsertFixUp(RBNode newItem)
        {
            RBNode y;

            while (newItem != _rootNode && newItem.parent.color == Color.Red)
            {
                if (newItem.parent == newItem.parent.parent.left)
                {
                    y = newItem.parent.parent.right;

                    if (y.color == Color.Red && y != null)
                    {
                        newItem.parent.color = Color.Black;
                        y.color = Color.Black;
                        newItem.parent.parent.color = Color.Red;
                        newItem = newItem.parent.parent;
                    }
                    else
                    {
                        if (newItem == newItem.parent.right)
                        {
                            newItem = newItem.parent;
                            LeftRotate(newItem);
                        }
                        newItem.parent.color = Color.Black;
                        newItem.parent.parent.color = Color.Red;
                        RightRotate(newItem.parent.parent);
                    }
                }
                else
                {

                    y = newItem.parent.parent.left;

                    if (y != null && y.color == Color.Red)
                    {
                        newItem.parent.color = Color.Black;
                        y.color = Color.Black;
                        newItem.parent.parent.color = Color.Red;
                        newItem = newItem.parent.parent;
                    }
                    else
                    {
                        if (newItem == newItem.parent.left)
                        {
                            newItem = newItem.parent;
                            RightRotate(newItem);
                        }
                        newItem.parent.color = Color.Black;
                        newItem.parent.parent.color = Color.Red;
                        LeftRotate(newItem.parent.parent);
                    }

                }

                if (newItem == _rootNode)
                    break;

            }

            _rootNode.color = Color.Black;
        }

        public void Remove(int key)
        {
            // first find the node in the tree to delete and assign to item pointer/reference
            RBNode item = Find(key);
            RBNode x = null;
            RBNode y = null;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.left == null || item.right == null)
            {
                y = item;
            }
            else
            {
                y = Successor(item);
            }
            if (y.left != null)
            {
                x = y.left;
            }
            else
            {
                x = y.right;
            }
            if (x != null)
            {
                x.parent = y;
            }
            if (y.parent == null)
            {
                _rootNode = x;
            }
            else if (y == y.parent.left)
            {
                y.parent.left = x;
            }
            else
            {
                y.parent.left = x;
            }
            if (y != item)
            {
                item.value = y.value;
            }
            if (y.color == Color.Black)
            {
                RemoveFixUp(x);
            }

        }

        /// Checks the tree for any violations after deletion and performs a fix
        private void RemoveFixUp(RBNode X)
        {

            while (X != null && X != _rootNode && X.color == Color.Black)
            {
                if (X == X.parent.left)
                {
                    RBNode W = X.parent.right;

                    if (W.color == Color.Red)
                    {
                        W.color = Color.Black; 
                        X.parent.color = Color.Red;
                        LeftRotate(X.parent);
                        W = X.parent.right;
                    }

                    if (W.left.color == Color.Black && W.right.color == Color.Black)
                    {
                        W.color = Color.Red;
                        X = X.parent;
                    }
                    else if (W.right.color == Color.Black)
                    {
                        // Case 3
                        W.left.color = Color.Black;
                        W.color = Color.Red;
                        RightRotate(W);
                        W = X.parent.right;
                    }

                    W.color = X.parent.color;
                    X.parent.color = Color.Black;
                    W.right.color = Color.Black;
                    LeftRotate(X.parent);
                    X = _rootNode;
                }
                else
                {
                    RBNode W = X.parent.left;

                    if (W.color == Color.Red)
                    {
                        W.color = Color.Black;
                        X.parent.color = Color.Red;
                        RightRotate(X.parent);
                        W = X.parent.left;
                    }

                    if (W.right.color == Color.Black && W.left.color == Color.Black)
                    {
                        W.color = Color.Black;
                        X = X.parent;
                    }
                    else if (W.left.color == Color.Black)
                    {
                        W.right.color = Color.Black;
                        W.color = Color.Red;
                        LeftRotate(W);
                        W = X.parent.left;
                    }

                    W.color = X.parent.color;
                    X.parent.color = Color.Black;
                    W.left.color = Color.Black;
                    RightRotate(X.parent);
                    X = _rootNode;
                }
            }
            if (X != null)
                X.color = Color.Black;
        }
        private RBNode Minimum(RBNode X)
        {
            while (X.left.left != null)
                X = X.left;

            if (X.left.right != null)
                X = X.left.right;

            return X;
        }
        private RBNode Successor(RBNode X)
        {
            if (X.left != null)
            {
                return Minimum(X);
            }
            else
            {
                RBNode Y = X.parent;
                while (Y != null && X == Y.right)
                {
                    X = Y;
                    Y = Y.parent;
                }
                return Y;
            }
        }
    }
}
