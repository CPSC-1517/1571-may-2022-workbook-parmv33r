using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Employment
    {
        // An instance of this will hold data about a persom's Employment
        // The code of this class is the definition of that data
        // The Charactersistics (datta) of the class
        // Title, SupervisorLevel, Years of employment with the company
        
        //There are 4 components of a class definition
        // data fields (data members)
        // properties
        // constructors
        // behaviour (methods)

        // data fields 
        // are the storage areas in your class
        // these are treated as variables
        // these may be public, private, public read-only

        // property 
        // These are access techniques to retriece or set data in your class
        // without touching the storage field

        // A property is associated with a single instance of data
        // A property is public so it can be access by an outside user
        // of the class
        // A property MUST have a get
        // A property MAY have a set
        // if no SET, the property is not changable by the user; readonly
        // Commonly used for calculated data of the class.
        // the SET can be either public or private
        // public: user can alter the contents
        // private: only code within the class can alter the contents of the data

        public string Title
        {
            get;
            set;
        }
    }
}