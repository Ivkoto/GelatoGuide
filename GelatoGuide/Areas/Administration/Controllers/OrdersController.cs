using AutoMapper;
using GelatoGuide.Areas.Administration.Models.Orders;
using Microsoft.AspNetCore.Mvc;

namespace GelatoGuide.Areas.Administration.Controllers;

public class OrdersController : AdminController
{
    private readonly IMapper mapper;

    public OrdersController(IMapper mapper)
    {
        this.mapper = mapper;
    }


    public ActionResult All()
        => View();


    //public ActionResult Details(int id)
    //{
    //    return View();
    //}


    public IActionResult Create()
        => View();


    [HttpPost]
    public IActionResult Create(CreateOrderFormModel order)
    {
        if (!ModelState.IsValid)
        {
            return View(order);
        }

        return RedirectToAction("All", "Orders");
    }
}