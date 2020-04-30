namespace AbyssRunSite.DataContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnemyModel", "LevelModelId", "dbo.LevelModel");
            DropForeignKey("dbo.ItemModel", "LevelModelId", "dbo.LevelModel");
            DropIndex("dbo.EnemyModel", new[] { "LevelModelId" });
            DropIndex("dbo.ItemModel", new[] { "LevelModelId" });
            AlterColumn("dbo.EnemyModel", "LevelModelId", c => c.Int());
            AlterColumn("dbo.ItemModel", "LevelModelId", c => c.Int());
            CreateIndex("dbo.EnemyModel", "LevelModelId");
            CreateIndex("dbo.ItemModel", "LevelModelId");
            AddForeignKey("dbo.EnemyModel", "LevelModelId", "dbo.LevelModel", "Id");
            AddForeignKey("dbo.ItemModel", "LevelModelId", "dbo.LevelModel", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemModel", "LevelModelId", "dbo.LevelModel");
            DropForeignKey("dbo.EnemyModel", "LevelModelId", "dbo.LevelModel");
            DropIndex("dbo.ItemModel", new[] { "LevelModelId" });
            DropIndex("dbo.EnemyModel", new[] { "LevelModelId" });
            AlterColumn("dbo.ItemModel", "LevelModelId", c => c.Int(nullable: false));
            AlterColumn("dbo.EnemyModel", "LevelModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemModel", "LevelModelId");
            CreateIndex("dbo.EnemyModel", "LevelModelId");
            AddForeignKey("dbo.ItemModel", "LevelModelId", "dbo.LevelModel", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EnemyModel", "LevelModelId", "dbo.LevelModel", "Id", cascadeDelete: true);
        }
    }
}
