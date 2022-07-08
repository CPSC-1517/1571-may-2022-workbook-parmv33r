using System;
using WestWindSystem.DAL;
using WestWindSystem.Entities;

namespace WestWindSystem.BLL
{

    //this class need to allow from software that is outside of the class library project
    //therefore, this class will have an access type of public.

    public class BuildVersionServices
    {
        #region setup the context connection variable and class constructor
        //variable to hol an instance of context class
        private readonly WestWindContext _context;


        //constructor to create an instance of the registered context class
        internal BuildVersionServices(WestWindContext regcontext)
        {
            _context = regcontext;
        }

        #endregion

        #region Services: Query
        //query: look for something

        //create a method (service) that will retrieve the BuildVersion record
        //this method will be called from the PLweb application page (PageModel file)
        //this method must be public
        //this method becomes part of the class Library's public interface
        public BuildVersion GetBuildVersion()
        {
            // we need to access the DbSet<T> in the context class that
            // has been setup to transport the data from the database to
            // our application
            // _context is the instance of the DAL context class
            //BuildVersions is the property in the context class for the sql table
            //      BuildVersions via the entity BuildVersion
            // BY DEFAULT, ALL records of the sql table will be returned to the DbSet<T>
            //      this means taht your recieving variable MUST be a List<T>
            // HOWEVER, we can use additional methods withing Linq to restrict the
            //      amount of data to be returned.
            // FirstOrDefault() restricts the amount of data to a single record
            //      therefore, I do NOT need a List<T> just and instance of T
            //  First: get the first record on the table that matches the request condition
            // Default: if no record is foound matching the request condition return a null.
            // in our Linq query we have NO filtering conditions.
            BuildVersion info = _context.BuildVersions.FirstOrDefault();
            return info;
        }

        #endregion

    }
}

