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

        private void RemoveFixUp(RBNode newItem)
        {
            while (newItem != null && newItem != _rootNode && newItem.color == Color.Black)
            {
                if (newItem == newItem.parent.left)
                {
                    RBNode y = newItem.parent.right;

                    if (y.color == Color.Red)
                    {
                        y.color = Color.Black;
                        newItem.parent.color = Color.Red;
                        LeftRotate(newItem.parent);
                        y = newItem.parent.right;
                    }

                    if (y.left.color == Color.Black && y.right.color == Color.Black)
                    {
                        y.color = Color.Red;
                        newItem = newItem.parent;
                    }
                    else if (y.right.color == Color.Black)
                    {
                        y.left.color = Color.Black;
                        y.color = Color.Red;
                        RightRotate(y);
                        y = newItem.parent.right;
                    }

                    y.color = newItem.parent.color;
                    newItem.parent.color = Color.Black;
                    y.right.color = Color.Black;
                    LeftRotate(newItem.parent);
                    newItem = _rootNode;
                }
                else
                {
                    RBNode y = newItem.parent.left;

                    if (y.color == Color.Red)
                    {
                        y.color = Color.Black;
                        newItem.parent.color = Color.Red;
                        RightRotate(newItem.parent);
                        y = newItem.parent.left;
                    }

                    if (y.right.color == Color.Black && y.left.color == Color.Black)
                    {
                        y.color = Color.Black;
                        newItem = newItem.parent;
                    }
                    else if (y.left.color == Color.Black)
                    {
                        y.right.color = Color.Black;
                        y.color = Color.Red;
                        LeftRotate(y);
                        y = newItem.parent.left;
                    }

                    y.color = newItem.parent.color;
                    newItem.parent.color = Color.Black;
                    y.left.color = Color.Black;
                    RightRotate(newItem.parent);
                    newItem = _rootNode;
                }
            }
            if (newItem != null)
                newItem.color = Color.Black;

        }
        private RBNode Minimum(RBNode newItem)
        {
            while (newItem.left.left != null)
                newItem = newItem.left;

            if (newItem.left.right != null)
                newItem = newItem.left.right;

            return newItem;
        }
        private RBNode Successor(RBNode newItem)
        {
            if (newItem.left != null)
            {
                return Minimum(newItem);
            }
            else
            {
                RBNode y = newItem.parent;

                while (y != null && newItem == y.right)
                {
                    newItem = y;
                    y = y.parent;
                }

                return y;
            }
        }
    }
}
