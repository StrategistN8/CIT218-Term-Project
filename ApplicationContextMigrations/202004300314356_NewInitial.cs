namespace AbyssRunSite.ApplicationContextMigrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewInitial : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.EnemyModels", "LevelModelsId", "dbo.LevelModels");
            DropForeignKey("dbo.ItemModels", "LevelModelId", "dbo.LevelModels");
            DropIndex("dbo.EnemyModels", new[] { "LevelModelId" });
            DropIndex("dbo.ItemModels", new[] { "LevelModelId" });
            AlterColumn("dbo.EnemyModels", "LevelModelId", c => c.Int());
            AlterColumn("dbo.ItemModels", "LevelModelId", c => c.Int());
            CreateIndex("dbo.EnemyModels", "LevelModelId");
            CreateIndex("dbo.ItemModels", "LevelModelId");
            AddForeignKey("dbo.EnemyModels", "LevelModelId", "dbo.LevelModels", "Id");
            AddForeignKey("dbo.ItemModels", "LevelModelId", "dbo.LevelModels", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemModels", "LevelModelId", "dbo.LevelModels");
            DropForeignKey("dbo.EnemyModels", "LevelModelId", "dbo.LevelModels");
            DropIndex("dbo.ItemModels", new[] { "LevelModelId" });
            DropIndex("dbo.EnemyModels", new[] { "LevelModelId" });
            AlterColumn("dbo.ItemModels", "LevelModelId", c => c.Int(nullable: false));
            AlterColumn("dbo.EnemyModels", "LevelModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.ItemModels", "LevelModelId");
            CreateIndex("dbo.EnemyModels", "LevelModelId");
            AddForeignKey("dbo.ItemModels", "LevelModelId", "dbo.LevelModels", "Id", cascadeDelete: true);
            AddForeignKey("dbo.EnemyModels", "LevelModelId", "dbo.LevelModels", "Id", cascadeDelete: true);
        }
    }
}
