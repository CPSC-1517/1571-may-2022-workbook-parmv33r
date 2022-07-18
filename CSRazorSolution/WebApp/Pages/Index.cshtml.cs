﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WestWindSystem.BLL;
using WestWindSystem.Entities;

namespace WebApp.Pages;

//this web page Model class inherits from PageModel
    public class IndexModel : PageModel
    {
        //this default page uses a system class called ILogger<T>
        //this is composition
        //this is a local field
        private readonly ILogger<IndexModel> _logger;
        private readonly BuildVersionServices _buildversionServices;

    //constructor
    //this constructor receive an injection of a service
    //this injection is referred to as Injection Dependency
    //the second parameter in the list is the injection dependency  to be able
    //  to use the BuildVersionServices we build in our class library
    public IndexModel(ILogger<IndexModel> logger, BuildVersionServices bvservices)
        {
            _logger = logger;
            _buildversionServices = bvservices;
        }

        [BindProperty]
        public BuildVersion buildVersionInfo { get; set; }
        //this is a local property
        public string MyName { get; set; }

        //this is a class Behaviour (method)
        //this method, OnGet(), executes for any Get request
        //this method will be the first method executed when the page is first
        //  used.
        //excellent "event" to use to do any initialization to your web page display

        public void OnGet()
        {
            //once in the request method, you are in control of what is being
            //  processed on the web page for the current request

            Random rnd = new Random();
            int value = rnd.Next(0, 100); //100 is NOT include
            if (value % 2 == 0)
            {
                MyName = $"Don ({value}) welcome to the wide wild world of Razor Pages";
            }
            else
            {
                MyName = null;
            }

            //make my firs call to the database using the services within
            // BuildVersionServices of the class library
            buildVersionInfo = _buildversionServices.GetBuildVersion();
            //control is returned to the web server
        }
    }

