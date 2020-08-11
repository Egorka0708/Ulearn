using System.Drawing;
using System.Collections.Generic;
using GeometryTasks;

namespace GeometryPainting
{
    public static class SegmentExtensions
    {
        public static Dictionary<Segment, Color> Colors = new Dictionary<Segment, Color>();

        public static void SetColor(this Segment segment, Color color)
        {
            if (color != null)
            {
                if (Colors.Count > 0 && Colors.ContainsKey(segment))
                    Colors.Remove(segment);
                Colors.Add(segment, color);
            }
        }

        public static Color GetColor(this Segment segment)
        {
            Color color;
            if (segment != null)
            {
                if (Colors.TryGetValue(segment, out color))
                    color = Colors[segment];
            }
            else color = Color.Black;
            return color;
        }
    }
}
