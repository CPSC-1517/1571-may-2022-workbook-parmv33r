﻿// See https://aka.ms/new-console-template for more information
using System.Text.Json;
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

//OR

//Person me = CreatePerson(Job, Address);

// Access (Check your result)

Console.WriteLine($"{me.FirstName} {me.LastName} lives at {me.Address.ToString()}" +
    $" having a job count of {me.NumberOfPositions}");

Console.WriteLine("\nJobs: output via foreach loop\n");
foreach (var item in me.EmploymentPositions)
{
    if (item.Years > 0)
        Console.WriteLine(item.ToString());
}

Console.WriteLine("\nJobs: output via for loop\n");
for (int i = 0; i < me.EmploymentPositions.Count; i++)
{
    if (me.EmploymentPositions[i].Years > 0)
        Console.WriteLine(me.EmploymentPositions[i].ToString());
}
//using employment.Parse


string theRecord = "Boss,Owner,5.5";
Employment theParsedRecord = Employment.Parse(theRecord);
Console.WriteLine(theParsedRecord.ToString());

//using Employment .TryParse
theParsedRecord = null;
if (Employment.TryParse(theRecord, out theParsedRecord))
{
    //do whatever logic you need to do with the valid data
    Console.WriteLine(theParsedRecord.ToString());

}
//if the TryParse failed, you would be handling it via your user frindly error handling
//  code

// File I/O
//writing a comma separated value file
//string pathname = WriteCSVFile();

//read a comma separated value file
//we will be using ReadAllLines(pathname); returns an array of strings; each
//  array element is one line in your csv file.
const string PATHNAME = "../../../Employment.csv";
const string JSONPATHNAME = "../../../Employment.json";

List<Employment> jobs = ReadCSVFile(PATHNAME);
Console.WriteLine($"\nResults of reading the csv file at : {PATHNAME}");
foreach (Employment job in jobs)
{
    Console.WriteLine($"Title: {job.Title} Level: {job.Level} Year: {job.Years}");
}

//writing a JSON file
//me is built above
SaveAsJson(me, JSONPATHNAME);

//Read a JSON file
Person jsonMe = ReadAsJson(JSONPATHNAME);
Console.WriteLine("\nOutput from reading a json file\n");
Console.WriteLine($"{jsonMe.FirstName} {jsonMe.LastName} lives at {jsonMe.Address.ToString()}" +
    $" having a job count of {jsonMe.NumberOfPositions}");
Console.WriteLine("\nJobs: output via foreach loop\n");
foreach (var item in jsonMe.EmploymentPositions)
{
    if (item.Years > 0)
        Console.WriteLine(item.ToString());
}

Console.WriteLine("\nJobs: output via for loop\n");

string WriteCSVFile()
{
    string pathname = "";
    try
    {
        List<Employment> jobs = new List<Employment>();
        Employment theEmployment = new Employment("trainee", SupervisoryLevel.Entry, 0.5);
        jobs.Add(theEmployment);
        jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 3.5));
        jobs.Add(new Employment("lead", SupervisoryLevel.TeamLeader, 7.4));
        jobs.Add(new Employment("dh new projects", SupervisoryLevel.DepartmentHead, 1.0));

        //create a list of comma separated value strings
        //the contents of each string will be 3 values of Emmployment
        List<string> csvlines = new();

        //place all the instances of Employment in the collection of jobs
        //  in the csvlines using .ToString() of the Employment class
        foreach (var item in jobs)
        {
            csvlines.Add(item.ToString());
        }

        //write to a text file the csv lines
        //each line represents a Employment instance
        //you could use StreamWriter
        //HOWEEVER within the File class there is a method that outputs a list of strings
        //  all within ONE command. There is NO NEED for a StreamWriter instance
        //the pathname is the minimum for the command
        //the file by default will be created in the same folder as your .exe file
        //you CAN alter the path name using relative addressing

        pathname = PATHNAME; 
        File.WriteAllLines(pathname, csvlines);
        Console.WriteLine($"\n Check out the CSV file at: {Path.GetFullPath(pathname)}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return Path.GetFullPath(pathname);
}


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
    //Person me = new Person("Don", "Welch", address, null);

    //one could add the job(s) to the instance of Person (me) after the instance
    //  is create via the behaviour AddEmployment(Employment emp)
    // me.AddEmployment(job);

    //OR

    // one could create a List<T> and add to the List<t> before creating the person instance
    List<Employment> employments = new List<Employment>();
    employments.Add(job); // add a element to the list
    Person me = new Person("Don", "Welch", address, employments);

    // Create additional jobs and load to a Person
    Employment employment = new Employment("New Hire", SupervisoryLevel.Entry, 0.5);
    me.AddEmployment(employment);
     employment = new Employment("Team Head", SupervisoryLevel.TeamLeader, 5.2);
    me.AddEmployment(employment);
     employment = new Employment("Department IT Head", SupervisoryLevel.DepartmentHead, 6.2);
    me.AddEmployment(employment);
    return me;

}

List<Employment> ReadCSVFile(string pathname)
{
    List<Employment> employments = new List<Employment>();
    //use this variable repeatedly to hold a new instance of Employment
    //  as I read and Parse the CSV file.
    Employment job = null;
    //this try/catch error handling is for system I/O errors while reading the
    //  file
    try
    {
        //Read the CSV file using File.ReadAllLines()
        //thus NO need to create a StreamReader.
        //ReadAllLines returns an array of strings, each string representing
        //  one line in your CSV file
        string[] csvFileInput = File.ReadAllLines(pathname);

        //process EACH line in the file
        foreach (string csvLine in csvFileInput)
        {
            //as you process each line, we will use the TryParse of Employment
            //this will return an instance of Employment IF the data is valid
            //IF the data is NOT valid, Employment will throw various errors
            //we DO NOT want to stop processing the strings IF an error is discovered
            //THEREFORE we WILL have a try/catch WITHIN this loop
            try
            {
                //attempt to convert a comma separate value string into an
                //  instance of Employment (parse the data)
                bool converted = Employment.TryParse(csvLine, out job);
                //test if the parsing was successful
                //the way this logic is set up, the testing is unnecessary
                //  why? if the parse fails, an error would have be throw, thus
                //       processing will have jumped to a catch
                //why do the test then?
                //  consider that on a successful parse you may have additional
                //  (complex) logic to perform.
                if (converted)
                {
                    employments.Add(job);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"Format error: {ex.Message}");
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine($"Argument error: {ex.Message}");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Out of Range error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unknown exception error: {ex.Message}");
            }
        }
    }
    catch (IOException ex)
    {
        Console.WriteLine($"Reading CSV file error: {ex.Message}");
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return employments;
}

void SaveAsJson(Person me, string pathname)
{
    //the term use to read and write Json files is Serialization
    //the classes use are referred to as serializers
    //with writing we can make the file produce more readable format
    //  by using indentation
    //Json is very good at using objects and properties, however, it
    //  needs help/prompting to work better with fields: option IncludeFields
    //the term Serialize is generally used to indicate writing
    //instance instatiation
    JsonSerializerOptions options = new JsonSerializerOptions
    {
        WriteIndented = true,
        IncludeFields = true
    };
    try
    {
        //Serialize the instance of Person
        //produce a string of serialized data
        string jsonstring = JsonSerializer.Serialize<Person>(me, options);
        //output the json string to your file indicated in the path
        //use WriteAllText here because there is ONLY a SINGLE line of text
        //  unlike writing a csv file which has an array of strings (WriteAllLines)
        File.WriteAllText(pathname, jsonstring);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

Person ReadAsJson(string pathname)
{
    Person person = null;
    try
    {
        //bring in the text from the file
        string jsonstring = File.ReadAllText(pathname);
        //use the deserializer to unpack the json string into
        //  the expected structure <Person>
        person = JsonSerializer.Deserialize<Person>(jsonstring);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return person;
}