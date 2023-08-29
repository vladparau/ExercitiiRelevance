#region System
using System;
using System.Collections.Generic;
using System.Linq;
#endregion
namespace ExercitiiRelevance
{
    public class ArticolInventar
    {
        public float Greutate { get; }
        public float Volum { get; }

        public ArticolInventar(float greutate, float volum)
        {
            Greutate = greutate;
            Volum = volum;
        }
    }

    public class Sageata : ArticolInventar
    {
        public Sageata() : base(0.1f, 0.05f) { }
    }

    public class Arc : ArticolInventar
    {
        public Arc() : base(1f, 4f) { }
    }
    public class Franghie : ArticolInventar
    {
        public Franghie() : base(1f, 4f) { }
    }
    public class Apa : ArticolInventar
    {
        public Apa() : base(2f, 3f) { }
    }
    public class Mancare : ArticolInventar
    {
        public Mancare() : base(1f, 0.5f) { }
    }
    public class Sabie : ArticolInventar
    {
        public Sabie() : base(5f, 3f) { }
    }



    public class Ghiozdan
    {
        private int NumarMaximArticole { get; }
        private float GreutateMaxima { get; }
        private float VolumMaxim { get; }

        private List<ArticolInventar> articole = new List<ArticolInventar>();

        public Ghiozdan(int numarMaximArticole, float greutateMaxima, float volumMaxim)
        {
            NumarMaximArticole = numarMaximArticole;
            GreutateMaxima = greutateMaxima;
            VolumMaxim = volumMaxim;
        }

        public bool Adauga(ArticolInventar articol)
        {
            if (articole.Count >= NumarMaximArticole ||
                GreutateTotala() + articol.Greutate > GreutateMaxima ||
                VolumTotal() + articol.Volum > VolumMaxim)
            {
                return false;
            }

            articole.Add(articol);
            return true;
        }

        public int NumarArticole() => articole.Count;
        public float GreutateTotala() => articole.Sum(a => a.Greutate);
        public float VolumTotal() => articole.Sum(a => a.Volum);

        public void LimiteAdmise()
        {
            Console.WriteLine($"Numar maxim articole: {NumarMaximArticole}");
            Console.WriteLine($"Greutate maxima: {GreutateMaxima}");
            Console.WriteLine($"Volum maxim: {VolumMaxim}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Ghiozdan ghiozdan = new Ghiozdan(numarMaximArticole: 7, greutateMaxima: 20, volumMaxim: 20);

            while (true)
            {
                Console.WriteLine("Alege un articol pentru a-l adauga in ghiozdan:");
                Console.WriteLine("1. Sageata");
                Console.WriteLine("2. Arc");
                Console.WriteLine("3. Franghie");
                Console.WriteLine("4. Apa");
                Console.WriteLine("5. Mancare");
                Console.WriteLine("6. Sabie");


                int opt;
                if (int.TryParse(Console.ReadLine(), out opt))
                {
                    ArticolInventar articolAdaugat = null;

                    switch (opt)
                    {
                        case 1:
                            articolAdaugat = new Sageata();
                            break;
                        case 2:
                            articolAdaugat = new Arc();
                            break;
                        case 3:
                            articolAdaugat = new Franghie();
                            break;
                        case 4:
                            articolAdaugat = new Apa();
                            break;
                        case 5:
                            articolAdaugat = new Mancare();
                            break;
                        case 6:
                            articolAdaugat = new Sabie();
                            break;
                        default:
                            Console.WriteLine("Optiune invalida!");
                            break;

                    }

                    if (articolAdaugat != null && ghiozdan.Adauga(articolAdaugat))
                    {
                        Console.WriteLine("Articolul a fost adaugat in ghiozdan.");
                    }
                    else
                    {
                        Console.WriteLine("Articolul nu a putut fi adaugat in ghiozdan.");
                    }
                }


                Console.WriteLine($"Numarul de articole: {ghiozdan.NumarArticole()}");
                Console.WriteLine($"Greutate totala: {ghiozdan.GreutateTotala()}");
                Console.WriteLine($"Volum total: {ghiozdan.VolumTotal()}");
                ghiozdan.LimiteAdmise();

                Console.WriteLine("Doriti sa adaugati un alt articol? da/nu");
                string next = Console.ReadLine();

                if (next.ToLower() == "nu" || next.ToLower()!= "da" )
                    break;
            }
        }
    }


}
