﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sample;

namespace w3.Migrations
{
    [DbContext(typeof(notedatabase))]
    partial class notedatabaseModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("sample.mynotes", b =>
                {
                    b.Property<int?>("id");

                    b.Property<bool>("favourite");

                    b.Property<string>("text");

                    b.Property<string>("title");

                    b.Property<string>("type");

                    b.HasKey("id");

                    b.ToTable("notes");
                });
#pragma warning restore 612, 618
        }
    }
}
