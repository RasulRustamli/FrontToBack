using FrontToBack.DAL;
using FrontToBack.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontToBack.Controllers
{
    public class StateController : Controller
    {

        private readonly Context _context;
    public StateController(Context context)
    {
        _context = context;
    }
    public ActionResult Index()
    {

        ViewBag.CountryList = new SelectList(GetCountryList(), "CountryId", "CountryName");

        return View();
    }


    public List<Country> GetCountryList()
    { 
        List<Country> countries = _context.Countries.ToList();

        return countries;


    }

    public ActionResult GetStateList(int CountryId)
    {
        

        List<State> stateList = _context.States.Include(c=>c.Country).Where(x => x.CountryId == CountryId).ToList();

        ViewBag.StateOptions = new SelectList(stateList, "StateId", "StateName");

        return PartialView("StateOptionPartial");

    }

}
}
