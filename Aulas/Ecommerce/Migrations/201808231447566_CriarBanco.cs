namespace Ecommerce.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriarBanco : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categorias",
                c => new
                    {
                        CategoriaId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false),
                        Descricao = c.String(),
                    })
                .PrimaryKey(t => t.CategoriaId);
            
            CreateTable(
                "dbo.ItensVenda",
                c => new
                    {
                        ItemVendaId = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        Preco = c.Double(nullable: false),
                        Data = c.DateTime(nullable: false),
                        CarrinhoId = c.String(),
                        Produto_ProdutoId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemVendaId)
                .ForeignKey("dbo.Produtos", t => t.Produto_ProdutoId)
                .Index(t => t.Produto_ProdutoId);
            
            CreateTable(
                "dbo.Produtos",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 50),
                        Descricao = c.String(),
                        Preco = c.Double(nullable: false),
                        Imagem = c.String(),
                        Categoria_CategoriaId = c.Int(),
                    })
                .PrimaryKey(t => t.ProdutoId)
                .ForeignKey("dbo.Categorias", t => t.Categoria_CategoriaId)
                .Index(t => t.Categoria_CategoriaId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItensVenda", "Produto_ProdutoId", "dbo.Produtos");
            DropForeignKey("dbo.Produtos", "Categoria_CategoriaId", "dbo.Categorias");
            DropIndex("dbo.Produtos", new[] { "Categoria_CategoriaId" });
            DropIndex("dbo.ItensVenda", new[] { "Produto_ProdutoId" });
            DropTable("dbo.Produtos");
            DropTable("dbo.ItensVenda");
            DropTable("dbo.Categorias");
        }
    }
}
