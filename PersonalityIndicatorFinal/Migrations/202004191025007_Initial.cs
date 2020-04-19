namespace PersonalityIndicatorFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAnswers",
                c => new
                    {
                        AnswerKey = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        AnswerList = c.String(),
                    })
                .PrimaryKey(t => t.AnswerKey);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserAnswers");
        }
    }
}
