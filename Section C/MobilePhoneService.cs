namespace Section_C;

public sealed class MobilePhoneService
{
    public const string RecordNotFound = "Record NOT Found";
    public const string MissingFields = "Please fill in all fields.";
    public const string MissingCodeOrQuantity = "Please enter a mobile code and quantity.";
    public const string InvalidQuantity = "Quantity must be a number.";
    public const string QuantityMustBePositive = "Quantity must be greater than zero.";

    private readonly IMobilePhoneRepository repository;

    public MobilePhoneService(IMobilePhoneRepository repository)
    {
        this.repository = repository;
    }

    public string Add(string mobileCode, string make, string quantityText)
    {
        mobileCode = mobileCode.Trim();
        make = make.Trim();

        if (string.IsNullOrWhiteSpace(mobileCode)
            || string.IsNullOrWhiteSpace(make)
            || string.IsNullOrWhiteSpace(quantityText.Trim()))
        {
            return MissingFields;
        }

        if (!TryGetPositiveQuantity(quantityText, out int quantity, out string errorMessage))
        {
            return errorMessage;
        }

        MobilePhone? existingPhone = repository.Find(mobileCode);
        int newQuantity = quantity;

        if (existingPhone is null)
        {
            repository.Add(new MobilePhone(mobileCode, make, quantity));
        }
        else
        {
            newQuantity = existingPhone.Quantity + quantity;
            repository.Update(new MobilePhone(mobileCode, make, newQuantity));
        }

        return $"Added: Mobile Code: {mobileCode} | Make: {make} | Quantity Added: {quantity} | New Quantity: {newQuantity}";
    }

    public string Delete(string mobileCode, string quantityText)
    {
        mobileCode = mobileCode.Trim();

        if (string.IsNullOrWhiteSpace(mobileCode) || string.IsNullOrWhiteSpace(quantityText.Trim()))
        {
            return MissingCodeOrQuantity;
        }

        if (!TryGetPositiveQuantity(quantityText, out int quantityToDelete, out string errorMessage))
        {
            return errorMessage;
        }

        MobilePhone? existingPhone = repository.Find(mobileCode);

        if (existingPhone is null)
        {
            return RecordNotFound;
        }

        if (quantityToDelete >= existingPhone.Quantity)
        {
            repository.Delete(mobileCode);
            return $"Deleted: Mobile Code: {mobileCode} | Make: {existingPhone.Make} | Quantity Deleted: {existingPhone.Quantity} | Remaining Quantity: 0";
        }

        int remainingQuantity = existingPhone.Quantity - quantityToDelete;
        repository.Update(new MobilePhone(mobileCode, existingPhone.Make, remainingQuantity));

        return $"Deleted: Mobile Code: {mobileCode} | Make: {existingPhone.Make} | Quantity Deleted: {quantityToDelete} | Remaining Quantity: {remainingQuantity}";
    }

    public string Find(string mobileCode)
    {
        mobileCode = mobileCode.Trim();

        if (string.IsNullOrWhiteSpace(mobileCode))
        {
            return RecordNotFound;
        }

        MobilePhone? mobilePhone = repository.Find(mobileCode);

        return mobilePhone is null
            ? RecordNotFound
            : $"Found: Make: {mobilePhone.Make} | Quantity: {mobilePhone.Quantity}";
    }

    private static bool TryGetPositiveQuantity(string quantityText, out int quantity, out string errorMessage)
    {
        if (!int.TryParse(quantityText.Trim(), out quantity))
        {
            errorMessage = InvalidQuantity;
            return false;
        }

        if (quantity <= 0)
        {
            errorMessage = QuantityMustBePositive;
            return false;
        }

        errorMessage = string.Empty;
        return true;
    }
}
