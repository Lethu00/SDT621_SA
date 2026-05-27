namespace Section_C;

public sealed class MobilePhone
{
    public MobilePhone(string mobileCode, string make, int quantity)
    {
        MobileCode = mobileCode;
        Make = make;
        Quantity = quantity;
    }

    public string MobileCode { get; }

    public string Make { get; }

    public int Quantity { get; }
}
