namespace Lab6
{
    public class Dijkstra
    {
        MyGraph graph;

        List<VertixInfo> data;

        public Dijkstra(MyGraph graph)
        {
            this.graph = graph;
        }

        void InitData()
        {
            data = new List<VertixInfo>();
            foreach (var p in graph.Vertices)
            {
                data.Add(new VertixInfo(p));
            }
        }

        VertixInfo GetVertixData(Vertix v)
        {
            foreach (var i in data)
            {
                if (i.Vertix.Equals(v))
                {
                    return i;
                }
            }

            return null;
        }

        public VertixInfo FindUnvisitedVertixWithMinSum()
        {
            var minValue = int.MaxValue;
            VertixInfo minVertixInfo = null;
            foreach (var d in data)
            {
                if (d.IsUnvisited && d.EdgesWeightSum < minValue)
                {
                    minVertixInfo = d;
                    minValue = d.EdgesWeightSum;
                }
            }

            return minVertixInfo;
        }

        public string FindShortestPath(int startValue, int finishValue)
        {
            return FindShortestPath(graph.FindVertix(startValue), graph.FindVertix(finishValue));
        }

        public string FindShortestPath(Vertix startPoint, Vertix finishPoint)
        {
            InitData();
            var first = GetVertixData(startPoint);
            first.EdgesWeightSum = 0;

            while (true)
            {
                var current = FindUnvisitedVertixWithMinSum();
                if (current == null)
                {
                    break;
                }

                SetSumToNextVertix(current);
            }

            return GetPath(startPoint, finishPoint);
        }

        void SetSumToNextVertix(VertixInfo info)
        {
            info.IsUnvisited = false;

            foreach (var e in info.Vertix.Edges)
            {
                var nextInfo = GetVertixData(e.AdjVertix);
                var sum = info.EdgesWeightSum + e.EdgeWeight;

                if (sum < nextInfo.EdgesWeightSum)
                {
                    nextInfo.EdgesWeightSum = sum;
                    nextInfo.PrevVertix = info.Vertix;
                }
            }
        }

        string GetPath(Vertix startVertix, Vertix endVertix)
        {
            var path = endVertix.ToString();

            while (startVertix != endVertix)
            {
                endVertix = GetVertixData(endVertix).PrevVertix;
                path = endVertix.ToString() + path;
            }

            return path;
        }
    }
}