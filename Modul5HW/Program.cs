
using System;
using System.Security.Cryptography.X509Certificates;

static (string name, string lname, int age, string[] nicknamePets, string[] favColors) GetUserData()
{
    (string name, string lname, int age, string[] nicknamePets, string[] favColors) user;
    user.nicknamePets = new string[0];
    Console.Write("Введите ваше имя: ");
    user.name = Console.ReadLine();

    Console.Write("Введите вашу фамилию: ");
    user.lname = Console.ReadLine();
    string agestr;
    do 
    {
        Console.Write("Введите сколько вам лет?: ");
        agestr = Console.ReadLine();

    } while (!IsCorrectInput(agestr,out user.age));
    

    Console.Write("Есть ли у вас питомец? (y/n): ");
    bool havePet = Console.ReadLine() == "y";
    string numberPetstr;
    int numberPet;
    if (havePet)
    {
        do
        {
            Console.Write("Напишите количество питомцев ");
            numberPetstr = Console.ReadLine();

        } while (!IsCorrectInput(numberPetstr, out numberPet));
        
        user.nicknamePets = SetNicknamePets(numberPet);
    }

    string numberFavColorsstr;
    int numberFavColors;
    do
    {
        Console.Write("Напишите количество любимых цветов: ");
        numberFavColorsstr = Console.ReadLine();

    } while (!IsCorrectInput(numberFavColorsstr, out numberFavColors));
    

    user.favColors = SetFavColors(numberFavColors);

    return user;
}

static string[] SetNicknamePets(int numberPet)
{
    string[] nicknames = new string[numberPet];

    for (int i = 0; i < nicknames.Length; i++)
    {
        Console.Write("Введите кличку питомца номер {0}:", i);
        nicknames[i] = Console.ReadLine();
    }

    return nicknames;
}

static string[] SetFavColors(int numberFavColors)
{
    string[] favColors = new string[numberFavColors];

    for (int i = 0; i < favColors.Length; i++)
    {
        Console.Write("Введите любимы цвет номер {0}:", i);
        favColors[i] = Console.ReadLine();
    }

    return favColors;
}

static bool IsCorrectInput(string val, out int num)
{
    if (int.TryParse(val, out num) && num > 0)
    {
        return true;
    }
    Console.WriteLine("Некорректные данные, повторите попытку)");
    return false;
}

static void ShowUser((string name, string lname, int age, string[] nicknamePets, string[] favColors) user)
{
    Console.WriteLine("Ваше имя: {0}", user.name);
    Console.WriteLine("Ваша фамилия: {0}", user.lname);
    Console.WriteLine("Ваш возраст: {0}", user.age);
    for (int i = 0;i< user.nicknamePets.Length; i++)
    {
        Console.WriteLine("Кличка питомца номер {0}: {1}", i, user.nicknamePets[i]);
    }

    for (int i = 0; i < user.favColors.Length; i++)
    {
        Console.WriteLine("Любимый цвет номер {0}: {1}", i, user.favColors[i]);
    }
}

(string name, string lname, int age, string[] nicknamePets, string[] favColors) user = GetUserData();

ShowUser(user);
