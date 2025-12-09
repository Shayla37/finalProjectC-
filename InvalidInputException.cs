// FILE: Models/InvalidInputException.cs
using System;

// Custom Exception demonstrating specialized error types
public class InvalidInputException : Exception
{
    public InvalidInputException(string message) : base(message) { }
}
