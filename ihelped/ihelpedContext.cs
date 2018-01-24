using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ihelped
{
    public partial class ihelpedContext : DbContext
    {
        public virtual DbSet<BuyIns> BuyIns { get; set; }
        public virtual DbSet<Causes> Causes { get; set; }
        public virtual DbSet<Disseminations> Disseminations { get; set; }
        public virtual DbSet<Edges> Edges { get; set; }
        public virtual DbSet<Nodes> Nodes { get; set; }
        public virtual DbSet<Pot> Pot { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasPostgresExtension("pgcrypto");

            modelBuilder.Entity<BuyIns>(entity =>
            {
                entity.HasKey(e => e.BuyInId);

                entity.ToTable("buy_ins");

                entity.Property(e => e.BuyInId).HasColumnName("buy_in_id");

                entity.Property(e => e.Amount).HasColumnName("amount");

                entity.Property(e => e.CauseId)
                    .HasColumnName("cause_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Cause)
                    .WithMany(p => p.BuyIns)
                    .HasForeignKey(d => d.CauseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("buy_ins_cause_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.BuyIns)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("buy_ins_user_id_fkey");
            });

            modelBuilder.Entity<Causes>(entity =>
            {
                entity.HasKey(e => e.CauseId);

                entity.ToTable("causes");

                entity.Property(e => e.CauseId).HasColumnName("cause_id");

                entity.Property(e => e.CauseText)
                    .IsRequired()
                    .HasColumnName("cause_text");

                entity.Property(e => e.Hashtag)
                    .IsRequired()
                    .HasColumnName("hashtag");
            });

            modelBuilder.Entity<Disseminations>(entity =>
            {
                entity.HasKey(e => e.DisseminationId);

                entity.ToTable("disseminations");

                entity.Property(e => e.DisseminationId).HasColumnName("dissemination_id");

                entity.Property(e => e.NodeId)
                    .HasColumnName("node_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Node)
                    .WithMany(p => p.Disseminations)
                    .HasForeignKey(d => d.NodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("disseminations_node_id_fkey");
            });

            modelBuilder.Entity<Edges>(entity =>
            {
                entity.HasKey(e => e.EdgeId);

                entity.ToTable("edges");

                entity.Property(e => e.EdgeId).HasColumnName("edge_id");

                entity.Property(e => e.NodeA)
                    .HasColumnName("node_a")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.NodeB)
                    .HasColumnName("node_b")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.NodeANavigation)
                    .WithMany(p => p.EdgesNodeANavigation)
                    .HasForeignKey(d => d.NodeA)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("edges_node_a_fkey");

                entity.HasOne(d => d.NodeBNavigation)
                    .WithMany(p => p.EdgesNodeBNavigation)
                    .HasForeignKey(d => d.NodeB)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("edges_node_b_fkey");
            });

            modelBuilder.Entity<Nodes>(entity =>
            {
                entity.HasKey(e => e.NodeId);

                entity.ToTable("nodes");

                entity.HasIndex(e => new { e.UserId, e.CauseId })
                    .HasName("nodes_user_id_cause_id_key")
                    .IsUnique();

                entity.Property(e => e.NodeId).HasColumnName("node_id");

                entity.Property(e => e.CauseId)
                    .HasColumnName("cause_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Plays).HasColumnName("plays");

                entity.Property(e => e.State).HasColumnName("state");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Cause)
                    .WithMany(p => p.Nodes)
                    .HasForeignKey(d => d.CauseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nodes_cause_id_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Nodes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("nodes_user_id_fkey");
            });

            modelBuilder.Entity<Pot>(entity =>
            {
                entity.ToTable("pot");

                entity.Property(e => e.PotId).HasColumnName("pot_id");

                entity.Property(e => e.CauseId)
                    .HasColumnName("cause_id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Collected)
                    .HasColumnName("collected")
                    .HasDefaultValueSql("false");

                entity.Property(e => e.NextPayout).HasColumnName("next_payout");

                entity.Property(e => e.PotTotal).HasColumnName("pot_total");

                entity.Property(e => e.WinnerId)
                    .HasColumnName("winner_id")
                    .ValueGeneratedOnAdd();

                entity.HasOne(d => d.Cause)
                    .WithMany(p => p.Pot)
                    .HasForeignKey(d => d.CauseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pot_cause_id_fkey");

                entity.HasOne(d => d.Winner)
                    .WithMany(p => p.Pot)
                    .HasForeignKey(d => d.WinnerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("pot_winner_id_fkey");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("users");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email");

                entity.Property(e => e.First)
                    .IsRequired()
                    .HasColumnName("first");

                entity.Property(e => e.Last)
                    .IsRequired()
                    .HasColumnName("last");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password");
            });
        }
    }
}
