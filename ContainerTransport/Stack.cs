namespace ContainerTransport;

public class Stack
{
    public Stack(int x, int y)
    {
        X = x;
        Y = y;
    }

    public Container? TopContainer => Containers.LastOrDefault();
    
    public int X { get; init; }
    public int Y { get; init; }

    public List<Container> Containers = [];
}