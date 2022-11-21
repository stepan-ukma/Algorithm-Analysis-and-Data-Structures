using static Lab3.ColorEnum;

namespace Lab3
{
    public class RBNode
    {
        public int value;
        public RBNode left;
        public RBNode right;
        public RBNode parent;
        public Color color;

        public RBNode() { }
        public RBNode(int value) 
        { 
            this.value = value; 
        }
        public RBNode(Color color) 
        { 
            this.color = color; 
        }
        public RBNode(int value, Color color) 
        { 
            this.value = value; 
            this.color = color; 
        }
    }
}