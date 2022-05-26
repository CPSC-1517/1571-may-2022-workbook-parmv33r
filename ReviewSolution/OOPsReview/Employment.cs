using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPsReview.Data
{
    public class Employment
    {
        //An instance of this class will hold data about a person's
        //  employment
        //The code of this class is the definition of that data
        //The characteristics (data) of the class
        //  Title, SupervisorLevl, Years of employment within the company

        //there are 4 components of a class definition
        //  data fields (data members)
        //  property
        //  constructor
        //  behaviour (method)

        //data fields
        //  are storage areas in your class
        //  these are treated as variables
        //  these may be public, private, public readonly
        private string _Title;
        private double _Years;
        public int PublicDataField;

        //property
        //These are access techniques to retrieve or set data in
        //  your class without directly touching the storage data field

        //A property is associated with a single instance of data
        //A property is public so it can be access by an outside user
        //  of the class
        //A property MUST have a get
        //A property MAY have a set
        //  if no set, the property is not changable by the user; readonly
        //      commonly used for calculated data of the class
        //  the set can be either public or  private
        //     public: the user can alter the contents of the data
        //     private: only code within the class can alter the contents of the data

        //Fully implemented porperty
        // a) a declared storage area (Data feild)
        // b) a decalred property signature (access returneddatatype propertyname)
        // c) a coded accessor (get) coding block: public
        // d) an optional coded mutator (set) codingg block: public or private
        //      if the set is private the only way to place data into this property is
        //      via constructor or a behaviour (method)

        // When:
        // a) if you are storing the associate data in an explicity declared data field
        // b) if you are doing validation on incoming data
        // c) creating a property that genereates output from other data sources
        //      within the class (readonly property); this property would ONLY have a
        //      accessor (get)
        public string Title
        {
            // a property is associated with a single piece of data
            get
            {
                // accessor
                // the get "coding block" will return the contents of a data field(s)
                // the return has sytnax of return expression
                return _Title;
            }

            set
            {
                // mutator
                // the set "coding block" recieves an incoming value and places it into
                // the associated data field
                // during the setting, you might wish to validate the incoming data
                // during the setting, you might wish to do some type of logical
                // processing using the data to set another field
                // the incoming piece of data is referred to using the keyword "value"

                // ensure that the incoming data is not null or empty or just whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }

                // data is considered valid.
                _Title = value;
            }
        }

        // auto implemented property

        // these properties differ only in syntax
        // each property is responsible for a single piece of data
        // these properties do NOT reference a declared private data member
        // the system generates an internal storage area of the return data type
        // the system manages the internal storage for teh accessor and mutator
        // THERE IS NO ADDITIONAL LOGIN APPLIED TO THE DATA VALUE!!!

        // Using an enum for this field will automatically restrict the data values
        // this property can contain.

        // syntax:  access rdt  propertyname {get; [private]set;}


        public SupervisoryLevel Level { get; set; }

        public double Years
        {
            get
            {
                return _Years;
            }

            set
            {
                if (!Utilities.IsZeroPositive(value))
                {
                    throw new ArgumentOutOfRangeException($"Years value {value} is invalid. Must be o or greater");
                }

                _Years = value;
            }
        }

        // constructor

        // this is used to initialize the physical object (instance) during its creation
        // the result of the creation is to ensure that the coder gets an instance in a valid
        // "Known state"
        //
        // if your class definition has no constructor coded, the data members and/or
        // auto implemented properties are set to the C# default data type value.
        //
        // you can code one or more constrcutors in your class definition
        // IF YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE FOR ALL
        // CONSTRUCTORS USED BY THE CLASS !!!!!
        //
        // generally if you are going to code your own constructor(s) you code two types
        // Default: this constrcutor does not take in any parameters
        //          this constructor mimics the default system constructor
        // Greedy:  this constructor has a list of parameters, one for each property,
        //          declared for incoming data.
        //
        //  (), (a), (b), (c), (d), (a,b), (a,c), (a,d).....2 raise power of 4 = 16 constructors
        //  (), (a,b,c,d)
        //
        // syntax: accessstype  classname([list of parameters]) {constructor code block}
        //
        // IMPORTANT: The constructor DOES NOT have a return datatype.
        //            You DO NOT call constructor directly, it is called using the
        //              new command (= new classname(.....));

        public Employment()
        {
            //constructor body
            // a) empty: values will be set to c# defaults
            // b) you COULD assigned literal values to your properties with this constructor

            // the values that you give your class data member/properties CAN be assigned
            //      directly to a data member.
            // HOWEVER: if you have validated properties, you SHOULD consider saving your
            //          data values via property

            // You CAN code your validation logic within your constructors BECAUSE
            // objects run your constructor when it is created.
            // Placing your logic in the constructor could be done if you property has
            //  a private set OR if your public data member is a readonly data member.
            // Private sets and readonly data members CAN NOT have their data altered directly

            Level = SupervisoryLevel.TeamMember;
            Title = "Unknown";
        }

        // Greedy Constructor
        public Employment(string title, SupervisoryLevel level, double years= 0.0)
        {
            //you COULD your validation in this constructor

            //cnostructor body
            //  a) a parameter for each property
            //  b) you COULD could your validation in this contructor.
            //  c) validation for public readonly data members MUST be done here
            //  d) validation for properties with a private set MUST be done here
            //      if not done in the property.

            // Default parameters

            // WHY? it allows the programmer to use your constructor/method without having to
            //  specify all arguments in the code to your constructor/method

            // Location: end of parameter list
            // How many: as many as you wish
            // Values for your default paramemters must be a calid value
            // Postion and order of specified default parameters are important when the
            //  program uses the constructor/method.
            // default parameters CAN be skipped, HOWEVER, you still must account for the
            //  skipped parameter in your argument code list using commas
            // by giving the default parameter an argument value on the call, the constructor/method
            //  default value is overridden.

            // Syntax: datatype paramemtername = default value
            // example: years on this constructor is a default parameter

            // example: skipped defaults (3 default parameters, second one skipped)
            //          (string requiredparam, int requiredparam, int default1 = 0, int default2 = 0 , int default3 = 0)
            //
            // call: ... ("required string", 25, 10, , 5) default2 was skipped and it will be zero

            Title = title;
            Level = level;
            Years = years; // eventually the data will be placed in _Years

        }

        // Behaviours (A.K.A Methods)
        // a behaviour is any method in your class
        // behaviours can be private (for use by the class only);
        //                   Public (for use by the outside user)
        // all rules about methods are in effect

        // a special method may be a placed in your class to reflect the data stored by the
        //  instance (object) based on this class definition.
        // this method is the part of the system software and can be overridden by your own
        //  version of the method.

        public override string ToString()
        {
            // this string is known as a "comma seperated values (csv)" string
            return $"{Title},{Level},{Years}";
        }

        public void SetEmployeeResponsibilityLevel(SupervisoryLevel level)
        {
            // this method, in this example would not be necessary as the acess to directly
            //  to Level (property) is public (set;)
            // HOWEVER: IF the Level property had a private set; the outside user would not
            //  have direct access to changing the property.
            // THEREFORE: a method (besides the constructor) would need to be supplied to allow
            //  the outsider user the ability to alter the property value (if they so desired)

            // this assignment used the set; of the property
            //Enums does not require validation for bad value because it won't compile anyways, we cannot give a wrong value it wont accept.

            Level = level;
        }
    }
}