namespace WpfGrid
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity;

    [Table("City")]
    public partial class City
    {
        public int cityID { get; set; }

        [Key]
        [StringLength(50)]
        public string cityName { get; set; }

        public int? proID { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? UpdateDate { get; set; }

        public virtual Province Province { get; set; }
    }
   
    public class TestDBContext : DbContext
    {
        public TestDBContext() : base("name=City") { }
        public DbSet<City> City { get; set; }
        public DbSet<Province> Province { get; set; }
    }
}
