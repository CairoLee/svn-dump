using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerInterface
{
    public interface IUpgrade
    {
        string Name { get; }
        string Key { get; }
        string Type { get; }
        int Price { get; }
        string Description { get; }
        float Value { get; }
        List<string> Requirements { get; }
    }
}
