﻿// <auto-generated />
using KBot.Resources;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KBot.Migrations
{
    [DbContext(typeof(SqliteDbContext))]
    [Migration("20181206191854_Migration")]
    partial class Migration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity("KBot.Resources.Database.Person", b =>
                {
                    b.Property<ulong>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Banner");

                    b.Property<string>("BattleTag");

                    b.Property<int>("BdayDay");

                    b.Property<int>("BdayMonth");

                    b.Property<ushort>("CompetitiveRank");

                    b.Property<string>("DisplayName");

                    b.Property<int>("Followers");

                    b.Property<bool>("IsLive");

                    b.Property<bool>("IsProfilePrivate");

                    b.Property<string>("Logo");

                    b.Property<string>("Name");

                    b.Property<string>("Preview");

                    b.Property<string>("Title");

                    b.Property<string>("Url");

                    b.Property<int>("Views");

                    b.HasKey("Id");

                    b.ToTable("People");
                });
#pragma warning restore 612, 618
        }
    }
}
