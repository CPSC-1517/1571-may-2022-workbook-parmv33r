using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WestWindSystem.Entities
{

    //we need to point this entity definition to the sql table that it represents.
    // to do this we can use an annotation.
    //annotations are place IMMEDIATELY before the item in the definition it
    // refers to.

    [Table("BuildVersion")]

    public class BuildVersion
    {
        //in sql nvarchar(),varchar,nchar,char is declared as a string in your
        //  Entity definition!!!!!!!!!
        //sql bit is a bool in C#

        //names of class properties DO NOT need to match the attribute names
        //  on your SQL table (entity)
        //HOWEVER, IF you use a different names then ORDER is IMPORTANT in this
        //  entity class. It MUST match th eorder in the sql table.
        //If your property names match then the order within this entity class
        //  is not important. However, it is much easier to match your sql table
        // to your entity if you maintain the same order for data.

        //annotation to indicate the primary key/property
        // 3 syntax forms for the pkey annotation

        //IDENTITY() pkey in sql
        // a) [Key]

        //Your sql pkey is NOT a IDENTITY() pkey in sql
        // b) [Key]
        //    [DatabseGenratedOption(DatabseGeneratedOption.None)]

        //Your sql pkey is a compound pkey in sql
        // you will need to add the annotation in front of each part of the
        //      compound key attribute / property to form the correct pkey structure
        // c) [Key]
        //    [Coulmn(Order=n)]

        // https://www.entityframeworktutorial.net/code-first/key-dataannotations-attribute-in-code-first.aspx

        //if you have a foriegn and your attribute / property name are the same
        // the system will already know about the fkey relationships
        // therefore you DO NOT use the annotation [ForiegnKey]

        [Key]
        public int Id { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public DateTime ReleaseDate { get; set; }

        // you can create a property within your entity that is NOT a data
        //  attribute in you sql table.
        // if you do, use the {NotMapped} annotation.

        //example

        //assume you have two separete properties FirstName and LastName
        // you wish to create a string of Fullname
        // you do not wish to force the program to consistently concatenate
        //  the properties in their code
        // you wish to make it easier for the programmer by doing the
        // concatenation for them

        //[NotMapped]
    }
}

