﻿// <auto-generated />
using System;
using DenMarkTest.DataAccessLayer.Dbcontexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DenMarkTest.DataAccessLayer.Migrations
{
    [DbContext(typeof(DanishContext))]
    partial class DanishContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DenMarkTest.DataAccessLayer.Entities.Test", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateCreated");

                    b.Property<DateTime>("dateModified");

                    b.Property<string>("guid");

                    b.Property<bool>("isActive");

                    b.Property<DateTime>("testDate");

                    b.Property<string>("testDescription");

                    b.Property<string>("testType");

                    b.HasKey("id");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("DenMarkTest.DataAccessLayer.Entities.TestParticipants", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParticipantId");

                    b.Property<string>("Result");

                    b.Property<int?>("TestId");

                    b.Property<DateTime>("dateCreated");

                    b.Property<DateTime>("dateModified");

                    b.Property<bool>("isActive");

                    b.HasKey("id");

                    b.HasIndex("ParticipantId");

                    b.HasIndex("TestId");

                    b.ToTable("TestParticipants");
                });

            modelBuilder.Entity("DenMarkTest.DataAccessLayer.Entities.TestTypes", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateCreated");

                    b.Property<DateTime>("dateModified");

                    b.Property<bool>("isActive");

                    b.Property<string>("testDescription");

                    b.Property<string>("testType");

                    b.HasKey("id");

                    b.ToTable("TestTypes");
                });

            modelBuilder.Entity("DenMarkTest.DataAccessLayer.Entities.User", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("dateCreated");

                    b.Property<DateTime>("dateModified");

                    b.Property<string>("fname");

                    b.Property<bool>("isActive");

                    b.Property<string>("lname");

                    b.HasKey("id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("DenMarkTest.DataAccessLayer.Entities.TestParticipants", b =>
                {
                    b.HasOne("DenMarkTest.DataAccessLayer.Entities.User", "Participant")
                        .WithMany()
                        .HasForeignKey("ParticipantId");

                    b.HasOne("DenMarkTest.DataAccessLayer.Entities.Test", "Test")
                        .WithMany("TestParticipants")
                        .HasForeignKey("TestId");
                });
#pragma warning restore 612, 618
        }
    }
}
