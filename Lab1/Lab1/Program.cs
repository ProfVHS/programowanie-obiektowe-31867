// ZADANIE 0

// const int requiredAge = 14;
// const int simRequiredAge = 18;
// const string accessDenied = "Musisz mieć 18 lat.";
// const string accessAllowed = "Witamy w naszym sklepie";
// const string simRestrictionMessage = "Witamy w naszym sklepie, musisz mieć 18 lat aby zakupić kartę sim";
//
// Console.WriteLine("Podaj swój wiek: ");
//
// string? input = Console.ReadLine();
//
// bool success = int.TryParse(input, out var age);
//
// if (!success)
// {
//     Console.WriteLine("Podaj poprawną wartość!");
// }
// else
// {
//     if (age >= simRequiredAge)
//     {
//         Console.WriteLine(accessAllowed);
//     }
//     else if (age >= requiredAge)
//     {
//         Console.WriteLine(simRestrictionMessage);
//     }
//     else
//     {
//         Console.WriteLine(accessDenied);
//     }
// }


// ZADANIE 1

// var input = "";
//
// while (input != "admin123")
// {
//     Console.WriteLine("Podaj hasło: ");
//     input = Console.ReadLine();
// }
//
// Console.WriteLine("Zalogowano pomyślnie!");

// ZADANIE 2

// int number = 0;
// while (number <= 0)
// {
//     Console.WriteLine("Podaj liczbę większą od zera");
//     var input = Console.ReadLine();
//     Int32.TryParse(input, out number);
// }

// ZADANIE 3

// string[] cities = { "Warszawa", "Berlin", "Katowice", "Krakow", "Poznań" };
// foreach (string city in cities)
// {
//     Console.WriteLine(city);
// }