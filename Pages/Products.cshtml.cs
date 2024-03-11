using MaswadehEyadSprint4.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MaswadehEyadSprint4.Pages
{
    public class ProductsModel : PageModel
    {

        public string Message { get; set; }
        [BindProperty]
        [Display(Name = "Primary Flavour")]
        [Required(ErrorMessage = "Please chose a primary flavour.")]
        public int PrimaryFlavoursID { get; set; }
        [BindProperty]
        [Display(Name = "Nut free")]
        [Required(ErrorMessage = "Please chose if the ice cream is nut free or not.")]
        public int NutfreeID { get; set; }
        [BindProperty]
        [Display(Name = "Ice cream size")]
        [Required(ErrorMessage = "Please enter the ice cream size")]
        public int IcecreamSizeID { get; set; }
        public SelectList listofprimaryflavours { get; set; }
        public SelectList listoficecreamsizes { get; set; }
        public IList<Nutfree> listofnutfree { get; set; }




        //need a read only variable to be the same name as whatever you called your dbcontext class.
        private readonly MyApplicationDbContext _myApplicationDbContext;

        //the following code injects our database context into our page model 
        public ProductsModel(MyApplicationDbContext myApplicationDbContext)
        {
            _myApplicationDbContext = myApplicationDbContext;
        }

        public List<viewSimpleIcecream> allicecream = new List<viewSimpleIcecream>();

        //the onget or ongetasync method executes prior to the user seeing the page.
        public async Task<IActionResult> OnGetAsync()
        {
            //populating our primary flavours dropdown list
            listofprimaryflavours = new SelectList(_myApplicationDbContext.PrimaryFlavours, "PrimaryFlavoursID", "PrimaryFlavoursname");

            //populating the nutr free radio buttons
            listofnutfree = _myApplicationDbContext.Nutfree.ToList();

            //populating our icecream size dropdown list
            listoficecreamsizes = new SelectList(_myApplicationDbContext.IcecreamSize, "IcecreamSizeID", "IcecreamSizename", "price");

            //Populate the allicecream list that we created above.
            allicecream = await _myApplicationDbContext.viewSimpleIcecream.ToListAsync();


            return Page();
        }

        public IActionResult OnPostFilter()
        {
            //populating our primary flavours dropdown list
            listofprimaryflavours = new SelectList(_myApplicationDbContext.PrimaryFlavours, "PrimaryFlavoursID", "PrimaryFlavoursname");

            //populating the nutr free radio buttons
            listofnutfree = _myApplicationDbContext.Nutfree.ToList();

            //populating our icecream size dropdown list
            listoficecreamsizes = new SelectList(_myApplicationDbContext.IcecreamSize, "IcecreamSizeID", "IcecreamSizename", "price");

            bool primaryflavourselected = false;
            bool nutfreeselected = false;
            bool icecreamsizeselected = false;

            //check if the usesr selected a primary flavour, if so set bool to true
            if (PrimaryFlavoursID != 0)
            {
                //user selected a primary flavour from the list
                primaryflavourselected = true;
            }
            if (IcecreamSizeID != 0)
            {
                //user selected a ice cream size from the list
                icecreamsizeselected = true;
            }
            if (NutfreeID != 0)
            {
                //user selected a nut free option
                nutfreeselected = true;
            }
            ProcessFilter(primaryflavourselected, nutfreeselected, icecreamsizeselected);

            return Page();
        }

        public void ProcessFilter(bool parmPrimary, bool parmNut, bool parmSize)
        {
            //user selected primary flavours but no ice cream size or nut free
            if (parmPrimary && !parmNut && !parmSize)
            {
                allicecream = _myApplicationDbContext.viewSimpleIcecream.Where(x => x.PrimaryFlavoursID == PrimaryFlavoursID).ToList();
            }
            //user selected nut free but not a primary flavour or ice cream size
            if (!parmPrimary && parmNut && !parmSize)
            {
                allicecream = _myApplicationDbContext.viewSimpleIcecream.Where(x => x.NutfreeID == NutfreeID).ToList();
            }
            //user selected ice cream size but not primary flavour and nut free
            if (!parmPrimary && !parmNut && parmSize)
            {
                allicecream = _myApplicationDbContext.viewSimpleIcecream.Where(x => x.IcecreamSizeID == IcecreamSizeID).ToList();
            }
            //user selected a primary flavour and nut but not size
            if (parmPrimary && parmNut && !parmSize)
            {
                allicecream = _myApplicationDbContext.viewSimpleIcecream.Where(x => x.PrimaryFlavoursID == PrimaryFlavoursID && x.NutfreeID == NutfreeID).ToList();
            }
            //user selected a primary flavour and ice cream size but no nuts
            if (parmPrimary && !parmNut && parmSize)
            {
                allicecream = _myApplicationDbContext.viewSimpleIcecream.Where(x => x.PrimaryFlavoursID == PrimaryFlavoursID && x.IcecreamSizeID == IcecreamSizeID).ToList();
            }
            //user selected a nut free option and ice cream size but no primary flavour
            if (!parmPrimary && parmNut && parmSize)
            {
                allicecream = _myApplicationDbContext.viewSimpleIcecream.Where(x => x.NutfreeID == NutfreeID && x.IcecreamSizeID == IcecreamSizeID).ToList();
            }
            //user selected all 3 filters
            if (parmPrimary && parmNut && parmSize)
            {
                allicecream = _myApplicationDbContext.viewSimpleIcecream.Where(x => x.NutfreeID == NutfreeID && x.IcecreamSizeID == IcecreamSizeID && x.PrimaryFlavoursID == PrimaryFlavoursID).ToList();
            }
            //user selected nothing
            if (!parmPrimary && !parmNut && !parmSize)
            {
                allicecream = _myApplicationDbContext.viewSimpleIcecream.ToList();
            }

        }

        public void OnPostClear()
        {
            ModelState.Clear();
            PrimaryFlavoursID = 0;
            IcecreamSizeID = 0;
            NutfreeID = 0;

            //populating our primary flavours dropdown list
            listofprimaryflavours = new SelectList(_myApplicationDbContext.PrimaryFlavours, "PrimaryFlavoursID", "PrimaryFlavoursname");

            //populating the nutr free radio buttons
            listofnutfree = _myApplicationDbContext.Nutfree.ToList();

            //populating our icecream size dropdown list
            listoficecreamsizes = new SelectList(_myApplicationDbContext.IcecreamSize, "IcecreamSizeID", "IcecreamSizename", "price");

            ProcessFilter(false, false, false);
        }
    }
}
