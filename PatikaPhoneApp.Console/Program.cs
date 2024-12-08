using PatikaPhoneApp.Console;

string choose;
bool isEnd = false;

while (!isEnd)
{
    Console.WriteLine("1. Telefon Numarası Kaydet");
    Console.WriteLine("2. Telefon Numarası Sil");
    Console.WriteLine("3. Telefon Numarası Güncelle");
    Console.WriteLine("4. Rehber Listeleme");
    Console.WriteLine("5. Rehberde Arama");

    Console.WriteLine("Tercih yapınız: ");
    choose = Console.ReadLine()!;
    Console.WriteLine();

    switch (choose)
    {
        case "1":
            SaveNumber();
            break;
        case "2":
            DeleteNumber();
            break;
        case "3":
            UpdateNumber();
            break;
        case "4":
            GetAllUsers();
            break;
        case "5":
            SearchUser();
            break;
        default:
            break;
    }

    isEnd = IsEnd();
}

void SaveNumber()
{
    var user = new User();

    Console.Write("İsim giriniz: ");
    user.FirstName = Console.ReadLine()!;
    Console.WriteLine();

    Console.Write("Soyisim giriniz: ");
    user.LastName = Console.ReadLine()!;
    Console.WriteLine();

    Console.Write("Telefon numarasını giriniz: ");
    user.PhoneNumber = Console.ReadLine()!;
    Console.WriteLine();

    StaticData.Users.Add(user);

    Console.WriteLine("Başarıyla kaydedildi.");
}

void DeleteNumber()
{
    string answer;

DeleteUser:
    Console.Write("Lütfen numarasını silmek istediğiniz kişinin adını ya da soyadını giriniz: ");
    var searchText = Console.ReadLine()!;
    Console.WriteLine();

    var user = StaticData.Users.Where(u => u.FullName.Contains(searchText)).FirstOrDefault();

    if (user != null)
    {
        Console.Write($"{user.FullName} isimli kişi rehberden silinmek üzere, onaylıyor musunuz ?(y/n): ");
        answer = Console.ReadLine()!;

        if (answer == "y")
        {
            StaticData.Users.Remove(user);
            Console.WriteLine("Başarıyla silindi.");
        }
        else
        {
            return;
        }
    }
    else
    {
        Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
        Console.WriteLine("Silmeyi sonlandırmak için : (1)");
        Console.WriteLine("Yeniden denemek için      : (2)");
        Console.Write("Seçiminiz: ");
        answer = Console.ReadLine()!;
        Console.WriteLine();

        if (answer == "1")
            return;
        if (answer == "2")
            goto DeleteUser;
    }
}

void UpdateNumber()
{
    string phoneNumber, answer;

UpdateUser:
    Console.Write("Lütfen numarasını güncellemek istediğiniz kişinin adını ya da soyadını giriniz: ");
    var searchText = Console.ReadLine()!;
    Console.WriteLine();

    var user = StaticData.Users.Where(u => u.FullName.Contains(searchText)).FirstOrDefault();

    if (user != null)
    {
        Console.Write($"Yeni telefon numarasını giriniz: ");
        phoneNumber = Console.ReadLine()!;
        Console.WriteLine();

        user.PhoneNumber = phoneNumber;

        Console.WriteLine("Numara başarıyla güncellendi.");
    }
    else
    {
        Console.WriteLine(" Aradığınız krtiterlere uygun veri rehberde bulunamadı. Lütfen bir seçim yapınız.");
        Console.WriteLine("Güncellemeyi sonlandırmak için : (1)");
        Console.WriteLine("Yeniden denemek için      : (2)");
        Console.Write("Seçiminiz: ");
        answer = Console.ReadLine()!;
        Console.WriteLine();

        if (answer == "1")
            return;
        if (answer == "2")
            goto UpdateUser;
    }
}

void GetAllUsers()
{
    Console.WriteLine("Telefon Rehberi");
    Console.WriteLine(" **********************************************");

    StaticData.Users.ForEach(u => Console.WriteLine($"isim: {u.FirstName} Soyisim: {u.LastName} Telefon Numarası: {u.PhoneNumber}"));
}

void SearchUser()
{
    Console.WriteLine("Lütfen arama yapmak istediğiniz kişinin isminş ya da numarasını giriniz: ");
    var searchText = Console.ReadLine()!;
    Console.WriteLine();

    var users = StaticData.Users.Where(u => u.FullName.Contains(searchText)).ToList();

    if (users != null)
    {
        Console.WriteLine("Arama Sonuçlarınız:");
        Console.WriteLine("**********************************************");
        users.ForEach(u => Console.WriteLine($"isim: {u.FirstName} Soyisim: {u.LastName} Telefon Numarası: {u.PhoneNumber}"));
    }
    else
    {
        Console.WriteLine("Arama Sonuçlarınız:");
        Console.WriteLine("**********************************************");
        Console.WriteLine("Sonuç bulunamadı");
    }
}

bool IsEnd()
{
    string answer;

    Console.WriteLine("Başka bir işlem yapmak ister misiniz? (e/h): ");
    answer= Console.ReadLine()!;

    if (answer == "e")
        return false;
    else
        return true;
}