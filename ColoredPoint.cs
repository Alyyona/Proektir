using System;
namespace PrakticheskayaRabota{

    public class NamePoint : Point2D
    {
        public string Name { get; }

        public NamePoint (string name, double x, double y, string color, bool flag) : base(x, y, color, flag)
        {
            Name = name;
        }

        public override string ToString() => $"NamePoint '{Name}' ({X}; {Y}) [Color: {Color}, Flag: {Flag}]";
    }
}
