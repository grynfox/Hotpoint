namespace TheServer.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model : DbContext
    {
        public Model()
            : base("name=ModelConfig")
        {
        }

        public virtual DbSet<categoria> categoria { get; set; }
        public virtual DbSet<grupopermicoes> grupopermicoes { get; set; }
        public virtual DbSet<itens> itens { get; set; }
        public virtual DbSet<itenspedido> itenspedido { get; set; }
        public virtual DbSet<mesa> mesa { get; set; }
        public virtual DbSet<pedidomesa> pedidomesa { get; set; }
        public virtual DbSet<pessoa> pessoa { get; set; }
        public virtual DbSet<mesatempedido> mesatempedido { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<categoria>()
                .Property(e => e.descricao)
                .IsUnicode(false);

            modelBuilder.Entity<categoria>();
                //.HasMany(e => e.itens)
                //.WithRequired(e => e.categoria)
                //.WillCascadeOnDelete(false);

            modelBuilder.Entity<grupopermicoes>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<grupopermicoes>()
                .HasMany(e => e.pessoa)
                .WithRequired(e => e.grupopermicoes)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<itens>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<itens>()
                .Property(e => e.informacao)
                .IsUnicode(false);

            modelBuilder.Entity<itens>()
                .HasMany(e => e.itenspedido)
                .WithRequired(e => e.itens)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<itenspedido>()
                .Property(e => e.observacao)
                .IsUnicode(false);

            modelBuilder.Entity<mesa>()
                .Property(e => e.nomeMesa)
                .IsUnicode(false);

            modelBuilder.Entity<mesa>()
                .HasMany(e => e.mesatempedido)
                .WithRequired(e => e.mesa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pedidomesa>()
                .HasMany(e => e.itenspedido)
                .WithRequired(e => e.pedidomesa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pedidomesa>()
                .HasMany(e => e.mesatempedido)
                .WithRequired(e => e.pedidomesa)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<pessoa>()
                .Property(e => e.login)
                .IsUnicode(false);

            modelBuilder.Entity<pessoa>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<pessoa>()
                .Property(e => e.nome)
                .IsUnicode(false);

            modelBuilder.Entity<mesatempedido>()
                .Property(e => e.senhaPedido)
                .IsUnicode(false);
        }
    }
}
