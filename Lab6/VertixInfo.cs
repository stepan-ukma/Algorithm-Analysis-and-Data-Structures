namespace Lab6
{
    public class VertixInfo
    {
        public Vertix Vertix { get; set; }
        public bool IsUnvisited { get; set; }
        public int EdgesWeightSum { get; set; }
        public Vertix PrevVertix { get; set; }

        public VertixInfo(Vertix vertix)
        {
            Vertix = vertix;
            IsUnvisited = true;
            EdgesWeightSum = int.MaxValue;
            PrevVertix = null;
        }
    }
}