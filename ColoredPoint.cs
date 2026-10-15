using System;
namespace PrakticheskayaRabota{

    public class NamePoint : Point2D
    {
        public string Name { get; set; }

        public NamePoint (string name, double x, double y, string color, bool flag) 
        : base(x, y, color, flag)
        {
            Name = name;
        }

        public new string GetDescription()
        {
            return ToString();
        }

        public override string ToString()
        {
            return $"NamePoint '{Name}' ({X}; {Y}) [Color: {Color}, Flag: {Flag}]";
        } 
    }
}
