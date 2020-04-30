﻿namespace AbyssRunSite.DataContextMigrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using AbyssRunSite.Models;
    using AbyssRunSite.DataAccessLayer;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AbyssRunSite.DataAccessLayer.AbyssContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"DataContextMigrations";
        }

        protected override void Seed(AbyssRunSite.DataAccessLayer.AbyssContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var levels = new List<LevelModel>
            {
                new LevelModel {Id = 0, LevelName = "Outskirts", LevelEnemies = new List<EnemyModel>(), LevelItems = new List<ItemModel>(), LevelDescription="A small cavern on the outskirts of the Abyss facility. The ascent begins here."},
                new LevelModel {Id = 1, LevelName = "Obsidian Mines", LevelEnemies = new List<EnemyModel>(), LevelItems = new List<ItemModel>(), LevelDescription="A series of platforms within a newly excavated cavern."},
                new LevelModel {Id = 2, LevelName = "Wormwood Falls", LevelEnemies = new List<EnemyModel>(), LevelItems = new List<ItemModel>(), LevelDescription="A former mining chamber converted into a hazard storage center."},
                new LevelModel {Id = 3, LevelName = "Citadel Shaft", LevelEnemies = new List<EnemyModel>(), LevelItems = new List<ItemModel>(), LevelDescription="A major transfer station leading to the upper levels of the facility."}
            };

            levels.ForEach(lvl => context.Levels.AddOrUpdate(lvl));
            context.SaveChanges();

            var enemies = new List<EnemyModel>
            {
                new EnemyModel {Id = 0, EnemyName = "Peltast", LevelModelId = levels.Single(i => i.LevelName == "Obsidian Mines").Id, EnemyHP=1, EnemyAttack= "Plasma Rifle", EnemyDescription= "Small Scorpuron gifted with insect-like wings for flight. Peltasts are among the most numerous of the subspecies, being created to fly ahead of the main legions and incapacitate enemy soldiers with an agonizing sting.", EnemyImageSrc="~/Content/Images/Peltast.png"},
                new EnemyModel {Id = 1, EnemyName = "Legionary", LevelModelId = levels.Single(i => i.LevelName == "Obsidian Mines").Id, EnemyHP=3, EnemyAttack= "Molten Munition Cannon", EnemyDescription = "Legionaries are the most common of the solider Scorpuron. Each is a tough combatant clad in ablative layers of chitin and armor that protects it well from most attacks.", EnemyImageSrc="~/Content/Images/Legionary.png" },
                new EnemyModel {Id = 2, EnemyName = "Praetorian", LevelModelId = levels.Single(i => i.LevelName == "Wormwood Falls").Id, EnemyHP=2, EnemyAttack= "Stun Pistol and Thermal Blade", EnemyDescription = "Elite troops created to serve as both guards and assassins, Praetorian are both fast and aggressive. The modern incarnation of these elites has a small booster incorporated into their armor to further increase their speed on the charge.", EnemyImageSrc="~/Content/Images/Praetorian.png" },
                new EnemyModel {Id = 3, EnemyName = "Hoplite", LevelModelId = levels.Single(i => i.LevelName == "Wormwood Falls").Id, EnemyHP=3, EnemyAttack= "Venom", EnemyDescription = "Hoplites are defensive fighters trained to shield friendlies behind their shields. They appear to be descended from some of the more venomous scorpion species, complete with the ability to spray globs of venom from their tails.", EnemyImageSrc="~/Content/Images/Hoplite.png" },
                new EnemyModel {Id = 4, EnemyName = "Venator", LevelModelId = levels.Single(i => i.LevelName == "Citadel Shaft").Id, EnemyHP=10, EnemyAttack= "Massive Claws", EnemyDescription = "Venators live to hunt and feed, having the most animalistic minds of all Scorpuron subspecies. Their size and strength make them a daunting opponent that is best left alone when possible.", EnemyImageSrc="~/Content/Images/Venator.png" },
                new EnemyModel {Id = 5, EnemyName = "Pandinus", LevelModelId = levels.Single(i => i.LevelName == "Citadel Shaft").Id, EnemyHP=5, EnemyAttack= "Fireball, Teleportation", EnemyDescription = "One of the last of the regent line, Pandinus rules over the Scorpuron species and by extention the Abyss itself. He must be confronted in order to escape the facility. Battle with Pandinus is a daunting prospect, as the regent wields otherwordly powers.", EnemyImageSrc="~/Content/Images/Pandinus.png" },
                //new EnemyModel {EnemyName = "Genetrix", EnemyHP = 10, EnemyAttack = "Scorplings, Massive Claws, Venom", EnemyDescription = "Genetrix are Scorpuron females with offspring. They carry broods of Scorplings upon their backs until they are grown enough to be self-sufficent. They are generally found in the safety of brood chambers and will fight fiercely to protect their young.", EnemyImageSrc = "" }
            };

            enemies.ForEach(foe => context.Enemies.AddOrUpdate(foe));
            context.SaveChanges();

            AddOrUpdateLevelEnemy(context, "Peltast", "Obsidian Mines");
            AddOrUpdateLevelEnemy(context, "Legionary", "Obsidian Mines");
            AddOrUpdateLevelEnemy(context, "Praetorian", "Wormwood Falls");
            AddOrUpdateLevelEnemy(context, "Hoplite", "Wormwood Falls");
            AddOrUpdateLevelEnemy(context, "Venator", "Citadel Shaft");
            AddOrUpdateLevelEnemy(context, "Pandinus", "Citadel Shaft");
            context.SaveChanges();

            var items = new List<ItemModel>
            {
                new ItemModel {Id = 0, ItemName = "Samples", LevelModelId = levels.Single(i => i.LevelName == "Outskirts").Id, ItemDescription = "Chemical samples that Dr. Addison would find facinating. Samples increase score when collected.", ItemImageSrc= "" },
                new ItemModel {Id = 1, ItemName = "Armor", LevelModelId = levels.Single(i => i.LevelName == "Outskirts").Id, ItemDescription = "A combat armor vest that is good for one solid hit from an enemy. No defense from other hazards such as lava or chemicals.", ItemImageSrc= "" },
                new ItemModel {Id = 2, ItemName = "Plasma Cannon", LevelModelId = levels.Single(i => i.LevelName == "Obsidian Mines").Id, ItemDescription = "A military prototype created from salvaged technology. Effective against most Scorpuron.", ItemImageSrc= "" },
                new ItemModel {Id = 3, ItemName = "Rift Generator", LevelModelId = levels.Single(i => i.LevelName == "Wormwood Falls").Id, ItemDescription = "This otherwordly device launches a stream of particles that can translocate the weapon (and anyone holding it) to their location on termination. Has strange interactions upon impact with other beings...", ItemImageSrc= ""},
                new ItemModel {Id = 4, ItemName = "MMC", LevelModelId = levels.Single(i => i.LevelName == "Citidel Shaft").Id, ItemDescription = "This weapon fires shells containing a soft metal core and explosive gel. Upon firing the core is liquified, causing a shower of molten material on impact. ", ItemImageSrc= "" },
                new ItemModel {Id = 5, ItemName = "MMC Ammo", LevelModelId = levels.Single(i => i.LevelName == "Citidel Shaft").Id, ItemDescription = "Additional shells for the MMC weapon. Each pack contains 3 shells.", ItemImageSrc= "" },
            };

            items.ForEach(itm => context.Items.AddOrUpdate(itm));
            context.SaveChanges();

            AddOrUpdateLevelItem(context, "Samples", "Outskirts");
            AddOrUpdateLevelItem(context, "Armor", "Outskirts");
            AddOrUpdateLevelItem(context, "Plasma Cannon", "Obsidian Mines");
            AddOrUpdateLevelItem(context, "Rift Generator", "Wormwood Falls");
            AddOrUpdateLevelItem(context, "MMC", "Citadel Shaft");
            AddOrUpdateLevelItem(context, "MMC Ammo", "Citadel Shaft");
            context.SaveChanges();

        }

        /// <summary>
        /// Helper method that loads enemies into the level's enemy list.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="enemyName"></param>
        /// <param name="levelName"></param>
        void AddOrUpdateLevelEnemy(AbyssContext context, string enemyName, string levelName)
        {
            var crs = context.Levels.SingleOrDefault(c => c.LevelName == levelName);
            var inst = crs.LevelEnemies.SingleOrDefault(i => i.EnemyName == enemyName);
            if (inst == null)
                crs.LevelEnemies.Add(context.Enemies.Single(i => i.EnemyName == enemyName));
        }

        /// <summary>
        /// Helper method that loads items into the level's enemy list.
        /// </summary>
        /// <param name="context"></param>
        /// <param name="itemName"></param>
        /// <param name="levelName"></param>
        void AddOrUpdateLevelItem(AbyssContext context, string itemName, string levelName)
        {
            var crs = context.Levels.SingleOrDefault(c => c.LevelName == levelName);
            var inst = crs.LevelItems.SingleOrDefault(i => i.ItemName == itemName);
            if (inst == null)
                crs.LevelItems.Add(context.Items.Single(i => i.ItemName == itemName));
        }
    }
}
