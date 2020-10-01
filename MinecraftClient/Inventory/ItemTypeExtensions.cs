﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MinecraftClient.Inventory
{
    public static class ItemTypeExtensions
    {
        public static bool IsFood(this ItemType m)
        {
            ItemType[] t =
            {
                ItemType.Apple,
                ItemType.BakedPotato,
                ItemType.Beetroot,
                ItemType.Bread,
                ItemType.Carrot,
                ItemType.CookedChicken,
                ItemType.CookedCod,
                ItemType.CookedMutton,
                ItemType.CookedPorkchop,
                ItemType.CookedRabbit,
                ItemType.CookedSalmon,
                ItemType.Cookie,
                ItemType.DriedKelp,
                ItemType.EnchantedGoldenApple,
                ItemType.GoldenApple,
                ItemType.GoldenCarrot,
                ItemType.MelonSlice,
                ItemType.Potato,
                ItemType.PumpkinPie,
                ItemType.Beef,
                ItemType.Chicken,
                ItemType.Cod,
                ItemType.Mutton,
                ItemType.Porkchop,
                ItemType.Rabbit,
                ItemType.Salmon,
                ItemType.CookedBeef,
                ItemType.SweetBerries,
                ItemType.TropicalFish
            };
            return t.Contains(m);
        }

        public static bool IsStackable(this ItemType m)
        {
            // these are non-stackable
            ItemType[] t =
            {
                ItemType.AcaciaBoat,
                ItemType.BirchBoat,
                ItemType.BlackBed,
                ItemType.BlackShulkerBox,
                ItemType.BlueBed,
                ItemType.BlueShulkerBox,
                ItemType.Bow,
                ItemType.BrownBed,
                ItemType.BrownShulkerBox,
                ItemType.Cake,
                ItemType.ChainmailBoots,
                ItemType.ChainmailChestplate,
                ItemType.ChainmailHelmet,
                ItemType.ChainmailLeggings,
                ItemType.ChestMinecart,
                ItemType.CodBucket,
                ItemType.CommandBlockMinecart,
                ItemType.CreeperBannerPattern,
                ItemType.Crossbow,
                ItemType.CyanBed,
                ItemType.CyanShulkerBox,
                ItemType.DarkOakBoat,
                ItemType.DebugStick,
                ItemType.DiamondAxe,
                ItemType.DiamondBoots,
                ItemType.DiamondChestplate,
                ItemType.DiamondHelmet,
                ItemType.DiamondHoe,
                ItemType.DiamondHorseArmor,
                ItemType.DiamondLeggings,
                ItemType.DiamondPickaxe,
                ItemType.DiamondShovel,
                ItemType.DiamondSword,
                ItemType.Elytra,
                ItemType.EnchantedBook,
                ItemType.FilledMap,
                ItemType.FishingRod,
                ItemType.FlintAndSteel,
                ItemType.FurnaceMinecart,
                ItemType.GlobeBannerPattern,
                ItemType.GoldenAxe,
                ItemType.GoldenBoots,
                ItemType.GoldenChestplate,
                ItemType.GoldenHelmet,
                ItemType.GoldenHoe,
                ItemType.GoldenHorseArmor,
                ItemType.GoldenLeggings,
                ItemType.GoldenPickaxe,
                ItemType.GoldenShovel,
                ItemType.GoldenSword,
                ItemType.GrayBed,
                ItemType.GrayShulkerBox,
                ItemType.GreenBed,
                ItemType.GreenShulkerBox,
                ItemType.HopperMinecart,
                ItemType.IronAxe,
                ItemType.IronBoots,
                ItemType.IronChestplate,
                ItemType.IronHelmet,
                ItemType.IronHoe,
                ItemType.IronHorseArmor,
                ItemType.IronLeggings,
                ItemType.IronPickaxe,
                ItemType.IronShovel,
                ItemType.IronSword,
                ItemType.Jigsaw,
                ItemType.JungleBoat,
                ItemType.LavaBucket,
                ItemType.LeatherBoots,
                ItemType.LeatherChestplate,
                ItemType.LeatherHelmet,
                ItemType.LeatherHorseArmor,
                ItemType.LeatherLeggings,
                ItemType.LightBlueBed,
                ItemType.LightBlueShulkerBox,
                ItemType.LightGrayBed,
                ItemType.LightGrayShulkerBox,
                ItemType.LimeBed,
                ItemType.LimeShulkerBox,
                ItemType.LingeringPotion,
                ItemType.MagentaBed,
                ItemType.MagentaShulkerBox,
                ItemType.MilkBucket,
                ItemType.Minecart,
                ItemType.MojangBannerPattern,
                ItemType.MushroomStew,
                ItemType.MusicDisc11,
                ItemType.MusicDisc13,
                ItemType.MusicDiscCat,
                ItemType.MusicDiscChirp,
                ItemType.MusicDiscFar,
                ItemType.MusicDiscMall,
                ItemType.MusicDiscMellohi,
                ItemType.MusicDiscStal,
                ItemType.MusicDiscStrad,
                ItemType.MusicDiscWait,
                ItemType.MusicDiscWard,
                ItemType.OakBoat,
                ItemType.OrangeBed,
                ItemType.OrangeShulkerBox,
                ItemType.PinkBed,
                ItemType.PinkShulkerBox,
                ItemType.Potion,
                ItemType.PufferfishBucket,
                ItemType.PurpleBed,
                ItemType.PurpleShulkerBox,
                ItemType.RabbitStew,
                ItemType.RedBed,
                ItemType.RedShulkerBox,
                ItemType.Saddle,
                ItemType.SalmonBucket,
                ItemType.Shears,
                ItemType.Shield,
                ItemType.ShulkerBox,
                ItemType.SkullBannerPattern,
                ItemType.SplashPotion,
                ItemType.SpruceBoat,
                ItemType.StoneAxe,
                ItemType.StoneHoe,
                ItemType.StonePickaxe,
                ItemType.StoneShovel,
                ItemType.StoneSword,
                ItemType.StructureBlock,
                ItemType.SuspiciousStew,
                ItemType.TntMinecart,
                ItemType.TotemOfUndying,
                ItemType.Trident,
                ItemType.TropicalFishBucket,
                ItemType.TurtleHelmet,
                ItemType.WaterBucket,
                ItemType.WhiteBed,
                ItemType.WhiteShulkerBox,
                ItemType.WoodenAxe,
                ItemType.WoodenHoe,
                ItemType.WoodenPickaxe,
                ItemType.WoodenShovel,
                ItemType.WoodenSword,
                ItemType.WritableBook,
                ItemType.WrittenBook,
                ItemType.YellowBed,
                ItemType.YellowShulkerBox
            };
            return !t.Contains(m);
        }

        public static int StackCount(this ItemType m)
        {
            // These are stack to 16 only
            ItemType[] t =
            {
                ItemType.BlackBanner,
                ItemType.BlueBanner,
                ItemType.BrownBanner,
                ItemType.CyanBanner,
                ItemType.GrayBanner,
                ItemType.GreenBanner,
                ItemType.LightBlueBanner,
                ItemType.LightGrayBanner,
                ItemType.LimeBanner,
                ItemType.MagentaBanner,
                ItemType.OrangeBanner,
                ItemType.PinkBanner,
                ItemType.PurpleBanner,
                ItemType.RedBanner,
                ItemType.WhiteBanner,
                ItemType.YellowBanner,
                ItemType.ArmorStand,
                ItemType.Bucket,
                ItemType.Egg,
                ItemType.EnderEye,
                ItemType.HoneyBottle,
                ItemType.Snowball
            };
            if (m.IsStackable())
                return 64;
            else if (t.Contains(m))
                return 16;
            else
                return 1;
        }
    }
}
