namespace GraphAndSearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();
            graph.AddNode("Entrance"); 
            graph.AddNode("Carousel");
            graph.AddNode("Mini Train");
            graph.AddNode("Ice Cream");
            graph.AddNode("Roller Coaster");
            graph.AddNode("Haunted House");
            graph.AddNode("Water Ride");
            graph.AddNode("Pirate Ship");
            graph.AddNode("Climbing Tower");
            graph.AddNode("Volcano Ride");

            graph.AddEdges("Entrance", "Carousel");
            graph.AddEdges("Entrance", "Mini Train");
            graph.AddEdges("Entrance", "Ice Cream");
            graph.AddEdges("Entrance", "Ice Cream");
            graph.AddEdges("Entrance", "Ice Cream");
            graph.AddEdges("Entrance", "Ice Cream");
            graph.AddEdges("Entrance", "Ice Cream");
            graph.AddEdges("Entrance", "Ice Cream");
            graph.AddEdges("Entrance", "Ice Cream");
            graph.AddEdges("Entrance", "Ice Cream");
            graph.AddEdges("Entrance", "Ice Cream");
            graph.AddEdges("Entrance", "Ice Cream");
            graph.AddEdges("Entrance", "Ice Cream");

        }
    }
}
