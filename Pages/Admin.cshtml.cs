using MaswadehEyadSprint4.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace MaswadehEyadSprint4.Pages
{
    public class AdminModel : PageModel
    {
        [BindProperty]
        [Display(Name = "Ice cream name")]
        [Required(ErrorMessage = "Please enter the ice cream name.")]
        public string Icecreamname { get; set; } = string.Empty;
        [BindProperty]
        [Display(Name = "Primary Flavour")]
        [Required(ErrorMessage = "Please chose a primary flavour.")]
        public int PrimaryFlavoursID { get; set; }
        [BindProperty]
        [Display(Name = "Nut free")]
        [Required(ErrorMessage = "Please chose if the ice cream is nut free or not.")]
        public int NutfreeID { get; set; }
        [BindProperty]
        [Display(Name = "Specials")]
        [Required(ErrorMessage = "Please enter the Special day")]
        public int SpecialsID { get; set; }
        [BindProperty]
        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter the description.")]
        public string Descriptions { get; set; }
        [BindProperty]
        [Display(Name = "Image path")]
        [Required(ErrorMessage = "Please enter the image path.")]
        public string Imagepath { get; set; }
        [BindProperty]
        [Display(Name = "Ice cream size")]
        [Required(ErrorMessage = "Please enter the ice cream size")]
        public int IcecreamSizeID { get; set; }
        public SelectList listofprimaryflavours { get; set; }
        public SelectList listofNuts { get; set; }
        public SelectList listofIcecreamsize { get; set; }
        public SelectList listofIspecials { get; set; }


        [BindProperty]
        public SimpleIcecream MySimpleIcecream { get; set; }

        public string Message { get; set; } = string.Empty;

        private readonly MyApplicationDbContext _myApplicationDbContext;

        public AdminModel(MyApplicationDbContext myApplicationDbContext)
        {
            _myApplicationDbContext = myApplicationDbContext;
        }

        public IActionResult OnGet()
        {
            listofprimaryflavours = new SelectList(_myApplicationDbContext.PrimaryFlavours, "PrimaryFlavoursID", "PrimaryFlavoursname");
            listofNuts = new SelectList(_myApplicationDbContext.Nutfree, "NutfreeID", "Nutfreename");
            listofIcecreamsize = new SelectList(_myApplicationDbContext.IcecreamSize, "IcecreamSizeID", "IcecreamSizename", "price");
            listofIspecials = new SelectList(_myApplicationDbContext.Specials, "SpecialsID", "SpecialDay");
            return Page();
        }

       
      
        public async Task<IActionResult> OnPostAdd() 
        {

            //All the required fields have been entered
            

            //check we have a icecream id

            if (PrimaryFlavoursID == 0)
            {
                //user did not select a primary flavour
                Message = "Please select a primary flavour.";

                listofprimaryflavours = new SelectList(_myApplicationDbContext.PrimaryFlavours, "PrimaryFlavoursID", "PrimaryFlavoursname");
                listofNuts = new SelectList(_myApplicationDbContext.Nutfree, "NutfreeID", "Nutfreename");
                listofIcecreamsize = new SelectList(_myApplicationDbContext.IcecreamSize, "IcecreamSizeID", "IcecreamSizename", "price");
                listofIspecials = new SelectList(_myApplicationDbContext.Specials, "SpecialsID", "SpecialDay");

                return Page();
            }

            if (NutfreeID == 0)
            {
                //user did not select if the ice cream was nut free or not
                Message = "Please select if the ice cream is nut free or not";

                listofprimaryflavours = new SelectList(_myApplicationDbContext.PrimaryFlavours, "PrimaryFlavoursID", "PrimaryFlavoursname");
                listofNuts = new SelectList(_myApplicationDbContext.Nutfree, "NutfreeID", "Nutfreename");
                listofIcecreamsize = new SelectList(_myApplicationDbContext.IcecreamSize, "IcecreamSizeID", "IcecreamSizename", "price");
                listofIspecials = new SelectList(_myApplicationDbContext.Specials, "SpecialsID", "SpecialDay");

                return Page();
            }

            if (IcecreamSizeID == 0)
            {
                //user did not select a Ice cream size
                Message = "Please select a Size.";

                listofprimaryflavours = new SelectList(_myApplicationDbContext.PrimaryFlavours, "PrimaryFlavoursID", "PrimaryFlavoursname");
                listofNuts = new SelectList(_myApplicationDbContext.Nutfree, "NutfreeID", "Nutfreename");
                listofIcecreamsize = new SelectList(_myApplicationDbContext.IcecreamSize, "IcecreamSizeID", "IcecreamSizename", "price");
                listofIspecials = new SelectList(_myApplicationDbContext.Specials, "SpecialsID", "SpecialDay");

                return Page();
            }

            if (SpecialsID == 0)
            {
                //user did not select a special id
                Message = "Please select a Special day.";

                listofprimaryflavours = new SelectList(_myApplicationDbContext.PrimaryFlavours, "PrimaryFlavoursID", "PrimaryFlavoursname");
                listofNuts = new SelectList(_myApplicationDbContext.Nutfree, "NutfreeID", "Nutfreename");
                listofIcecreamsize = new SelectList(_myApplicationDbContext.IcecreamSize, "IcecreamSizeID", "IcecreamSizename", "price");
                listofIspecials = new SelectList(_myApplicationDbContext.Specials, "SpecialsID", "SpecialDay");

                return Page();
            }

            _myApplicationDbContext.SimpleIcecream.Add(MySimpleIcecream);

            await _myApplicationDbContext.SaveChangesAsync();

            listofprimaryflavours = new SelectList(_myApplicationDbContext.PrimaryFlavours, "PrimaryFlavoursID", "PrimaryFlavoursname");
            listofNuts = new SelectList(_myApplicationDbContext.Nutfree, "NutfreeID", "Nutfreename");
            listofIcecreamsize = new SelectList(_myApplicationDbContext.IcecreamSize, "IcecreamSizeID", "IcecreamSizename", "price");
            listofIspecials = new SelectList(_myApplicationDbContext.Specials, "SpecialsID", "SpecialDay");

            ModelState.Clear();
            Icecreamname = string.Empty;
            Descriptions = string.Empty;
            Imagepath = string.Empty;
            PrimaryFlavoursID = 0;
            NutfreeID = 0;
            IcecreamSizeID = 0;
            SpecialsID = 0;

            return Page();
        }

 public IActionResult OnPostClear()
        {
            ModelState.Clear();
            Icecreamname = string.Empty;
            Descriptions = string.Empty;
            Imagepath = string.Empty;
            PrimaryFlavoursID = 0;
            NutfreeID = 0;
            IcecreamSizeID = 0;
            SpecialsID = 0;
           

            listofprimaryflavours = new SelectList(_myApplicationDbContext.PrimaryFlavours, "PrimaryFlavoursID", "PrimaryFlavoursname");
            listofNuts = new SelectList(_myApplicationDbContext.Nutfree, "NutfreeID", "Nutfreename");
            listofIcecreamsize = new SelectList(_myApplicationDbContext.IcecreamSize, "IcecreamSizeID", "IcecreamSizename", "price");
            listofIspecials = new SelectList(_myApplicationDbContext.Specials, "SpecialsID", "SpecialDay");

            return Page();
        }
    }
}
