﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using NuGetTrends.Data;

namespace NuGetTrends.Data.Migrations
{
    [DbContext(typeof(NuGetTrendsContext))]
    [Migration("20180820172327_IndexNameVersion")]
    partial class IndexNameVersion
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("NuGet.Protocol.Catalog.Models.PackageDependency", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("DependencyId")
                        .HasColumnName("dependency_id");

                    b.Property<int?>("PackageDependencyGroupId")
                        .HasColumnName("package_dependency_group_id");

                    b.Property<string>("Range")
                        .HasColumnName("range");

                    b.HasKey("Id")
                        .HasName("pk_package_dependency");

                    b.HasIndex("PackageDependencyGroupId")
                        .HasName("ix_package_dependency_package_dependency_group_id");

                    b.ToTable("package_dependency");
                });

            modelBuilder.Entity("NuGet.Protocol.Catalog.Models.PackageDependencyGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int?>("PackageDetailsCatalogLeafId")
                        .HasColumnName("package_details_catalog_leaf_id");

                    b.Property<string>("TargetFramework")
                        .HasColumnName("target_framework");

                    b.HasKey("Id")
                        .HasName("pk_package_dependency_group");

                    b.HasIndex("PackageDetailsCatalogLeafId")
                        .HasName("ix_package_dependency_group_package_details_catalog_leaf_id");

                    b.ToTable("package_dependency_group");
                });

            modelBuilder.Entity("NuGet.Protocol.Catalog.Models.PackageDetailsCatalogLeaf", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Authors")
                        .HasColumnName("authors");

                    b.Property<DateTimeOffset>("CommitTimestamp")
                        .HasColumnName("commit_timestamp");

                    b.Property<DateTimeOffset>("Created")
                        .HasColumnName("created");

                    b.Property<string>("Description")
                        .HasColumnName("description");

                    b.Property<string>("IconUrl")
                        .HasColumnName("icon_url");

                    b.Property<bool>("IsPrerelease")
                        .HasColumnName("is_prerelease");

                    b.Property<string>("Language")
                        .HasColumnName("language");

                    b.Property<DateTimeOffset>("LastEdited")
                        .HasColumnName("last_edited");

                    b.Property<string>("LicenseUrl")
                        .HasColumnName("license_url");

                    b.Property<bool?>("Listed")
                        .HasColumnName("listed");

                    b.Property<string>("MinClientVersion")
                        .HasColumnName("min_client_version");

                    b.Property<string>("PackageHash")
                        .HasColumnName("package_hash");

                    b.Property<string>("PackageHashAlgorithm")
                        .HasColumnName("package_hash_algorithm");

                    b.Property<string>("PackageId")
                        .HasColumnName("package_id");

                    b.Property<long>("PackageSize")
                        .HasColumnName("package_size");

                    b.Property<string>("PackageVersion")
                        .HasColumnName("package_version");

                    b.Property<string>("ProjectUrl")
                        .HasColumnName("project_url");

                    b.Property<DateTimeOffset>("Published")
                        .HasColumnName("published");

                    b.Property<string>("ReleaseNotes")
                        .HasColumnName("release_notes");

                    b.Property<bool?>("RequireLicenseAgreement")
                        .HasColumnName("require_license_agreement");

                    b.Property<string>("Summary")
                        .HasColumnName("summary");

                    b.Property<List<string>>("Tags")
                        .HasColumnName("tags");

                    b.Property<string>("Title")
                        .HasColumnName("title");

                    b.Property<int>("Type")
                        .HasColumnName("type");

                    b.Property<string>("VerbatimVersion")
                        .HasColumnName("verbatim_version");

                    b.HasKey("Id")
                        .HasName("pk_package_details_catalog_leafs");

                    b.HasIndex("PackageId", "PackageVersion");

                    b.ToTable("package_details_catalog_leafs");
                });

            modelBuilder.Entity("NuGetTrends.Data.Cursor", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<DateTimeOffset>("Value")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_cursors");

                    b.ToTable("cursors");

                    b.HasData(
                        new { Id = "Catalog", Value = new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)) }
                    );
                });

            modelBuilder.Entity("NuGetTrends.Data.PackageRegistration", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("PackageId")
                        .HasColumnName("package_id");

                    b.HasKey("Id")
                        .HasName("pk_package_registrations");

                    b.ToTable("package_registrations");
                });

            modelBuilder.Entity("NuGet.Protocol.Catalog.Models.PackageDependency", b =>
                {
                    b.HasOne("NuGet.Protocol.Catalog.Models.PackageDependencyGroup")
                        .WithMany("Dependencies")
                        .HasForeignKey("PackageDependencyGroupId")
                        .HasConstraintName("fk_package_dependency_package_dependency_group_package_dependenc~");
                });

            modelBuilder.Entity("NuGet.Protocol.Catalog.Models.PackageDependencyGroup", b =>
                {
                    b.HasOne("NuGet.Protocol.Catalog.Models.PackageDetailsCatalogLeaf")
                        .WithMany("DependencyGroups")
                        .HasForeignKey("PackageDetailsCatalogLeafId")
                        .HasConstraintName("fk_package_dependency_group_package_details_catalog_leafs_package~");
                });
#pragma warning restore 612, 618
        }
    }
}
