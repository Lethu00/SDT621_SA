using Microsoft.VisualStudio.TestTools.UnitTesting;
using Section_C;

namespace Section_C.Tests;

[TestClass]
public sealed class MobilePhoneServiceTests
{
    [TestMethod]
    public void Add_InsertsNewRecordIntoTblMobilePhones_AndReportsAddedQuantity()
    {
        MobilePhoneTableRepository repository = new();
        MobilePhoneService service = new(repository);

        string message = service.Add("M001", "Samsung", "12");

        Assert.AreEqual("Added: Mobile Code: M001 | Make: Samsung | Quantity Added: 12 | New Quantity: 12", message);
        Assert.AreEqual("tblMobilePhones", repository.Table.TableName);
        Assert.AreEqual(1, repository.Table.Rows.Count);
        Assert.AreEqual("M001", repository.Table.Rows[0]["MobileCode"]);
        Assert.AreEqual("Samsung", repository.Table.Rows[0]["Make"]);
        Assert.AreEqual(12, repository.Table.Rows[0]["Quantity"]);
    }

    [TestMethod]
    public void Add_WhenMobileCodeAlreadyExists_IncreasesQuantityAndReportsNewTotal()
    {
        MobilePhoneTableRepository repository = new();
        MobilePhoneService service = new(repository);
        service.Add("M001", "Samsung", "12");

        string message = service.Add("M001", "Samsung", "8");

        Assert.AreEqual("Added: Mobile Code: M001 | Make: Samsung | Quantity Added: 8 | New Quantity: 20", message);
        Assert.AreEqual(1, repository.Table.Rows.Count);
        Assert.AreEqual(20, repository.Table.Rows[0]["Quantity"]);
    }

    [TestMethod]
    public void Find_WhenMobileCodeExists_ReturnsMakeAndQuantity()
    {
        MobilePhoneService service = new(new MobilePhoneTableRepository());
        service.Add("M003", "Nokia", "3");

        string message = service.Find("M003");

        Assert.AreEqual("Found: Make: Nokia | Quantity: 3", message);
    }

    [TestMethod]
    public void Delete_WhenQuantityIsLessThanStock_SubtractsQuantityAndReportsRemainingStock()
    {
        MobilePhoneTableRepository repository = new();
        MobilePhoneService service = new(repository);
        service.Add("M002", "Apple", "5");

        string message = service.Delete("M002", "2");

        Assert.AreEqual("Deleted: Mobile Code: M002 | Make: Apple | Quantity Deleted: 2 | Remaining Quantity: 3", message);
        Assert.AreEqual(1, repository.Table.Rows.Count);
        Assert.AreEqual(3, repository.Table.Rows[0]["Quantity"]);
    }

    [TestMethod]
    public void Delete_WhenQuantityIsAllRemainingStock_RemovesRecord()
    {
        MobilePhoneTableRepository repository = new();
        MobilePhoneService service = new(repository);
        service.Add("M002", "Apple", "5");

        string message = service.Delete("M002", "5");

        Assert.AreEqual("Deleted: Mobile Code: M002 | Make: Apple | Quantity Deleted: 5 | Remaining Quantity: 0", message);
        Assert.AreEqual(0, repository.Table.Rows.Count);
    }

    [TestMethod]
    public void Delete_WhenMobileCodeDoesNotExist_ReturnsRecordNotFound()
    {
        MobilePhoneService service = new(new MobilePhoneTableRepository());

        string message = service.Delete("UNKNOWN", "1");

        Assert.AreEqual(MobilePhoneService.RecordNotFound, message);
    }
}
