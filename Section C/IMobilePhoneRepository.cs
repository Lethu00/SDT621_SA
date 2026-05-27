namespace Section_C;

public interface IMobilePhoneRepository
{
    void Add(MobilePhone mobilePhone);

    void Update(MobilePhone mobilePhone);

    bool Delete(string mobileCode);

    MobilePhone? Find(string mobileCode);
}
