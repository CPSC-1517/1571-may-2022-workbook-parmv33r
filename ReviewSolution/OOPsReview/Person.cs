using System;

namespace OOPsReview.Data
{
	public class Person
	{
        //Example of a composite class
        // a composite class uses otehr classes/strucs in its definition
        // a composite class is recognized with the phrase "has a" class.
        // this class of Person "has a" resident address
        // this class has a List<T> where <T> represents a datatype and in this
        //  class <T> is a collection of Employement.

        // Review video on inheritence and composition

        // each instance of this class will represent an individual
        // this class will define the following charasterstics of a person
        //  First Name, Last Name, the current resident address, List of employment positions


		private string _FirstName;
		private string _LastName;



        public string FirstName
        {
            get
            {
                return _FirstName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("First name is required");
                }

                _FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _LastName;
            }

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Last name is required");
                }

                _LastName = value;
            }
        }

        // Composition actually uses the other struct/class as a property/Feild within
        //  the definition of the class being specified (created)
        // in this example address is field that is a data member

        // This field is not a property
        // The data type is a developer defined datatype (struct)

        public ResidentAddress Address;

        public List<Employment> EmploymentPositions { get; private set; }

        //this propery will compile cleanly
        //this property will return a value IF EMploymentPositions has a instance of List <T>
        //this property will ABORT IF EmploymentPositions has NOT be set to an instance of List<T>

        public int NumberOfPositions { get { return EmploymentPositions.Count; } }

        //public Person()
        //{
        //    // the system will automatically assign default system values to
        //    //   our data members according to their datatype.
        //    // string -> Null
        //    // classes/Objects -> Null

        //    // firstname and lastname has validations voiding a null value

        //    Firstname = "Unknown";
        //    LastName = "Unknown";
        //    // if one tried to reference an instance's data and the instance is
        //    // null THEN one would get a exception: null exception
        //    // even though you have no instances to store, you will at least have
        //    //  someplace to put the data ONCE it is supplied

        //    EmploymentPositions = new List<Employment>();
        //}

        // Option 2

        // Do not code a "Default" Constructor
        // Code ONLY the "GREEDY" Constructor
        // If only a constructor exist for the class, the ONLY
        //  way to possibly create an instance for the class within
        //  program would be to use the constructor when the class
        //  instance is created.

        public Person(String firstname, String lastname, ResidentAddress address, List<Employment> employmentpositions)
        {
            FirstName = firstname;
            LastName = lastname;
            Address = address;
            if (employmentpositions !=null)
            {
                EmploymentPositions = employmentpositions;
            }

            else
            {
                //Allow a null parameter value and the class to have an empty List<T>
                EmploymentPositions = new List<Employment>();
            }
        }

        public void ChangeName(string firstname, string lastname)
        {
            FirstName = firstname;
            LastName = lastname;
        }

        public void AddEmployment(Employment employment)
        {
            if (employment == null)
            {
                throw new ArgumentNullException("You must supply an employment record for it to be added to this person");
            }

            EmploymentPositions.Add(employment);
        }
	}
}

