using System.ComponentModel.DataAnnotations;

namespace ContainerTransport;

public class Container
{
    public ContainerType ContainerType
    {
        get
        {
            return (Cooled, Valuable) switch
            {
                (false, false) => ContainerType.Standard,
                (true, false) => ContainerType.Cooled,
                (false, true) => ContainerType.Valuable,
                (true, true) => ContainerType.CooledValuable
            };
        }
    }
    
    public bool Cooled { get; set; }
    public bool Valuable { get; set; }

    public int Weight => ContentWeight + 4000;
    
    [Range(0, 30000)]
    public int ContentWeight { get; set; }
    
    public const int MaxWeightOnTop = 120000;
}