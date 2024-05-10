namespace ContainerTransport;

public class Ship
{
    public Ship(int height, int width)
    {
        Height = height;
        Width = width;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                _stacks.Add(new Stack(x, y));
            }
        }
    }

    public bool TryGetStackAt(int x, int y, out Stack? stack)
    {
        stack = _stacks.FirstOrDefault(s => s.X == x && s.Y == y);
        return stack is not null;
    }

    public readonly int Width;
    public readonly int Height;
    public IReadOnlyCollection<Stack> Stacks => _stacks;

    private readonly List<Stack> _stacks = [];
}