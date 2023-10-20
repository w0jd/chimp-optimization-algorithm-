// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Linq;
namespace malpy{

    class ai {
        public static float RosenbrockFunction(float[] wektor)
        {
            float wyn = 0;
            for (int i = 0; i < wektor.Length - 1; i++)
            {
                wyn += 100 * (float)Math.Pow(wektor[i + 1] - wektor[i] * wektor[i], 2) + (float)Math.Pow(1 - wektor[i], 2);
            }
            return wyn;

        }
        public static float SphereFunction(float[] wektor)
        {
            float wyn = 0;
            for (int i = 0; i < wektor.Length; i++)
            {
                wyn += wektor[i] * wektor[i];
            }
            return wyn;
        }
        public static float BealeFunction(float[] wektor)
        {
            float wyn = 0;
            wyn = (float)Math.Pow(1.5f - wektor[0] + wektor[0] * wektor[1], 2) + (float)Math.Pow(2.25f - wektor[0] + wektor[0] * wektor[1] * wektor[1], 2) + (float)Math.Pow(2.625f - wektor[0] + (float)Math.Pow(wektor[1], 3) * wektor[0], 2);
            return wyn;
        }
        public static float BukinFunctionN6(float[] wektor)
        {
            float wyn = 0;
            wyn = 100f * (float)Math.Pow(Math.Abs(wektor[1] - 0.01 * wektor[0] * wektor[0]), 1 / 2) + 0.01f * (float)Math.Abs(wektor[0] + 10);
            return wyn;
        }
        public static float HimmelblausFunction(float[] wektor)
        {
            float wyn = 0;
            wyn = 100f * (float)Math.Pow(wektor[0] * wektor[0] + wektor[1] - 11, 2) + (float)Math.Abs(wektor[0] + wektor[1] * wektor[1] - 7);
            return wyn;
        }
        public static float licz(float[] wektor)
        {
            float wyn = 0;
            //  float wyn = 2 * wektor[0] * wektor[0] * wektor[0] * wektor[0] -  5 * wektor[0] * wektor[0] - 2 * wektor[0] +3;
            wyn = 10f * wektor.Length;
            for (int i = 0; i < wektor.Length; i++)
            {
                wyn += wektor[i] * wektor[i] - 10f * (float)Math.Cos(2f * (float)Math.PI * wektor[i]);
            }
            /*      foreach (float w in wektor)
                     {
                         wyn *= w;
                     }*/
            /*   wyn=wektor[0]*wektor[0] *wektor[1]* wektor[1];*/
            return wyn;
        }
        static float[] PobierzWiersz(float[,] array, int rowIndex)
        {
            int liczbaKolumn = array.GetLength(1);
            float[] wiersz = new float[liczbaKolumn];

            for (int i = 0; i < liczbaKolumn; i++)
            {
                wiersz[i] = array[rowIndex, i];
            }

            return wiersz;
        }
        static int[] ZnajdzNajmniejszeIndeksy(float[] array)
        {
            return array
                .Select((value, index) => new { Value = value, Index = index })
                .OrderBy(item => item.Value)
                .Take(4)
                .Select(item => item.Index)
                .ToArray();
        }
        static float PoliczC() {
            Random rand = new Random();
            return (float)(2 * rand.NextDouble());
        }
        static float PoliczFat(int obecnaIteracja, int iloscIteracji) {
            return 1.95f - (float)Math.Pow(2 * obecnaIteracja, 1 / 4) * (float)Math.Log10(Math.Pow(iloscIteracji, 1 / 3));
        }
        static float PoliczFblok(int obecnaIteracja, int iloscIteracji) {
            return 1.95f - (float)Math.Pow(2 * obecnaIteracja, 1 / 3) * (float)Math.Log10(Math.Pow(iloscIteracji, 1 / 4));
        }
        static float PoliczFgon(int obecnaIteracja, int iloscIteracji) {
            return 1.5f + (float)Math.Pow(-3 * obecnaIteracja, 3) / (float)Math.Pow(iloscIteracji, 3);
        }
        static float PoliczFkier(int obecnaIteracja, int iloscIteracji) {
            return 1.5f + (float)Math.Pow(-2 * obecnaIteracja, 3) / (float)Math.Pow(iloscIteracji, 3);
        }
        static float PoliczR() {
            Random rand = new Random();
            return (float)(rand.NextDouble());
        }
        static float[] PomnurzPodziel(float[] wektor, float mnoznik, string znak) {
            if (znak == "*") {
                for (int i = 0; i < wektor.Length; i++) {
                    float wynik = wektor[i] * mnoznik;
                    wektor[i] = wynik;


                }
            } else {
                for (int i = 0; i < wektor.Length; i++) {
                    float wynik = wektor[i] / mnoznik;
                    wektor[i] = wynik;
                }
            }
            return wektor;
        }
        static float[] DoadjOdejij(float[] wektor1, float[] wektor2, string znak) {
            if (znak == "+") {
                for (int i = 0; i < wektor1.Length; i++) {

                    float wynik = wektor1[i] + wektor2[i];
                    wektor1[i] = wynik;
                }
            } else {
                for (int i = 0; i < wektor1.Length; i++) {
                    float wynik = wektor1[i] - wektor2[i];

                    wektor1[i] = wynik;
                }
            }
            return wektor1;
        }
        static Tuple<float[,], float[]> PierwszeWyp(float[,] szymapnse, float poupulacja, float wymiar, float prawyZakres, float lewyZakres, float[] wyniki)
        {
            Random rand = new Random();
            for (int i = 0; i < poupulacja; i++)
            {
                for (int j = 0; j < wymiar; j++)
                {
                    szymapnse[i, j] = (float)rand.NextDouble() * ( prawyZakres-lewyZakres) + lewyZakres;
                }
                wyniki[i] = licz(PobierzWiersz(szymapnse, i));
            }
            return new Tuple<float[,], float[]>(szymapnse, wyniki);
        }
        static float wybierzWzor(float[] wektor,int nr,float wymiar){
            float a;
            switch (nr)
            {
                case 1:

                    a = licz(wektor);
                    return a;                    
                case 2:
                    a = RosenbrockFunction(wektor);
                    return a;
                    
                case 3:
                    a = SphereFunction(wektor);
                    return a;

                case 4:
                    a = BealeFunction(wektor);
                    return a;
                case 5:
                    a = BukinFunctionN6(wektor); return a;
                case 6:
                    a = HimmelblausFunction(wektor);
                    return a;
            }
            //a[0] = 1;
            return 0f;
        }
        static float []LosowyWektor(int min,int max,int wymiar)
        {
            float[] wektor = new float[wymiar];
            Random rand = new Random();
            for (int i = 0; i < wymiar; i++)
            {
               wektor[i]= (float)rand.NextDouble() * (max - min) + max;
            }
            return wektor;
        } 
        static float[] MnozWektory(float[] wektor1, float[] wektor2, int wymiar)
        {
            float[] wektor= new float[wymiar];
            for(int i=0;  i < wymiar; i++)
            {
                wektor[i] = wektor1[i] * wektor2[i];
            }
            return wektor;
        }
        static float rozKwa(List<float> lst,float sr)
        {
            float sumaKwadratowRoznicy=0;
            foreach (float wynik in lst)
            {
                float roznica = wynik - sr;
                float kwadratRoznicy = roznica * roznica;
                sumaKwadratowRoznicy += kwadratRoznicy;
               
            }
            sumaKwadratowRoznicy = (float)Math.Pow(sumaKwadratowRoznicy / lst.Count,1/2f);
            return sumaKwadratowRoznicy;

        }
        static void Main(string[] args) {
            int poupulacja = 40;
            int wymiar = 30;
            float m, a;          
            float prawyZakres = 10;
            float lewyZakres = -10;
            float[] atakuacy = new float[wymiar];
            float[] Datakuacy = new float[wymiar];
            float[] blokujacy = new float[wymiar];
            float[] Dblokujacy = new float[wymiar];
            float[] goniacy = new float[wymiar];
            float[] Dgoniacy = new float[wymiar];
            float[] kierowca = new float[wymiar];
            float[] Dkierowca = new float[wymiar];
            int[] listaNaj = new int[4];
            float[,] szymapnse = new float[poupulacja, wymiar];
            int ileIteracji = 10;
            float[] wyniki = new float[poupulacja];
            float[] X1 = new float[wymiar];
            float[] X2 = new float[wymiar];
            float[] X3 = new float[wymiar];
            float[] X4 = new float[wymiar];
            float[] NowyX = new float[wymiar];
            Random rand = new Random();
            int[] N = { 10, 20, 40, 80 };
            int[] I = { 5, 10, 20, 40, 60, 80 };
            float mu = (float)rand.NextDouble();
            float[] tabPoz = new float[poupulacja];
            float[] tabWyn1= new float[poupulacja];
            List<float> tabWyn = new List<float>();
/*            foreach (int ileIt in I)
            {*/
                for (int i = 0; i < 50; i++) {
                    var zbiur = PierwszeWyp(szymapnse, poupulacja, wymiar, prawyZakres, lewyZakres, wyniki);
                    szymapnse = zbiur.Item1;
                    wyniki = zbiur.Item2;
                    listaNaj = ZnajdzNajmniejszeIndeksy(wyniki);
                    atakuacy = PobierzWiersz(szymapnse, listaNaj[0]);
                    blokujacy = PobierzWiersz(szymapnse, listaNaj[1]);
                    goniacy = PobierzWiersz(szymapnse, listaNaj[2]);
                    kierowca = PobierzWiersz(szymapnse, listaNaj[3]);
                    for (int j = 0; j < poupulacja; j++) {
                        mu = (float)rand.NextDouble();
                        if (j != listaNaj[0] && j != listaNaj[1] && j != listaNaj[2] && j != listaNaj[3]) {
                            if (mu < 0.5f) {
                                for (int k = 0; k < wymiar; k++) {
                                    szymapnse[j, k] = (float)rand.NextDouble() * (prawyZakres - lewyZakres) + prawyZakres;
                                    wyniki[j] = licz(PobierzWiersz(szymapnse, j));
                                }
                            } else {
                                float c1 = PoliczC();
                                float c2 = PoliczC();
                                float c3 = PoliczC();
                                float c4 = PoliczC();
               /*                 float[] WekC1 = new float[wymiar];
                                WekC1 = LosowyWektor(0, 2, wymiar);
                                float[] M1 = new float[wymiar];
                                M1 = LosowyWektor((int)lewyZakres, (int)prawyZakres, wymiar);
                                Datakuacy = DoadjOdejij(MnozWektory(atakuacy, WekC1, wymiar), MnozWektory(PobierzWiersz(szymapnse, j), M1, wymiar), "-");
                                WekC1 = LosowyWektor(0, 2, wymiar);
                                M1 = LosowyWektor((int)lewyZakres, (int)prawyZakres, wymiar);
                                Dblokujacy = DoadjOdejij(MnozWektory(blokujacy, WekC1, wymiar), MnozWektory(PobierzWiersz(szymapnse, j), M1, wymiar), "-");

                                WekC1 = LosowyWektor(0, 2, wymiar);
                                M1 = LosowyWektor((int)lewyZakres, (int)prawyZakres, wymiar);
                                Dgoniacy = DoadjOdejij(MnozWektory(goniacy, WekC1, wymiar), MnozWektory(PobierzWiersz(szymapnse, j), M1, wymiar), "-");

                                m = (float)rand.NextDouble();
                                WekC1 = LosowyWektor(0, 2, wymiar);
                                M1 = LosowyWektor((int)lewyZakres, (int)prawyZakres, wymiar);
                                Dkierowca = DoadjOdejij(MnozWektory(kierowca, WekC1, wymiar), MnozWektory(PobierzWiersz(szymapnse, j), M1, wymiar), "-");*/


                                m = (float)rand.NextDouble();
                                Datakuacy = DoadjOdejij(PomnurzPodziel(atakuacy, c1, "*"), PomnurzPodziel(PobierzWiersz(szymapnse, j), m, "*"), "-");
                                m = (float)rand.NextDouble();
                                Dblokujacy = DoadjOdejij(PomnurzPodziel(blokujacy, c2, "*"), PomnurzPodziel(PobierzWiersz(szymapnse, j), m, "*"), "-");
                                m = (float)rand.NextDouble();
                                Dgoniacy = DoadjOdejij(PomnurzPodziel(goniacy, c3, "*"), PomnurzPodziel(PobierzWiersz(szymapnse, j), m, "*"), "-");
                                m = (float)rand.NextDouble();
                                Dkierowca = DoadjOdejij(PomnurzPodziel(kierowca, c4, "*"), PomnurzPodziel(PobierzWiersz(szymapnse, j), m, "*"), "-");
                                a = 2 * PoliczR() * PoliczFat(i, ileIteracji) - PoliczFat(i, ileIteracji);
                                atakuacy = PobierzWiersz(szymapnse, listaNaj[0]);
                                blokujacy = PobierzWiersz(szymapnse, listaNaj[1]);
                                goniacy = PobierzWiersz(szymapnse, listaNaj[2]);
                                kierowca = PobierzWiersz(szymapnse, listaNaj[3]);
                                X1 = DoadjOdejij(atakuacy, PomnurzPodziel(Datakuacy, a, "*"), "-");
                                a = 2 * PoliczR() * PoliczFblok(i, ileIteracji) - PoliczFblok(i, ileIteracji);
                                X2 = DoadjOdejij(blokujacy, PomnurzPodziel(Dblokujacy, a, "*"), "-");
                                a = 2 * PoliczR() * PoliczFgon(i, ileIteracji) - PoliczFgon(i, ileIteracji);
                                X3 = DoadjOdejij(goniacy, PomnurzPodziel(Dgoniacy, a, "*"), "-");
                                a = 2 * PoliczR() * PoliczFkier(i, ileIteracji) - PoliczFkier(i, ileIteracji);
                                X4 = DoadjOdejij(kierowca, PomnurzPodziel(Dkierowca, a, "*"), "-");
                                NowyX = PomnurzPodziel(DoadjOdejij(X1, DoadjOdejij(X2, DoadjOdejij(X3, X4, "+"), "+"), "+"), 4, "/");
                                
                                for (int k = 0; k < wymiar; k++) {
                                    if (NowyX[k] < lewyZakres)
                                    {
                                        NowyX[k] = lewyZakres;
                                    } else if (NowyX[k] > prawyZakres) {
                                        NowyX[k] = prawyZakres;
                                    }
                                    szymapnse[j, k] = NowyX[k];
                                }
                            }
                        }
                    }
                    for (int it = 0; it < poupulacja; it++) {
                        wyniki[it] = licz(PobierzWiersz(szymapnse, it));
   
                    }
                    listaNaj = ZnajdzNajmniejszeIndeksy(wyniki);
                    atakuacy = PobierzWiersz(szymapnse, listaNaj[0]);
                    blokujacy = PobierzWiersz(szymapnse, listaNaj[1]);
                    goniacy = PobierzWiersz(szymapnse, listaNaj[2]);
                    kierowca = PobierzWiersz(szymapnse, listaNaj[3]);
                    Console.WriteLine(licz(atakuacy));
                }
                tabWyn.Add( wybierzWzor(atakuacy, 1, wymiar));
             
                //Console.Write("y= ");
                // Console.WriteLine(atakuacy[0]);
            }
/*            float srWyn = tabWyn.Average();
            float odh = rozKwa(tabWyn, srWyn);
            //Console.Write("pozycja małpy");
            Console.WriteLine(srWyn);
            Console.WriteLine(odh);
            //Array.ForEach(atakuacy, Console.WriteLine);
        }*/
    }
}