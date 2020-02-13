﻿using Glass.Mapper.Sc.Web.Mvc;
using Ignium.Foundation.GoogleTagManager.Services;
using Sitecore.Analytics;
using Sitecore.Services.Infrastructure.Web.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ignium.Foundation.GoogleTagManager.Controllers
{
    public class OutcomeController : Controller
    {
        private readonly ITrackerService _trackerService;
        private readonly IMvcContext _mvcContext;
        public OutcomeController(ITrackerService trackerService, IMvcContext mvcContext)
        {
            _trackerService = trackerService;
            _mvcContext = mvcContext;
        }

        [HttpGet]
        [Route("api/googletagmanager/outcomes/track")]
        public async Task<ActionResult> TrackPageOutcome(Guid outcomeDefinitionId, decimal amount, string currencyCode = "USD")
        {
            bool result = await _trackerService.TrackCurrentPageOutcome(Tracker.Current, _mvcContext, outcomeDefinitionId, currencyCode, amount);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("api/googletagmanager/outcomes/pages/track")]
        public async Task<ActionResult> TrackOutcome(Guid outcomeDefinitionId, decimal amount, string currencyCode = "USD")
        {
            bool result = await _trackerService.TrackCurrentOutcome(Tracker.Current, _mvcContext, outcomeDefinitionId, currencyCode, amount);

            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}