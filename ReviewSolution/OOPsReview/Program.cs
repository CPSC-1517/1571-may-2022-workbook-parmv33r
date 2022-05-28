// See https://aka.ms/new-console-template for more information
using OOPsReview.Data;

// this class program is by default the namespace of the project: OOPsReview
// Console is a static class
// You CANNOT create your own instance of a static class

//Console.WriteLine("Hello, World!");

// an instance class needs to be created using the new command and the class constructor
// one needs to declare a variable of datatype: ex Employment

Employment myEmp = new Employment("Level 5 Programmer", SupervisoryLevel.Supervisor, 15.9); // default constructor
Console.WriteLine(myEmp.ToString()); // use the instance name to reference items within your class
Console.WriteLine($"{myEmp.Title},{myEmp.Level},{myEmp.Years}");

myEmp.SetEmployeeResponsibilityLevel(SupervisoryLevel.DepartmentHead);

Console.WriteLine(myEmp.ToString());

// testing (Simulate a Unit Test)
// Arrange (setup of test data)
Employment Job = null;

// passing a reference variable to a method
// a class is a reference data store
// this passes the actual memory address of the data store to the method
// Any changes done to the data store within the method WILL BE reflected
//  in the data store WHEN you return from the method.
CreateJob(ref Job);
Console.WriteLine(Job.ToString());
// Passing value arguments to a method AND receiving a value result back from the method
// Struct is a value data store
ResidentAddress Address = CreateAddress();
Console.WriteLine(Address.ToString());

// Act (Execution of the test you wish to perform)
// test that we can create a Person (Composite instance)
Person me = null; // variable capable of holding Person instance
me = CreatePerson(Job, Address);
// Access (Check your result)

Console.WriteLine($"{me.Firstname} {me.LastName} lives at {me.Address.ToString()}" +
    $" having a job count of {me.NumberOfPositions}");

void CreateJob(ref Employment job)
{
    // since the class may throw exceptions, you should have user friendly error handeling
    try
    {
        job = new Employment(); //default constructor; new command takes a constructor as it's
        // Because my properties have public set(mutators), I can "set" the value of the
        //  proprty directly from the driver program
        job.Title = "Boss";
        job.Level = SupervisoryLevel.Owner;
        job.Years = 25.5;

        //OR

        // Use greedy constructor
        //job = new Employment("Boss", SupervisoryLevel.Owner, 25.5);
    }

    catch(ArgumentNullException ex)
    {
        Console.WriteLine(ex.Message);
    }

    catch (ArgumentOutOfRangeException ex)
    {
        Console.WriteLine(ex.Message);
    }

    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}


ResidentAddress CreateAddress()
{
    ResidentAddress address = new ResidentAddress(10706, "106 street", "", "", "Edmonton", "AB");
    return address;
}

Person CreatePerson(Employment job, ResidentAddress address)
{
    Person me = new Person("Don", "Welch", address, null);
    me.AddEmployment(job);
    return me;
}