using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Context
{
    public class CarBookContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-EAQ14N5;initial Catalog=CarBookDb;integrated Security=true;TrustServerCertificate=true;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<About>().HasKey(about => about.AboutId);
            modelBuilder.Entity<Banner>().HasKey(banner => banner.BannerId);
            modelBuilder.Entity<Brand>().HasKey(brand => brand.BrandId);
            modelBuilder.Entity<Car>().HasKey(car => car.CarId);
            modelBuilder.Entity<CarDescription>().HasKey(carDescription => carDescription.CarDescriptionId);
            modelBuilder.Entity<CarFeature>().HasKey(carFeature => carFeature.CarFeatureId);
            modelBuilder.Entity<CarPricing>().HasKey(carPricing  => carPricing.CarPricingId);
            modelBuilder.Entity<Category>().HasKey(category => category.CategoryId);
            modelBuilder.Entity<Contact>().HasKey(contact => contact.ContactId);
            modelBuilder.Entity<Feature>().HasKey(feature => feature.FeatureId);
            modelBuilder.Entity<FooterAddress>().HasKey(footerAddress => footerAddress.FooterAddressId);
            modelBuilder.Entity<Location>().HasKey(location => location.LocationId);
            modelBuilder.Entity<Pricing>().HasKey(pricing => pricing.PricingId);
            modelBuilder.Entity<Service>().HasKey(service => service.ServiceId);
            modelBuilder.Entity<SocialMedia>().HasKey(socialMedia  => socialMedia.SocialMediaId);
            modelBuilder.Entity<Testimonial>().HasKey(testimonial => testimonial.TestimonialId);

        }

        public DbSet<About> Abouts { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarDescription> CarDescriptions { get; set; }
        public DbSet<CarFeature> CarFeatures { get; set; }
        public DbSet<CarPricing> CarPricings { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<FooterAddress> FooterAddresses { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
    }
}
