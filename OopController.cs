// FILE: Controllers/OopController.cs
namespace SOFT121.Controllers // << NEW: Wrap the controller in the project namespace
{
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System;
    using Microsoft.AspNetCore.Http;
    using SOFT121.Models; // << NEW: Reference the Models namespace

    [ApiController]
    [Route("api/[controller]")] 
    public class OopController : ControllerBase
    {
        // ... (rest of the controller methods and logic remains the same) ...

        [HttpGet("concepts")]
        public ActionResult<IEnumerable<OopConcept>> GetConcepts()
        {
            // ... (method body remains the same) ...
            var concepts = new List<OopConcept>
            {
                new OopConcept("Class", "A blueprint for creating objects.", "Structure"),
                // ... etc.
            };
            return Ok(concepts);
        }

        // ... (SafeDivide method remains the same) ...
    }
}
