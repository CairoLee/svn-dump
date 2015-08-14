using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TowerInterface
{
    public interface IShowableProperty
    {
        string Name { get; }
        string PropertyName { get; }
        string Hint { get; }
    }
}
