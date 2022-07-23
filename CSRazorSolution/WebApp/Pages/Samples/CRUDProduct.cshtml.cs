﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

#region Additional Namespaces
using WestWindSystem.BLL;       //this is where the services were coded
using WestWindSystem.Entities;  //this is where the entity definition is coded
using WebApp.Helpers;
#endregion


namespace WebApp.Pages.Samples
{
    public class CRUDProductModel : PageModel
    {
        #region Private service fields & class constructor
        private readonly CategoryServices _categoryServices;
        private readonly ProductServices _productServices;
        private readonly SupplierServices _supplierServices;


        public CRUDProductModel(CategoryServices categoryservices,
                                        ProductServices productservices,
                                        SupplierServices supplierServices)
        {
            _categoryServices = categoryservices;
            _productServices = productservices;
            _supplierServices = supplierServices;
        }
        #endregion


        [TempData]
        public string Feedback { get; set; }

        public bool HasFeedback
        {
            get
            {
                return !string.IsNullOrWhiteSpace(Feedback);
            }

        }

        [TempData]
        public string ErrorMsg { get; set; }

        public bool HasError
        {
            get
            {
                return !string.IsNullOrWhiteSpace(ErrorMsg);
            }

        }

        [BindProperty(SupportsGet = true)]
        public int? productid { get; set; }

        [BindProperty]
        public Product ProductInfo { get; set; }

        public List<Supplier> SupplierList { get; set; }

        public List<Category> CategoryList { get; set; }

        public void OnGet()
        {
            PopulateSupportLists();
            //onget executes the first time the page is generated
            //onget executes in response to a requested issues when using the
            //      redirecttopage()
            //test if the routing parameter has
            // a) a value
            // b) the value is valid (>0), pkey value

            //if a product was select on a the Query page, then its pkey value
            // will have been passed to this CRUD page
            // if a pkey value exists then lookup the current data off the
            // databse for the pkey value

            if (productid.HasValue)
            {
                if(productid.Value > 0)
                {
                    ProductInfo = _productServices.Product_GetById(productid.Value);
                }
            }
        }

        public void PopulateSupportLists()
        {
            SupplierList = _supplierServices.Supplier_List();
            CategoryList = _categoryServices.Category_List();
        }


        public IActionResult OnPostClear()
        {
            Feedback = "User clear";
            ErrorMsg = "";
            productid = (int?)null;
            ModelState.Clear();
            return RedirectToPage(new { productid = productid });
        }

        public IActionResult OnPostSearch()
        {
            return RedirectToPage("/Samples/CategoryProducts");
        }

        
    }
}