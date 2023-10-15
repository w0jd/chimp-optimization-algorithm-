// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Linq;
namespace malpy{

    class ai {
        public static float licz(float[] wektor)
        {
            float wyn=wektor[0]*wektor[0]+1;
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
        static float PoliczC(){
            Random rand=new Random();
            return (float)(2*rand.NextDouble());
        }
        static float PoliczFat(int obecnaIteracja, int iloscIteracji){
            return 1.95f-(float)Math.Pow(2*obecnaIteracja,1/4)*(float)Math.Log10(Math.Pow(iloscIteracji,1/3));
        }
        static float PoliczFblok(int obecnaIteracja, int iloscIteracji){
            return 1.95f-(float)Math.Pow(2*obecnaIteracja,1/3)*(float)Math.Log10(Math.Pow(iloscIteracji,1/4));
        }
        static float PoliczFgon(int obecnaIteracja, int iloscIteracji){
            return 1.5f+(float)Math.Pow(-3*obecnaIteracja,3)/(float)Math.Pow(iloscIteracji,3);
        }
        static float PoliczFkier(int obecnaIteracja, int iloscIteracji){
            return 1.5f+(float)Math.Pow(-2*obecnaIteracja,3)/(float)Math.Pow(iloscIteracji,3);
        }
        static float PoliczR(){
             Random rand=new Random();
            return (float)(rand.NextDouble()); 
        }
        static float[] PomnurzPodziel(float [] wektor,float mnoznik,string znak){
            if(znak=="*"){
            for (int i=0 ; i<wektor.Length;i++){
                wektor[i]=wektor[i]*mnoznik;
      

            }
            }else{
            for (int i=0 ; i<wektor.Length;i++){
                wektor[i]=wektor[i]/mnoznik;
            }
            }
            return wektor;
        }
        static float[] DoadjOdejij(float []wektor1, float[] wektor2,string znak){
            if(znak=="+"){
            for (int i=0 ; i<wektor1.Length;i++){
                wektor1[i]=wektor1[i]+wektor2[i];
            }
            }else{          
                for (int i=0 ; i<wektor1.Length;i++){
                wektor1[i]=wektor1[i]-wektor2[i];
            }
            }
            return wektor1;
        }
        static void Main(string[] args){
            int poupulacja=10;
           
            int wymiar=1;
            float m,a,c;
            int prawyZakres=10;
            int lewyZakres=-10;
            float[] atakuacy=new float[wymiar];
            float[] Datakuacy=new float[wymiar];
            float[] blokujacy=new float[wymiar];
            float[] Dblokujacy=new float[wymiar];
            float[] goniacy=new float[wymiar];
            float[] Dgoniacy=new float[wymiar];
            float[] kierowca=new float[wymiar];
            float[] Dkierowca=new float[wymiar];
            int[] listaNaj=new int[4];
            
            float[,] szymapnse=new float[poupulacja , wymiar];
            int ileIteracji=5;
            float[] wyniki = new float[poupulacja];
            float []X1=new float[wymiar];
            float []X2=new float[wymiar];
            float []X3=new float[wymiar];
            float []X4=new float[wymiar];
            float []NowyX=new float[wymiar];
            Random rand=new Random();
            float mu=(float)rand.NextDouble();
            // Console.WriteLine("a");
            for (int i=0;i<poupulacja;i++ ){
                for(int j=0;j<wymiar;j++){
                  
                    
                    szymapnse[i,j]=  (float)rand.NextDouble()*(prawyZakres-lewyZakres)+prawyZakres;
                    // Console.Write("liczba");
                    // Console.WriteLine((float)rand.NextDouble()*(lewyZakres-prawyZakres)+lewyZakres);
                    // Console.Write("szempans");

                    // Console.WriteLine(szymapnse[i,j]);

                }
                    wyniki[i] = licz(PobierzWiersz(szymapnse, i));
                    // Console.Write("szympans ");
                    // Console.WriteLine(PobierzWiersz(szymapnse, i)[0]);
                    // Console.Write("wynik ");
                    Console.WriteLine(wyniki[i]);
            }
            listaNaj= ZnajdzNajmniejszeIndeksy(wyniki);
            Console.Write("listaNaj[0]= ");

            Console.WriteLine(listaNaj[0]);
            Console.Write("sympans najlepszy");
            atakuacy=PobierzWiersz(szymapnse, listaNaj[0]);
            Console.WriteLine(atakuacy[0]);

            blokujacy=PobierzWiersz(szymapnse, listaNaj[1]);
            goniacy=PobierzWiersz(szymapnse, listaNaj[2]);
            kierowca=PobierzWiersz(szymapnse, listaNaj[3]);
            // Console.WriteLine("atakuacy[0]=");

            // Console.WriteLine(atakuacy[0]);
            
            for (int i=0;i<ileIteracji;i++ ){
                for(int j=0;j<poupulacja;j++){
                  mu=(float)rand.NextDouble();
                  if(j!=listaNaj[0]&&j!=listaNaj[1]&&j!=listaNaj[2]&&j!=listaNaj[3]){
                      if(mu<0.5f){
                            for(int k=0;k<wymiar;k++){
                                //ziterować po elementach tablicy 
                             szymapnse[j,k]=  (int)rand.NextDouble()*(prawyZakres-lewyZakres)+prawyZakres;
                             wyniki[j] = licz(PobierzWiersz(szymapnse, j));
    
                            } 
                        }else{
                            float c1=PoliczC();
                            float c2=PoliczC();
                            float c3=PoliczC();
                            float c4=PoliczC();
                            m=(float)rand.NextDouble();
                            Datakuacy=DoadjOdejij(PomnurzPodziel(atakuacy,c1,"*"),PomnurzPodziel(PobierzWiersz(szymapnse, j),m,"*"),"-");
                            Console.Write("Datakuacy= ");
                            Console.WriteLine(Datakuacy[0]);
                            m=(float)rand.NextDouble();
                            Dblokujacy=DoadjOdejij(PomnurzPodziel(blokujacy,c2,"*"),PomnurzPodziel(PobierzWiersz(szymapnse, j),m,"*"),"-");
                            m=(float)rand.NextDouble();
                            Dgoniacy=DoadjOdejij(PomnurzPodziel(goniacy,c3,"*"),PomnurzPodziel(PobierzWiersz(szymapnse, j),m,"*"),"-");
                            m=(float)rand.NextDouble();
                            Dkierowca=DoadjOdejij(PomnurzPodziel(kierowca,c4,"*"),PomnurzPodziel(PobierzWiersz(szymapnse, j),m,"*"),"-");
                            a=2*PoliczR()*PoliczFat(i,ileIteracji)-PoliczFat(i,ileIteracji);
                            // Console.WriteLine(a);
                            X1=DoadjOdejij(atakuacy,PomnurzPodziel(Datakuacy,a,"*"),"-");
                            Console.Write("X1= ");
                            Console.WriteLine(X1[0]);

                            a=2*PoliczR()*PoliczFblok(i,ileIteracji)-PoliczFblok(i,ileIteracji);
                            X2=DoadjOdejij(blokujacy,PomnurzPodziel(Dblokujacy,a,"*"),"-");
                            a=2*PoliczR()*PoliczFgon(i,ileIteracji)-PoliczFgon(i,ileIteracji);
                            X3=DoadjOdejij(goniacy,PomnurzPodziel(Dgoniacy,a,"*"),"-");
                            a=2*PoliczR()*PoliczFkier(i,ileIteracji)-PoliczFkier(i,ileIteracji);
                            X4=DoadjOdejij(kierowca,PomnurzPodziel(Dkierowca,a,"*"),"-");
                            NowyX=PomnurzPodziel(DoadjOdejij(X1,DoadjOdejij(X2,DoadjOdejij(X3,X4,"+"),"+"),"+"),4,"/");
                            for(int k=0;k<wymiar;k++){
                                szymapnse[j,k]=NowyX[k];
                            }
                        }
                    }
                }
                for(int it=0;it<poupulacja;it++){
                    wyniki[i] = licz(PobierzWiersz(szymapnse, i));
                }
                listaNaj= ZnajdzNajmniejszeIndeksy(wyniki);
                // Console.WriteLine(wyniki);
                // Console.WriteLine(atakuacy[0]);
                // Console.WriteLine(licz(atakuacy));
                atakuacy=PobierzWiersz(szymapnse, listaNaj[0]);
                blokujacy=PobierzWiersz(szymapnse, listaNaj[1]);
                goniacy=PobierzWiersz(szymapnse, listaNaj[2]);
                kierowca=PobierzWiersz(szymapnse, listaNaj[3]); 
            }
        // Console.WriteLine(atakuacy);
        // Console.WriteLine(wyniki[0]);

        
       } 
    }
}