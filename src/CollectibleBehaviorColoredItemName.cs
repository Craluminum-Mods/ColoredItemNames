using System.Collections.Generic;
using System.Text;
using Vintagestory.API.Common;

namespace ColoredItemNames
{
    public class CollectibleBehaviorColoredItemName : CollectibleBehavior
    {
        private readonly List<string> colors = new List<string>
        {
            "#FFD65F",
            "#FFEE70",
            "#FFFA81",
            "#FEF8F4",
            "#C2F3E8",
            "#9AEFD6",
            "#B8F2F4",
            "#FFD2E0",
            "#FFE4F1",
            "#FFAC90",
            "#FF816D"
        };

        private int colorIndex = 0;

        public CollectibleBehaviorColoredItemName(CollectibleObject collObj) : base(collObj)
        {
        }

        public override void GetHeldItemName(StringBuilder sb, ItemStack itemStack)
        {
            for (int i = sb.Length - 1; i >= 0; i--)
            {
                ColorText(i, sb);
            }
        }

        private void ColorText(int index, StringBuilder sb)
        {
            var was = sb[index];
            if (was != ' ')
            {
                sb.Remove(index, 1);
                sb.Insert(index, Wrap(was, GetNextColor()));
            }
        }

        private string Wrap(char a, string hex)
        {
            return $"<font color=\"{hex}\">{a}</font>";
        }

        private string GetNextColor()
        {
            colorIndex++;
            if (colorIndex >= colors.Count)
            {
                colorIndex = 0;
            }

            return colors[colorIndex];
        }
    }
}
