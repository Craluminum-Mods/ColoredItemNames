using Vintagestory.API.Common;
using Vintagestory.API.Util;

[assembly: ModInfo("Colored Item Names")]

namespace ColoredItemNames
{
    class Core : ModSystem
    {
        public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Client;

        public override void Start(ICoreAPI api)
        {
            base.Start(api);

            api.RegisterCollectibleBehaviorClass("ColoredItemName", typeof(CollectibleBehaviorColoredItemName));
            api.World.Logger.Event("started 'Colored Item Names' mod");
        }

        public override void AssetsFinalize(ICoreAPI api)
        {
            foreach (var obj in api.World.Collectibles)
            {
                if (api.Side == EnumAppSide.Client)
                {
                    obj.CollectibleBehaviors = obj.CollectibleBehaviors.Append(new CollectibleBehaviorColoredItemName(obj));
                }
            }
        }
    }
}