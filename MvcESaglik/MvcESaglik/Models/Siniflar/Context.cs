using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MvcESaglik.Models.Siniflar
{
    public class Context:DbContext
    {
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Alerji> Alerjis { get; set; }
        public DbSet<Asi> Asis { get; set; }
        public DbSet<Brans> Brans { get; set; }
        public DbSet<DoktorProfil> DoktorProfils { get; set; }
        public DbSet<Hastalik> Hastaliks { get; set; }
        public DbSet<İl> İls { get; set; }
        public DbSet<İlce> İlces { get; set; }
        public DbSet<Klinik> Kliniks { get; set; }
        public DbSet<KullaniciProfil> KullaniciProfils { get; set; }
        public DbSet<Kurum> Kurums { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public DbSet<Mesajlar> Mesajlars { get; set; }
        public DbSet<Randevu> Randevus { get; set; }
        public DbSet<Rapor> Rapors { get; set; }
        public DbSet<Recete> Recetes { get; set; }
        public DbSet<ReceteIlac> ReceteIlacs { get; set; }
        public DbSet<Tahlil> Tahlils { get; set; }
        public DbSet<Yapilacak> Yapilacaks { get; set; }
        public DbSet<Yorum> Yorums { get; set; }
    }
}