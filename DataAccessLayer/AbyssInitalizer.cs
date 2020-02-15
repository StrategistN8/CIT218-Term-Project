using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AbyssRunSite.Models;

namespace AbyssRunSite.DataAccessLayer
{
    public class AbyssInitalizer : System.Data.Entity.DropCreateDatabaseIfModelChanges<AbyssContext>
    {

        protected override void Seed(AbyssContext context)
        {
            var enemies = new List<EnemyModel>
            {
                new EnemyModel {EnemyName ="Peltast", EnemyHP=1, EnemyAttack="Plasma Rifle", EnemyDescription="Small Scorpuron gifted with insect-like wings for flight. Peltasts are among the most numerous of the Scorpuron Legions, being created as scouts and saboteurs to fly ahead of the main legions and incapacitate enemy soldiers with an agonizing venom.", EnemyImageSrc="~/Content/Images/Peltast.png"},
                new EnemyModel {EnemyName ="Legionary", EnemyHP=3, EnemyAttack="Molten Munition Cannon", EnemyDescription="Legionaries are the most common of the solider Scorpuron. Each Legionary is a tough combatant clad in ablative layers of chitin and armor that protects it well from most attacks.", EnemyImageSrc="~/Content/Images/Legionary.png" },
                new EnemyModel {EnemyName ="Praetorian", EnemyHP=2, EnemyAttack="Stun Pistol and Thermal Blade", EnemyDescription="Elite troops created to serve as both guards and assassins, Praetorian are both fast and aggressive. The modern incarnation of these elites have a small booster incorperated into their armor to further increase their speed on the charge.", EnemyImageSrc="~/Content/Images/Praetorian.png" },
                new EnemyModel {EnemyName ="Venator", EnemyHP=10, EnemyAttack="Claws", EnemyDescription="Venators live to hunt and feed, having the most animalistic minds of all Scorpuron subspecies. Their size and strength make them a daunting opponent that is best left alone when possible.", EnemyImageSrc="~/Content/Images/Venator.png" },
            };

            enemies.ForEach(foe => context.Enemies.Add(foe));
            context.SaveChanges();

            var levels = new List<LevelModel>
            {
                new LevelModel {LevelName = "Outskirts", LevelDescription="A small cavern on the outskirts of the Abyss facility. The ascent begins here."},
                new LevelModel {LevelName = "Obsidian Mines", LevelDescription="A series of platforms within a newly excavated cavern."},
                new LevelModel {LevelName = "Wormwood Falls", LevelDescription="A former mining chamber converted into a hazard storage center."},
                new LevelModel {LevelName = "Citadel Shaft", LevelDescription="A major transfer station leading to the upper levels of the facility."}

            };

            levels.ForEach(lvl => context.Levels.Add(lvl));
            context.SaveChanges();

            var items = new List<ItemModel>
            {
                new ItemModel { ItemName = "Samples" },
                new ItemModel { ItemName = "Armor" },
                new ItemModel { ItemName = "Plasma Cannon" },
                new ItemModel { ItemName = "Rift Generator" },
                new ItemModel { ItemName = "MMC" },
                new ItemModel { ItemName = "MMC Ammo" },
                new ItemModel { ItemName = "Reflex Shield" },
                new ItemModel { ItemName = "Shroud Serum" },
                new ItemModel { ItemName = "Nephilim Suit" },
            };

            items.ForEach(itm => context.Items.Add(itm));
            context.SaveChanges();
        }

    }
}