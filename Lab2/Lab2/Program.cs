// ZADANIE 5

// KontoBankowe kontoBankowe = new KontoBankowe();
//
// kontoBankowe.Wplata(100);
//
// Console.WriteLine(kontoBankowe.PobierzSaldo());
// kontoBankowe.Wyplata(50);
// Console.WriteLine(kontoBankowe.PobierzSaldo());
// kontoBankowe.Wyplata(55);
//
// class KontoBankowe
// {
//     private double saldo;
//     public void Wplata(double kwota) { saldo += kwota; }
//     public double PobierzSaldo() { return saldo; }
//
//     public void Wyplata(double kwota)
//     {
//         if (saldo >= kwota) saldo -= kwota;
//         else Console.WriteLine("Nie wystarczające środki!");
//     }
// }

// Pies pies = new Pies();
// Kot kot = new Kot();
//
// pies.Szczekaj();
// kot.Miaucz();
//
// class Zwierze
// {
//     public void Jedz() => Console.WriteLine("Zwierzę je");
// }
// class Pies : Zwierze
// {
//     public void Szczekaj() => Console.WriteLine("Hau hau!");
// }
//
// class Kot : Zwierze
// {
//     public void Miaucz() => Console.WriteLine("Miau miau!");
// }