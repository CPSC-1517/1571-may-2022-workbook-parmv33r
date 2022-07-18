﻿using System;
using Microsoft.EntityFrameworkCore;
using WestWindSystem.Entities;

namespace WestWindSystem.DAL
{

    //let the access type for this class as internal
    // "internal" access to this class is ONLY possible from
    //      within this project
    //why it adds a layer of security to the web application

    //DbContext is the entityframework software that talks to the database.
    //we inherit the required class

    //Add the NuGet Package: Microsoft.EntityFrameworkCore.SQLServer
    // required for DbContext
    internal class WestWindContext : DbContext
    {
        //constructor will pass the context connection to the DbContext parent
        //  for use in setting up the database connection

        public WestWindContext(DbContextOptions<WestWindContext> options) : base(options)
        {

        }

        // setup properties in this class that can be referenced by others
        //  code within your class library.
        //the properties represent a collection of instances of the entity
        // retreived from or sent to the database

        // one property per entity in Entities.
        public DbSet<BuildVersion> BuildVersions { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Territory> Territories { get; set; }

    }
}

