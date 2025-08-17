using System;

[Serializable]
public class ElectricityBill
{
    private string consumerNumber;
    private string consumerName;
    private int unitsConsumed;
    private double billAmount;

    public string ConsumerNumber
    {
        get => consumerNumber;
        set
        {
            if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^EB\d{5}$"))
                throw new FormatException("Consumer Number must start with EB followed by 5 digits.");
            consumerNumber = value;
        }
    }

    public string ConsumerName
    {
        get => consumerName;
        set => consumerName = value;
    }

    public int UnitsConsumed
    {
        get => unitsConsumed;
        set
        {
            if (value < 0)
                throw new ArgumentException("Units must be ≥ 0");
            unitsConsumed = value;
        }
    }

    public double BillAmount
    {
        get => billAmount;
        set => billAmount = value;
    }
}

