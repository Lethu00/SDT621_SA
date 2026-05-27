using System.Data;

namespace Section_C;

public sealed class MobilePhoneTableRepository : IMobilePhoneRepository
{
    private readonly DataTable tblMobilePhones;

    public MobilePhoneTableRepository()
    {
        tblMobilePhones = CreateMobilePhonesTable();
    }

    public DataTable Table => tblMobilePhones;

    public void Add(MobilePhone mobilePhone)
    {
        tblMobilePhones.Rows.Add(mobilePhone.MobileCode, mobilePhone.Make, mobilePhone.Quantity);
    }

    public void Update(MobilePhone mobilePhone)
    {
        DataRow? row = tblMobilePhones.Rows.Find(mobilePhone.MobileCode);

        if (row is null)
        {
            Add(mobilePhone);
            return;
        }

        row["Make"] = mobilePhone.Make;
        row["Quantity"] = mobilePhone.Quantity;
    }

    public bool Delete(string mobileCode)
    {
        DataRow? row = tblMobilePhones.Rows.Find(mobileCode);

        if (row is null)
        {
            return false;
        }

        tblMobilePhones.Rows.Remove(row);
        return true;
    }

    public MobilePhone? Find(string mobileCode)
    {
        DataRow? row = tblMobilePhones.Rows.Find(mobileCode);

        if (row is null)
        {
            return null;
        }

        return new MobilePhone(
            (string)row["MobileCode"],
            (string)row["Make"],
            (int)row["Quantity"]);
    }

    private static DataTable CreateMobilePhonesTable()
    {
        DataTable table = new("tblMobilePhones");
        DataColumn mobileCodeColumn = table.Columns.Add("MobileCode", typeof(string));
        table.Columns.Add("Make", typeof(string));
        table.Columns.Add("Quantity", typeof(int));
        table.PrimaryKey = [mobileCodeColumn];

        return table;
    }
}
