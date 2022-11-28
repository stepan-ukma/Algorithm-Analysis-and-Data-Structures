namespace Lab5
{
    public class Graph
    {
        private int verticesCount;

        // Adjacency List
        private List<List<int>> adjacencyList;

        public Graph(int vertices)
        {
            verticesCount = vertices;
            adjacencyList = new List<List<int>>(verticesCount);

            for (int i = 0; i < vertices; i++)
                adjacencyList.Add(new List<int>());
        }

        public void AddEdge(int vertex, int adjVertex) 
        { 
            adjacencyList[vertex].Add(adjVertex); 
        }
        public void TopologicalSort()
        {
            Stack<int> stack = new Stack<int>();

            // Mark all the vertices as not visited
            var visited = new bool[verticesCount];

            // Visit from each vertix if not already visited
            for (int i = 0; i < verticesCount; i++)
            {
                if (visited[i] == false)
                    SortUtil(i, visited, stack);
            }

            foreach (var vertex in stack)
            {
                Console.Write(vertex + " ");
            }
        }

        private void SortUtil(int start, bool[] visited, Stack<int> stack)
        {
            visited[start] = true;

            // Recur for all the vertices adjacent to this vertex
            foreach (var vertex in adjacencyList[start])
            {
                if (!visited[vertex])
                    SortUtil(vertex, visited, stack);
            }

            stack.Push(start);
        }
    }
}
