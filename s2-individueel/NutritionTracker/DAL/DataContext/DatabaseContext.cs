using Microsoft.EntityFrameworkCore;
using AModelLayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace DAL.DataContext
{
    public class DatabaseContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        //Initialize instace of DbContext with specific options
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        //For nutrition of the day
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<NutritionModel> Nutritions { get; set; }

        //For training scheme
        public DbSet<SchemeModel> Schemes { get; set; }
        public DbSet<ExcersiseModel> Excersises { get; set; }
        public DbSet<SetModel> Sets { get; set; }

        //For saving user info and calculating recommended kcal etc
        public DbSet<UserInfoModel> UserInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Training scheme tables

            #region Scheme

            modelBuilder.Entity<SchemeModel>().ToTable("scheme");
            //Primary key and identity column
            modelBuilder.Entity<SchemeModel>().HasKey(s => s.Id);
            modelBuilder.Entity<SchemeModel>().Property(s => s.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("scheme_id");
            //Column settings
            modelBuilder.Entity<SchemeModel>().Property(s => s.Name).IsRequired().HasMaxLength(100).HasColumnName("scheme_name");
            modelBuilder.Entity<SchemeModel>().Property(s => s.UserId).IsRequired().HasColumnName("scheme_user_id");
            modelBuilder.Entity<SchemeModel>().Property(s => s.DayOne).IsRequired().HasMaxLength(15).HasColumnName("scheme_day_one");
            modelBuilder.Entity<SchemeModel>().Property(s => s.DayTwo).IsRequired(false).HasMaxLength(15).HasColumnName("scheme_day_two");
            //RELATIONS
            //Many excersises
            modelBuilder.Entity<SchemeModel>().HasMany<ExcersiseModel>(s => s.Excersises).WithOne(s => s.Scheme).HasForeignKey(s => s.SchemeId);
            //One user
            modelBuilder.Entity<SchemeModel>().HasOne<AppUserModel>(s => s.User).WithMany(s => s.Schemes).HasForeignKey(s => s.UserId);

            #endregion

            #region Excersise

            modelBuilder.Entity<ExcersiseModel>().ToTable("excersise");
            //Primary key and identity column
            modelBuilder.Entity<ExcersiseModel>().HasKey(s => s.Id);
            modelBuilder.Entity<ExcersiseModel>().Property(s => s.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("excersise_id");
            //Column settings
            modelBuilder.Entity<ExcersiseModel>().Property(s => s.SchemeId).IsRequired().HasColumnName("excersise_scheme_id");
            modelBuilder.Entity<ExcersiseModel>().Property(s => s.Name).IsRequired().HasMaxLength(100).HasColumnName("excersise_name");
            modelBuilder.Entity<ExcersiseModel>().Property(s => s.DisplayOrder).IsRequired().HasMaxLength(100).HasColumnName("excersise_order");
            //RELATIONS
            //Many sets
            modelBuilder.Entity<ExcersiseModel>().HasMany<SetModel>(s => s.Sets).WithOne(s => s.Excersise).HasForeignKey(s => s.ExceriseId);
            //One scheme
            modelBuilder.Entity<ExcersiseModel>().HasOne<SchemeModel>(s => s.Scheme).WithMany(s => s.Excersises).HasForeignKey(s => s.SchemeId);

            #endregion

            #region Set

            modelBuilder.Entity<SetModel>().ToTable("set");
            //Primary key and identity column
            modelBuilder.Entity<SetModel>().HasKey(s => s.Id);
            modelBuilder.Entity<SetModel>().Property(s => s.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("set_id");
            //Column settings
            modelBuilder.Entity<SetModel>().Property(s => s.ExceriseId).IsRequired().HasColumnName("set_excersise_id");
            modelBuilder.Entity<SetModel>().Property(s => s.Reps).IsRequired().HasMaxLength(100).HasColumnName("set_rep");
            modelBuilder.Entity<SetModel>().Property(s => s.Weight).IsRequired().HasMaxLength(100).HasColumnName("set_weigth");
            modelBuilder.Entity<SetModel>().Property(s => s.DisplayOrder).IsRequired().HasMaxLength(100).HasColumnName("set_order");
            //RELATIONS
            //One excersise
            modelBuilder.Entity<SetModel>().HasOne<ExcersiseModel>(s => s.Excersise).WithMany(s => s.Sets).HasForeignKey(s => s.ExceriseId);

            #endregion

            #endregion

            #region User and user info

            #region User

            //RELATIONS:
            modelBuilder.Entity<AppUserModel>().HasOne<UserInfoModel>(s => s.UserInfo).WithOne(s => s.User).HasForeignKey<UserInfoModel>(s => s.UserId);
            modelBuilder.Entity<AppUserModel>().HasMany<SchemeModel>(s => s.Schemes).WithOne(s => s.User).HasForeignKey(s => s.UserId);
            modelBuilder.Entity<AppUserModel>().HasMany<NutritionModel>(s => s.Nutritions).WithOne(s => s.User).HasForeignKey(s => s.UserId);

            #endregion
            

            #region UserInfo

            modelBuilder.Entity<UserInfoModel>().ToTable("user_info");
            //Primary key and identity column
            modelBuilder.Entity<UserInfoModel>().HasKey(s => s.Id);
            modelBuilder.Entity<UserInfoModel>().Property(s => s.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("user_info_id");
            //Column settings
            modelBuilder.Entity<UserInfoModel>().Property(s => s.UserId).IsRequired().HasColumnName("user_info_user_id");
            modelBuilder.Entity<UserInfoModel>().Property(s => s.Weight).IsRequired().HasMaxLength(200).HasColumnName("user_info_weight");
            modelBuilder.Entity<UserInfoModel>().Property(s => s.Height).IsRequired().HasMaxLength(300).HasColumnName("user_info_height");
            modelBuilder.Entity<UserInfoModel>().Property(s => s.BirthDate).IsRequired().HasMaxLength(100).HasColumnName("user_info_birth");
            modelBuilder.Entity<UserInfoModel>().Property(s => s.Method).IsRequired(false).HasMaxLength(100).HasColumnName("user_info_method");
            modelBuilder.Entity<UserInfoModel>().Property(s => s.Gender).IsRequired(false).HasMaxLength(100).HasColumnName("user_info_gender");
            modelBuilder.Entity<UserInfoModel>().Property(s => s.RecommendedKcal).IsRequired().HasMaxLength(6000).HasColumnName("user_info_kcal");
            modelBuilder.Entity<UserInfoModel>().Property(s => s.RecommendedProtein).IsRequired().HasMaxLength(500).HasColumnName("user_info_protein");
            //RELATIONS
            //One user
            modelBuilder.Entity<UserInfoModel>().HasOne<AppUserModel>(s => s.User).WithOne(s => s.UserInfo).HasForeignKey<UserInfoModel>(s => s.UserId);

            #endregion

            #endregion

            #region Nutrion and product

            #region Nutrition

            modelBuilder.Entity<NutritionModel>().ToTable("nutrition");
            //Primary key and identity column
            modelBuilder.Entity<NutritionModel>().HasKey(s => s.Id);
            modelBuilder.Entity<NutritionModel>().Property(s => s.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("nutrition_id");
            //Column settings
            modelBuilder.Entity<NutritionModel>().Property(s => s.UserId).IsRequired().HasColumnName("nutrition_user_id");
            modelBuilder.Entity<NutritionModel>().Property(s => s.Amount).IsRequired().HasMaxLength(10000).HasColumnName("nutrition_amount");
            modelBuilder.Entity<NutritionModel>().Property(s => s.Date).IsRequired().HasMaxLength(300).HasColumnName("nutrition_date");
            //RELATIONS
            //One user
            modelBuilder.Entity<NutritionModel>().HasOne<AppUserModel>(s => s.User).WithMany(s => s.Nutritions).HasForeignKey(s => s.UserId);
            //One product 
            modelBuilder.Entity<NutritionModel>().HasOne<ProductModel>(s => s.Product).WithMany(s => s.Nutritions).HasForeignKey(s => s.ProductId);

            #endregion

            #region product

            modelBuilder.Entity<ProductModel>().ToTable("product");
            //Primary key and identity column
            modelBuilder.Entity<ProductModel>().HasKey(s => s.Id);
            modelBuilder.Entity<ProductModel>().Property(s => s.Id).UseIdentityColumn(1, 1).IsRequired().HasColumnName("product_id");
            //Column settings
            modelBuilder.Entity<ProductModel>().Property(s => s.Name).IsRequired().HasMaxLength(200).HasColumnName("product_name");
            modelBuilder.Entity<ProductModel>().Property(s => s.Calorie).IsRequired().HasColumnName("product_calorie");
            modelBuilder.Entity<ProductModel>().Property(s => s.Fat).IsRequired().HasColumnName("product_fat");
            modelBuilder.Entity<ProductModel>().Property(s => s.Carb).IsRequired().HasColumnName("product_carb");
            modelBuilder.Entity<ProductModel>().Property(s => s.Protein).IsRequired().HasColumnName("product_protein");
            modelBuilder.Entity<ProductModel>().Property(s => s.Salt).IsRequired().HasColumnName("product_salt");
            modelBuilder.Entity<ProductModel>().Property(s => s.Sugar).IsRequired().HasColumnName("product_sugar");
            //RELATIONS
            //Many products
            modelBuilder.Entity<ProductModel>().HasMany<NutritionModel>(s => s.Nutritions).WithOne(s => s.Product).HasForeignKey(s => s.ProductId);

            #endregion

            #endregion
        }
    }
}