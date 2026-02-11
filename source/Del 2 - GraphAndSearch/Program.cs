namespace GraphAndSearch
{
    public class Program
    {
        static void Main(string[] args)
        {
            Graph<string> themePark = new("Entrance");

            themePark.AddNode("Carousel", themePark._nodes["Entrance"]);
            themePark.AddNode("Mini Train", themePark._nodes["Entrance"]);
            themePark.AddNode("Ice Cream", themePark._nodes["Entrance"]);
            themePark.AddNode("Roller Coaster", themePark._nodes["Carousel"]);
            themePark.AddNode("Haunted House", themePark._nodes["Carousel"]);
            themePark.AddNode("Water Ride", themePark._nodes["Mini Train"]);
            themePark.AddNode("Pirate Ship", themePark._nodes["Ice Cream"]);
            themePark.AddNode("Climbing Tower", themePark._nodes["Roller Coaster"]);
            themePark.AddNode("Volcano Ride", themePark._nodes["Climbing Tower"]);

            themePark.BFS(themePark._nodes["Water Ride"]);
        }
    }
}
