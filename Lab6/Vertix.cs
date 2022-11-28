namespace Lab6
{
    public class Vertix
    {
        public int Value { get; }
        public List<Edge> Edges { get; }

        public Vertix(int value)
        {
            Value = value;
            Edges = new List<Edge>();
        }

        public void AddEdge(Edge edge) => Edges.Add(edge);

        public void AddEdge(Vertix v, int edgeWeight)
        {
            AddEdge(new Edge(v, edgeWeight));
        }

        public override string ToString() => Value.ToString() + " -> ";
    }
}
