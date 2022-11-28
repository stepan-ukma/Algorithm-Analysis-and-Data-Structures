namespace Lab6
{
    public class MyGraph
    {
        public List<Vertix> Vertices { get; } = new List<Vertix>();

        public void AddVertix(int vertixValue)
        {
            Vertices.Add(new Vertix(vertixValue));
        }

        public Vertix FindVertix(int vertixValue)
        {
            foreach (var p in Vertices)
            {
                if (p.Value.Equals(vertixValue))
                {
                    return p;
                }
            }

            return null;
        }

        public void AddEdge(int firstValue, int secondValue, int weight)
        {
            var p1 = FindVertix(firstValue);
            var p2 = FindVertix(secondValue);

            if (p2 != null && p1 != null)
            {
                p1.AddEdge(p2, weight);
                p2.AddEdge(p1, weight);
            }
        }
    }
}
