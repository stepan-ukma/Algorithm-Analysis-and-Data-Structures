using static Lab3.ColorEnum;

namespace Lab3
{
    public class RedBlackTree : IRedBlackTree
    {
        private RBNode _rootNode;
        private int _nodeCount;

        public int NodeCount
        {
            get { return _nodeCount; }
        }

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

        private void LeftRotate(RBNode X)
        {
            RBNode Y = X.right; // set Y
            X.right = Y.left; // turn Y's left subtree into X's right subtree
            if (Y.left != null)
            {
                Y.left.parent = X;
            }
            if (Y != null)
            {
                Y.parent = X.parent; // link X's parent to Y
            }
            if (X.parent == null)
            {
                _rootNode = Y;
            }
            if (X.parent != null)
            {
                if (X == X.parent.left)
                {
                    X.parent.left = Y;
                }
                else
                {
                    X.parent.right = Y;
                }
            }

            Y.left = X; // put X on Y's left
            if (X != null)
            {
                X.parent = Y;
            }

        }

        private void RightRotate(RBNode Y)
        {
            // Right rotate is simply mirror code from left rotate
            RBNode X = Y.left;
            Y.left = X.right;

            if (X.right != null)
                X.right.parent = Y;

            if (X != null)
                X.parent = Y.parent;

            if (Y.parent == null) 
                _rootNode = X;

            if (Y.parent != null)
            {
                if (Y == Y.parent.right)
                    Y.parent.right = X;

                if (Y == Y.parent.left)
                    Y.parent.left = X;
            }
            
            X.right = Y; // put Y on X's right

            if (Y != null)
                Y.parent = X;
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
            RBNode newItem = new RBNode(item);

            if (_rootNode == null)
            {
                _rootNode = newItem;
                _rootNode.color = Color.Black;
                _nodeCount++;
                return;
            }

            RBNode Y = null;
            RBNode X = _rootNode;

            while (X != null)
            {
                Y = X;
                if (newItem.value < X.value)
                {
                    X = X.left;
                }
                else
                {
                    X = X.right;
                }
            }

            newItem.parent = Y;

            if (Y == null)
            {
                _rootNode = newItem;
            }
            else if (newItem.value < Y.value)
            {
                Y.left = newItem;
            }
            else
            {
                Y.right = newItem;
            }

            newItem.left = null;
            newItem.right = null;
            newItem.color = Color.Red; // color the new node red
            InsertFixUp(newItem);      // check for violations and fix
            _nodeCount++;
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
        private void InsertFixUp(RBNode item)
        {
            // Checks Red-Black Tree properties
            while (item != _rootNode && item.parent.color == Color.Red)
            {
                /*We have a violation*/
                if (item.parent == item.parent.parent.left)
                {
                    RBNode Y = item.parent.parent.right;
                    if (Y != null && Y.color == Color.Red) // Case 1: uncle is red
                    {
                        item.parent.color = Color.Black;
                        Y.color = Color.Black;
                        item.parent.parent.color = Color.Red;
                        item = item.parent.parent;
                    }
                    else // Case 2: uncle is black
                    {
                        if (item == item.parent.right)
                        {
                            item = item.parent;
                            LeftRotate(item);
                        }
                        // Case 3: recolor & rotate
                        item.parent.color = Color.Black;
                        item.parent.parent.color = Color.Red;
                        RightRotate(item.parent.parent);
                    }

                }
                else
                {
                    // mirror image of code above
                    RBNode X = null;

                    X = item.parent.parent.left;
                    if (X != null && X.color == Color.Black) // Case 1
                    {
                        item.parent.color = Color.Red;
                        X.color = Color.Red;
                        item.parent.parent.color = Color.Black;
                        item = item.parent.parent;
                    }
                    else // Case 2
                    {
                        if (item == item.parent.left)
                        {
                            item = item.parent;
                            RightRotate(item);
                        }
                        // Case 3: recolor & rotate
                        item.parent.color = Color.Black;
                        item.parent.parent.color = Color.Red;
                        LeftRotate(item.parent.parent);

                    }

                }
                _rootNode.color = Color.Black; // re-color the root black as necessary
            }
        }

        public void Remove(int key)
        {
            // first find the node in the tree to delete and assign to item pointer/reference
            RBNode item = Find(key);
            RBNode X = null;
            RBNode Y = null;

            if (item == null)
            {
                Console.WriteLine("Nothing to delete!");
                return;
            }
            if (item.left == null || item.right == null)
            {
                Y = item;
            }
            else
            {
                Y = Successor(item);
            }
            if (Y.left != null)
            {
                X = Y.left;
            }
            else
            {
                X = Y.right;
            }
            if (X != null)
            {
                X.parent = Y;
            }
            if (Y.parent == null)
            {
                _rootNode = X;
            }
            else if (Y == Y.parent.left)
            {
                Y.parent.left = X;
            }
            else
            {
                Y.parent.left = X;
            }
            if (Y != item)
            {
                item.value = Y.value;
            }
            if (Y.color == Color.Black)
            {
                RemoveFixUp(X);
            }

            _nodeCount--;
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
                        // Case 1
                        W.color = Color.Black; 
                        X.parent.color = Color.Red;
                        LeftRotate(X.parent);
                        W = X.parent.right;
                    }

                    if (W.left.color == Color.Black && W.right.color == Color.Black)
                    {
                        // Case 2
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

                    // Case 4
                    W.color = X.parent.color;
                    X.parent.color = Color.Black;
                    W.right.color = Color.Black;
                    LeftRotate(X.parent);
                    X = _rootNode;
                }
                else // mirror code from above with "right" & "left" exchanged
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
