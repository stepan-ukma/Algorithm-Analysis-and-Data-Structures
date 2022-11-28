namespace Lab6
{
    public class Edge
    {
        public Vertix AdjVertix { get; }
        public int EdgeWeight { get; }
        public Edge(Vertix adjVertix, int weight)
        {
            AdjVertix = adjVertix;
            EdgeWeight = weight;
        }
    }
}
