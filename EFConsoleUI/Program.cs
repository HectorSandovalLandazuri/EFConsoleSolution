// See https://aka.ms/new-console-template for more information


using EFConsoleUI.DataAccess;
using EFConsoleUI.Models;
using Microsoft.EntityFrameworkCore;

//CreateHector();

//UpdateFirstName(1, "Manuel");
//RemovePhoneNumber(1, "555-1212");
RemoveUser(1);
//ReadById(1);
ReadAll();
Console.WriteLine("Done Processing");


static void CreateHector()
{
    var c = new Contact
    {
        FirstName = "Claudia",
        LastName = "Alvarado"
    };
    c.EmailAddresses.Add(new Email {EmailAddress= "claudia@claudia.com" });
    c.EmailAddresses.Add(new Email { EmailAddress = "claudia@hola.com" });
    c.PhoneNumbers.Add(new Phone { PhoneNumber = "111-1212" });
    c.PhoneNumbers.Add(new Phone { PhoneNumber = "112-1212" });
    using  (var db=new ContactContext())
    {
        db.Contacts.Add(c);
        db.SaveChanges();
    }
}

static void ReadAll()
{
    using (var db=new ContactContext())
    {
        var records=db.Contacts
//            .Include(e => e.EmailAddresses)
//            .Include(p => p.PhoneNumbers)
            .ToList();
        foreach (var c in records)
        {
            Console.WriteLine($"{c.FirstName} { c.LastName}");
        }
    }
}

static void ReadById(int id)
{
    using (var db = new ContactContext())
    {
        var user = db.Contacts.Where(c=>c.Id==id).First();
        Console.WriteLine($"{user.FirstName} {user.LastName}");
    }

}

static void UpdateFirstName(int id,string firstName)
{
    using (var db = new ContactContext())
    {
        var user = db.Contacts.Where(c => c.Id == id).First();
        user.FirstName = firstName;
        db.SaveChanges();
    }
}

static void RemovePhoneNumber(int id,string phoneNumber)
{
    using (var db = new ContactContext())
    {
        var user = db.Contacts
            .Include(p => p.PhoneNumbers)
            .Where(c => c.Id == id)
            .First();
        user.PhoneNumbers.RemoveAll(p=> p.PhoneNumber == phoneNumber);
        db.SaveChanges();
    }
}

static void RemoveUser(int id)
{
    using (var db = new ContactContext())
    {
        var user = db.Contacts
            .Include(e=>e.EmailAddresses)
            .Include(p => p.PhoneNumbers)
            .Where(c => c.Id == id)
            .First();
        db.Contacts.Remove(user);
        db.SaveChanges();
    }
}