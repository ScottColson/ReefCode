using System.Collections.Generic;

namespace ReefCode.Reefi
{    public interface ILightingGroupList : IReadOnlyList<ILightingGroup>, ILightCommand, IDisplayCommand
    {
    }
}
