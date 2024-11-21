﻿// <auto-generated />
using Insurance.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Insurance.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20241121061440_updload22")]
    partial class updload22
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Insurance.Models.CompanyModel", b =>
                {
                    b.Property<string>("companyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Varchar(150)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("companyActive")
                        .HasColumnType("bit");

                    b.Property<string>("companyDescription")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("companyName")
                        .HasColumnType("Varchar(150)");

                    b.HasKey("companyId");

                    b.ToTable("Company");
                });

            modelBuilder.Entity("Insurance.Models.CustomerModel", b =>
                {
                    b.Property<string>("customerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Varchar(150)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("EmailId")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("aadharNo")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("alternativeNo")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("bloodGroup")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("children")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("dateofBirth")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("dateofWedding")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("fatherName")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("gender")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("graduation")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("married_Uncheck_for_single")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("mobileNumber")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("motherName")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("permanent_address_area")
                        .HasColumnType("Varchar(250)");

                    b.Property<string>("permanent_address_street")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("permanent_city")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("permanent_location")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("present_address_area")
                        .HasColumnType("Varchar(250)");

                    b.Property<string>("present_address_street")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("present_city")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("present_location")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("qualification")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("same_as_permanent_address")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("spouse_dateofbirth")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("spouse_name")
                        .HasColumnType("Varchar(150)");

                    b.HasKey("customerId");

                    b.ToTable("customer");
                });

            modelBuilder.Entity("Insurance.Models.PolicyModel", b =>
                {
                    b.Property<string>("policyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Varchar(150)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<bool>("policyActive")
                        .HasColumnType("bit");

                    b.Property<string>("policyDescription")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("policyName")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.HasKey("policyId");

                    b.ToTable("Policy");
                });

            modelBuilder.Entity("Insurance.Models.RenewalModel", b =>
                {
                    b.Property<string>("renewalId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Varchar(150)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("amount")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("companyId")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("customerId")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("customer_name")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("description")
                        .HasColumnType("Varchar(300)");

                    b.Property<string>("duration_months")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("next_renewal")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("policyId")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("policy_for")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("policy_no")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("renewal_date")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.HasKey("renewalId");

                    b.HasIndex("companyId");

                    b.HasIndex("customerId");

                    b.HasIndex("policyId");

                    b.ToTable("Renewal");
                });

            modelBuilder.Entity("Insurance.Models.RenewvalUploads", b =>
                {
                    b.Property<string>("imgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Varchar(150)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("imgPath")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("imgSource")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.HasKey("imgId");

                    b.ToTable("renewval_upload");
                });

            modelBuilder.Entity("Insurance.Models.UploadModel", b =>
                {
                    b.Property<string>("imgId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("Varchar(150)")
                        .HasDefaultValueSql("NEWID()");

                    b.Property<string>("CreatedDate")
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("imgPath")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.Property<string>("imgSource")
                        .IsRequired()
                        .HasColumnType("Varchar(150)");

                    b.HasKey("imgId");

                    b.ToTable("custome_upload");
                });

            modelBuilder.Entity("Insurance.Models.RenewalModel", b =>
                {
                    b.HasOne("Insurance.Models.CompanyModel", "company")
                        .WithMany()
                        .HasForeignKey("companyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insurance.Models.CustomerModel", "customer")
                        .WithMany()
                        .HasForeignKey("customerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Insurance.Models.PolicyModel", "policy")
                        .WithMany()
                        .HasForeignKey("policyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("company");

                    b.Navigation("customer");

                    b.Navigation("policy");
                });
#pragma warning restore 612, 618
        }
    }
}
