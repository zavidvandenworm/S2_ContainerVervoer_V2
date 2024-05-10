namespace ContainerTransport;

public static class ShipToUrl
{
    private static string StackToString(Stack stack, bool weights = false)
    {
        var output = "";

        for (int i = 0; i < stack.Containers.Count; i++)
        {
            if (weights)
            {
                output += (int)stack.Containers.ElementAt(i).Weight;
            }
            else
            {
                output += (int)stack.Containers.ElementAt(i).ContainerType;
            }
            if (i < stack.Containers.Count - 1)
            {
                output += "-";
            }
        }

        return output;
    }

    private static string RowToString(Ship ship, int rowAt, bool weights = false)
    {
        var output = "";

        for (int y = 0; y < ship.Height; y++)
        {
            var here = string.Empty;
            ship.TryGetStackAt(rowAt, y, out var stack);
            here += StackToString(stack!, weights);

            if (y < ship.Height - 1)
            {
                here += ",";
            }

            output += here;
        }

        return output;
    }

    private static string ShipToString(Ship ship, bool weights = false)
    {
        var output = "";

        for (int x = 0; x < ship.Width; x++)
        {
            var here = string.Empty;
            here += RowToString(ship, x, weights);
            
            if (x != 0)
            {
                output += "/";
            }

            output += here;
        }

        return output;
    }

    public static string ToUrl(this Ship ship)
    {
        var url = $"?length={ship.Height}&width={ship.Width}&stacks=";
        url += ShipToString(ship);
        url += "&weights=";
        url += ShipToString(ship, true);
        
        return url;
    }
}