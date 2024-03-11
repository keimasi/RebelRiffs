﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MusicManagement.Infrastructure.EfCore;

#nullable disable

namespace MusicManagement.Infrastructure.EfCore.Migrations
{
    [DbContext(typeof(MusicContext))]
    [Migration("20240310184315_updata_relationBand")]
    partial class updata_relationBand
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MusicManagement.Domain.Models.Album", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AlbumCategoryId")
                        .HasColumnType("bigint");

                    b.Property<long>("AlbumPictureId")
                        .HasColumnType("bigint");

                    b.Property<long?>("BandId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("ReleasedDate")
                        .IsRequired()
                        .HasColumnType("datetime2");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumCategoryId");

                    b.HasIndex("AlbumPictureId")
                        .IsUnique();

                    b.HasIndex("BandId");

                    b.ToTable("tbAlbums", (string)null);
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.AlbumCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Artist", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("ArtistPictureId")
                        .HasColumnType("bigint");

                    b.Property<long?>("BandId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("Country")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<long?>("InstrumentId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ArtistPictureId")
                        .IsUnique()
                        .HasFilter("[ArtistPictureId] IS NOT NULL");

                    b.HasIndex("BandId");

                    b.HasIndex("InstrumentId");

                    b.ToTable("tbArtists", (string)null);
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Audio", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AlbumId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.ToTable("Audios");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Band", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long?>("BandCategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BandCategoryId")
                        .IsUnique()
                        .HasFilter("[BandCategoryId] IS NOT NULL");

                    b.ToTable("tbBands", (string)null);
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.BandCategory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BandId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BandCategory");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Instrument", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Instruments");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.PictureModels.AlbumPicture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("AlbumId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AlbumPicture");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.PictureModels.ArtistPicture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("ArtistId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ArtistPicture");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.PictureModels.BandPicture", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<long>("BandId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BandId");

                    b.ToTable("BandPicture");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Album", b =>
                {
                    b.HasOne("MusicManagement.Domain.Models.AlbumCategory", "AlbumCategory")
                        .WithMany("Albums")
                        .HasForeignKey("AlbumCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicManagement.Domain.Models.PictureModels.AlbumPicture", "AlbumPicture")
                        .WithOne("Album")
                        .HasForeignKey("MusicManagement.Domain.Models.Album", "AlbumPictureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MusicManagement.Domain.Models.Band", "Band")
                        .WithMany("Albums")
                        .HasForeignKey("BandId");

                    b.Navigation("AlbumCategory");

                    b.Navigation("AlbumPicture");

                    b.Navigation("Band");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Artist", b =>
                {
                    b.HasOne("MusicManagement.Domain.Models.PictureModels.ArtistPicture", "ArtistPicture")
                        .WithOne("Artist")
                        .HasForeignKey("MusicManagement.Domain.Models.Artist", "ArtistPictureId");

                    b.HasOne("MusicManagement.Domain.Models.Band", "Band")
                        .WithMany("Artists")
                        .HasForeignKey("BandId");

                    b.HasOne("MusicManagement.Domain.Models.Instrument", "Instrument")
                        .WithMany("Artists")
                        .HasForeignKey("InstrumentId");

                    b.Navigation("ArtistPicture");

                    b.Navigation("Band");

                    b.Navigation("Instrument");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Audio", b =>
                {
                    b.HasOne("MusicManagement.Domain.Models.Album", "Album")
                        .WithMany("Audios")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Album");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Band", b =>
                {
                    b.HasOne("MusicManagement.Domain.Models.BandCategory", "BandCategory")
                        .WithOne("Band")
                        .HasForeignKey("MusicManagement.Domain.Models.Band", "BandCategoryId");

                    b.Navigation("BandCategory");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.PictureModels.BandPicture", b =>
                {
                    b.HasOne("MusicManagement.Domain.Models.Band", "Band")
                        .WithMany("Pictures")
                        .HasForeignKey("BandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Band");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Album", b =>
                {
                    b.Navigation("Audios");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.AlbumCategory", b =>
                {
                    b.Navigation("Albums");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Band", b =>
                {
                    b.Navigation("Albums");

                    b.Navigation("Artists");

                    b.Navigation("Pictures");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.BandCategory", b =>
                {
                    b.Navigation("Band")
                        .IsRequired();
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.Instrument", b =>
                {
                    b.Navigation("Artists");
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.PictureModels.AlbumPicture", b =>
                {
                    b.Navigation("Album")
                        .IsRequired();
                });

            modelBuilder.Entity("MusicManagement.Domain.Models.PictureModels.ArtistPicture", b =>
                {
                    b.Navigation("Artist")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
