// FILE: Models/InheritanceConcept.cs
// Derived Class demonstrating Inheritance and Polymorphism
public class InheritanceConcept : OopConcept
{
    public InheritanceConcept() : base(
        "Inheritance", 
        "A mechanism where one class acquires the properties and methods of another class.", 
        "Reusability"
    ) { }

    // Polymorphism / Method Overriding
    public new string Summarize()
    {
        string baseSummary = base.Summarize();
        return $"{baseSummary}. It promotes code reuse and hierarchical relationships.";
    }
}
