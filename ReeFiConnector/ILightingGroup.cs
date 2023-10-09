using System.Collections.Generic;

namespace ReefCode.Reefi
{
    public interface ILightingGroup : IReadOnlyList<ILight>, ILightCommand, IDisplayCommand
    {
        int GroupId { get; }
    }
}
