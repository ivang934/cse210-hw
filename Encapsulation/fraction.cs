using System;

public class Fraction
{
    private int _top;
    private int _bottom;

    public Fraction()
    {
        _top = 1;
        _bottom = 1;
    }
    
    public Fraction(int wholeNumber)
    {
        _top = wholeNumber;
        _bottom = 1;
    }

    // Constructor 3: Two parameters for the numerator and denominator.
    public Fraction(int top, int bottom)
    {
        _top = top;
        _bottom = bottom;
    }


    public int GetTop()
    {
        return _top;
    }

    // Setter for the top number.
    public void SetTop(int top)
    {
        _top = top;
    }

    public int GetBottom()
    {
        return _bottom;
    }

    public void SetBottom(int bottom)
    {
        // You could add validation here, e.g., to prevent setting the denominator to zero.
        if (bottom != 0)
        {
            _bottom = bottom;
        }
        else
        {
            Console.WriteLine("Denominator cannot be zero.");
        }
    }

    // Method to return the fraction as a string
    public string GetFractionString()
    {
        string text = $"{_top}/{_bottom}";
        return text;
    }

    public double GetDecimalValue()
    {
        // We must cast one of the integers to a double to ensure floating-point division.
        return (double)_top / _bottom;
    }
}
