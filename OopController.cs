// FILE: Controllers/OopController.cs
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Http;

[ApiController]
[Route("api/[controller]")] // Route will be /api/oop
public class OopController : ControllerBase
{
    // --- API Documentation & OOP Implementation Endpoint ---
    [HttpGet("concepts")]
    public ActionResult<IEnumerable<OopConcept>> GetConcepts()
    {
        // Create Instances (Objects) of the defined Classes
        var concepts = new List<OopConcept>
        {
            new OopConcept("Class", "A blueprint for creating objects.", "Structure"),
            new OopConcept("Instance", "A specific object created from a class.", "Concrete Data"),
            new OopConcept("Encapsulation", "Bundling data and methods into a single unit.", "Data Hiding"),
            new InheritanceConcept() // Uses the specialized subclass
        };
        
        return Ok(concepts);
    }

    // --- Error Handling Endpoint ---
    // [HttpGet("divide?num={num}&denom={denom}")]
    [HttpGet("divide")]
    public ActionResult<object> SafeDivide([FromQuery] string num, [FromQuery] string denom)
    {
        try
        {
            // Write code to catch and handle errors and exceptions
            if (!double.TryParse(num, out double numerator) || 
                !double.TryParse(denom, out double denominator))
            {
                // Throw custom exception
                throw new InvalidInputException("Input must be valid numerical strings.");
            }

            double result = numerator / denominator;
            
            return Ok(new { numerator = num, denominator = denom, result = result, status="Success" });
        }
        catch (InvalidInputException ex)
        {
            Console.WriteLine($"[C# Error Handler] Custom Input Error: {ex.Message}");
            return BadRequest(new { error = "Invalid Input", message = ex.Message });
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("[C# Error Handler] Zero Division Attempted.");
            return BadRequest(new { error = "Division Error", message = "Cannot divide by zero." });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[C# Error Handler] Unexpected Error: {ex.Message}");
            return StatusCode(StatusCodes.Status500InternalServerError, new { error = "Server Error", message = ex.Message });
        }
    }
}
