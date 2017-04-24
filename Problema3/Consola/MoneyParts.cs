using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Consola
{
    public static class MoneyParts
    {
      


        /*

        public static void mostrarOptimo(decimal parametroEntrada, decimal[] multiplo, int limitante, Dictionary<decimal, int> dictionary)
        {
            
            decimal parametroEntradaInicial = parametroEntrada;
            
                decimal[] monedas = { 0.05m,0.10m,0.20m,0.50m,1,2,5,10,20,50,100,200};           
 int cantidad = 0;
               decimal ultimoMultiplo=0;
                int ultimoJ=0;
                int ultimaCantidad = 0;
                while (ultimoJ>=0)
                {                   
                    Console.Write("[");
         
            for (int j = multiplo.Length-1; j >= 0;j--)
            {

                if (parametroEntrada % multiplo[j] == 0)
                {
                    cantidad = Convert.ToInt32(parametroEntrada / multiplo[j]);

                    if (dictionary.Count()>0)                    
                    cantidad = cantidad - dictionary[multiplo[multiplo.Length - 2]];

                    for (int i = 0; i < cantidad; i++) { 
                        Console.Write(multiplo[j]);
                    }
                    //Console.Write("]");                               
                }
                else {
                    cantidad = Convert.ToInt32(Math.Floor(parametroEntrada / multiplo[j]));

                    if (dictionary.Count() > 0)
                    cantidad = cantidad-dictionary[multiplo[multiplo.Length - 2]];


                    for (int i = 0; i < cantidad; i++) {
                        Console.Write(multiplo[j] + ",");
                    }
                    parametroEntrada = parametroEntrada - multiplo[j]*cantidad;                
                }
                ultimoMultiplo = multiplo[j];
                dictionary.Add(multiplo[j],cantidad);

                if (j == multiplo.Length - 2)
                ultimaCantidad = cantidad;
            }
            Console.Write("]");
            Console.WriteLine();

            //para bucle
            if (ultimoMultiplo == 0.05m && cantidad == limitante)
            {
                break;
            }
            if (dictionary[multiplo[multiplo.Length - 2]] == 0)
            { dictionary[multiplo[multiplo.Length - 1]]=cantidad-1;
                
                mostrarOptimo(parametroEntradaInicial, multiplo, limitante, dictionary);
                
            }
            else
            {
                mostrarOptimo(parametroEntradaInicial, multiplo, limitante, dictionary);
            }      
            }        
        }
        */
        public static string mostrarUnidad(decimal parametroEntrada,decimal multiplo){
        int cantidad =Convert.ToInt32( parametroEntrada/multiplo);
            decimal[] numerosRepetidos= new decimal[cantidad];
            for(int j=0;j<cantidad;j++){
            numerosRepetidos[j]=multiplo;
            }
            return "["+string.Join(",", numerosRepetidos)+"]";
        }

        public static string mostrarUnidadParcial(decimal parametroEntrada, decimal multiplo)
        {
            int cantidad = Convert.ToInt32(parametroEntrada / multiplo);
            decimal[] numerosRepetidos = new decimal[cantidad];
            for (int j = 0; j < cantidad; j++)
            {
                numerosRepetidos[j] = multiplo;
            }
            return  string.Join(",", numerosRepetidos) ;
        }






        public static Dictionary<decimal, int> cantidadMaximas(decimal parametroEntrada, decimal[] multiplo)
        {

            Dictionary<decimal, int> d = new Dictionary<decimal, int>();


            for (int j = multiplo.Length - 1; j >= 0; j--)
            {         int cantidadAnterior =Convert.ToInt32(Math.Floor(parametroEntrada / multiplo[j]));
            d.Add(multiplo[j], cantidadAnterior);
            }
            return d;
        }


        public static Dictionary<decimal, int> Inicial(decimal parametroEntrada, decimal[] multiplo)
        {

            Dictionary<decimal, int> d = new Dictionary<decimal, int>();


            for (int j = multiplo.Length - 1; j >= 0; j--)
            {
                int cantidadAnterior = Convert.ToInt32(Math.Floor(parametroEntrada / multiplo[j]));
                for (int i = 0; i < cantidadAnterior; i++)
                {
                    //Console.Write(multiplo[j] + ",");
                }
                
                parametroEntrada = parametroEntrada - multiplo[j] * cantidadAnterior;
                d.Add(multiplo[j], cantidadAnterior);
            }
            //Console.WriteLine("");
            return d;
        }
        public static Dictionary<decimal, int> InicialF(decimal parametroEntrada, decimal[] multiplo)
        {

            Dictionary<decimal, int> d = new Dictionary<decimal, int>();


            for (int j = multiplo.Length - 1; j >= 0; j--)
            {
                int cantidadAnterior = Convert.ToInt32(Math.Floor(parametroEntrada / multiplo[j]));
                for (int i = 0; i < cantidadAnterior; i++)
                {
                    //Console.Write(multiplo[j] + ",");
                }

                parametroEntrada = parametroEntrada - multiplo[j] * cantidadAnterior;
                d.Add(multiplo[j], cantidadAnterior);
            }
           //Console.WriteLine("");
            return d;
        }

        public static string mostrarData(decimal parametroEntrada, decimal[] cantidadesPosibles)
        {
            string final="";
            //2 soles
            decimal maximo_valor=cantidadesPosibles[cantidadesPosibles.Length-1];
            //
           decimal cantidad =maximo_valor%parametroEntrada;
            int numeroMayorCantidad=0;
            if(cantidad==0){
            numeroMayorCantidad=Convert.ToInt32( parametroEntrada/maximo_valor);
               final+= mostrarUnidad(parametroEntrada,maximo_valor);
            }else{
            int cantidadAnterior =Convert.ToInt32(Math.Floor(parametroEntrada / maximo_valor));

            decimal parametroEntradaNuevo= parametroEntrada-maximo_valor*(cantidadAnterior-1);
                final+=mostrarUnidadParcial(parametroEntrada,maximo_valor)+",";
                cantidadesPosibles=cantidadesPosibles.Take(cantidadesPosibles.Count()-1).ToArray();

                mostrarData(parametroEntradaNuevo,cantidadesPosibles);
            }
          return final;


   

        
        
        
        
        }







        public static void build(string parametroEntrada)
        {
            string salida = "";
         
            parametroEntrada = parametroEntrada.Replace("\"", "");
            try {
              
                decimal[] monedas = { 0.05m,0.10m,0.20m,0.50m,1,2,5,10,20,50,100,200};

                decimal parametroDouble = Convert.ToDecimal(parametroEntrada,CultureInfo.GetCultureInfo("en"));
              
                
                decimal[] cantidadesPosibles= monedas.Where(x=>x<parametroDouble).ToArray();
             
                    
                        Console.WriteLine();

                        int maximaMonedasMinimas = Convert.ToInt32(Math.Floor(parametroDouble / cantidadesPosibles[0]));
                Dictionary<decimal, int> d=new Dictionary<decimal, int>();

                Dictionary<decimal, int> cantidadMaxima = cantidadMaximas(parametroDouble, cantidadesPosibles);
               Dictionary<decimal, int> diccionario= InicialF(parametroDouble, cantidadesPosibles);

                int entrada=0;
                if(diccionario[0.10m]==0){
                    entrada=cantidadMaxima[cantidadMaxima.Keys.Max()]-1;
                }else{
                entrada=cantidadMaxima[cantidadMaxima.Keys.Max()];
                }


                //for (int j = 0; j < cantidadesPosibles.Length;j++ )
                //{
                    mostrar(parametroDouble, diccionario, entrada, cantidadesPosibles);
                //}        


                    

            }
            catch (Exception e)
            {
                Console.WriteLine("error encontrado");
                
            }
           
        }

        public static void mostrar(decimal MontoEntrada, Dictionary<decimal, int> tuplas, int numeroEntrada, decimal[] multiplo)
        {

            decimal keyMaximo=tuplas.Keys.Max();
            decimal MontoOriginal = MontoEntrada;
            int cantidad005 = 0;
            int cantidad010 = 0;
            int cantidad020 = 0;
            int cantidad050 = 0;
            int cantidad1 = 0;
            int cantidad2 = 0;
            int cantidad5 = 0;
            int cantidad10 = 0;
            int cantidad20 = 0;
            int cantidad50 = 0;
            int cantidad100 = 0;
            int cantidad200 = 0;

            int tuplas005 = tuplas.ContainsKey(0.05m) ? tuplas[0.05m] : 0;
            int tuplas010 = tuplas.ContainsKey(0.10m) ? tuplas[0.10m] : 0;
            int tuplas020 = tuplas.ContainsKey(0.20m) ? tuplas[0.20m] : 0;
            int tuplas050 = tuplas.ContainsKey(0.50m) ? tuplas[0.50m] : 0;
            int tuplas1 = tuplas.ContainsKey(1) ? tuplas[1] : 0;
            int tuplas2 = tuplas.ContainsKey(2) ? tuplas[2] : 0;
            int tuplas5 = tuplas.ContainsKey(5) ? tuplas[5] : 0; ;
            int tuplas10 = tuplas.ContainsKey(10) ? tuplas[10] : 0;
            int tuplas20 = tuplas.ContainsKey(20) ? tuplas[20] : 0;
            int tuplas50 = tuplas.ContainsKey(50) ? tuplas[50] : 0;
            int tuplas100 = tuplas.ContainsKey(100) ? tuplas[100] : 0;
            int tuplas200 = tuplas.ContainsKey(200) ? tuplas[200] : 0;
            int cantidadAnterior = 0;

            bool pas_200 = false;
            int cont200 = 0;
            while (cantidad200 >= 0 && !pas_200)
            {
          
                decimal[] monedas200 = { 0.05m, 0.10m, 0.20m, 0.50m, 1, 2, 5, 10, 20,50,100,200 };
                Dictionary<decimal, int> tuplas_200 = Inicial(MontoEntrada, monedas200);
                //cantidadAnterior = Convert.ToInt32(Math.Floor(MontoEntrada / 200));
                //if (cont200 != 0)
                //{
                //    cantidadAnterior = cantidad200;
                //}
                //cont200++;

                if (tuplas200 > 0)
                {
                    for (int i = 0; i < tuplas200; i++)
                        Console.Write("200,");
                    cantidad200 = tuplas200;
                }
                else {
                    cantidad200 = -1;
                }
                   
                MontoEntrada = MontoEntrada - cantidadAnterior * 200;
                bool pas_100 = false;
                int cont100 = 0;
                while (cantidad100 >= 0 && !pas_100)
                {


                    decimal[] monedas100 = { 0.05m, 0.10m, 0.20m, 0.50m, 1, 2, 5, 10, 20, 50, 100 };
                    Dictionary<decimal, int> tuplas_100 = Inicial(MontoEntrada, monedas100);
                    //cantidadAnterior = Convert.ToInt32(Math.Floor(MontoEntrada / 100));
                    //if (cont100 != 0)
                    //{
                    //    cantidadAnterior = cantidad100;
                    //}
                    //cont100++;
                    if (tuplas100 > 0)
                    {
                        for (int i = 0; i < tuplas100; i++)
                            Console.Write("100,");
                        cantidad100 = tuplas100;

                    }
                    else {
                        cantidad100 = -1;
                    }
                  
                    MontoEntrada = MontoEntrada - cantidadAnterior * 100;
                    bool pas_50 = false;
                    int cont50 = 0;
                    while (cantidad50 >= 0 && !pas_50)
                    {
                       
                        decimal[] monedas50 = { 0.05m, 0.10m, 0.20m, 0.50m, 1, 2, 5, 10, 20, 50 };
                        Dictionary<decimal, int> tuplas_50 = Inicial(MontoEntrada, monedas50);
                        //cantidadAnterior = Convert.ToInt32(Math.Floor(MontoEntrada / 50));
                        //if (cont50 != 0)
                        //{
                        //    cantidadAnterior = cantidad50;
                        //}
                        //cont50++;

                        if (tuplas50 > 0)
                        {
                            for (int i = 0; i < tuplas50; i++)
                                Console.Write("50,");
                            cantidad50 = tuplas50;
                        }
                        else {
                            cantidad50 = -1;
                        }
                           

                        MontoEntrada = MontoEntrada - cantidadAnterior * 50;
                        bool pas_20 = false;
                        int cont20 = 0;
                        while (cantidad20 >= 0 && !pas_20)
                        {



                            MontoEntrada = MontoEntrada - cantidad20 * 20;
                            decimal[] monedas20 = { 0.05m, 0.10m, 0.20m, 0.50m, 1, 2, 5, 10,20 };
                            Dictionary<decimal, int> tuplas_20 = Inicial(MontoEntrada, monedas20);
                            //cantidadAnterior = Convert.ToInt32(Math.Floor(MontoEntrada / 20));
                           
                            //    if (cont20 != 0)
                            //    {
                            //        cantidadAnterior = cantidad20;
                            //    }
                            //    cont20++;

                            if (tuplas20>0)
                            {

                                for (int i = 0; i < tuplas20; i++)
                                    Console.Write("20,");
                                cantidad20 = tuplas20;
                            }
                            else {
                                cantidad20 = -1;
                            
                            }
                               
                            MontoEntrada = MontoEntrada - cantidadAnterior * 20;
                            bool pas_10 = false;
                            int cont10 = 0;
                            while (cantidad10 >= 0 && !pas_10)
                            {
                                MontoEntrada = MontoEntrada - cantidad10 * 10;
                                decimal[] monedas10 = { 0.05m, 0.10m, 0.20m, 0.50m, 1, 2, 5,10 };
                                Dictionary<decimal, int> tuplas_10 = Inicial(MontoEntrada, monedas10);
                                //cantidadAnterior = Convert.ToInt32(Math.Floor(MontoEntrada / 10));

                                //if (cont10 != 0)
                                //{
                                //    cantidadAnterior = cantidad10;
                                //}
                                //cont10++;

                                if (tuplas10 > 0)
                                {
                                    for (int i = 0; i < tuplas10; i++)
                                        Console.Write("10,");
                                    cantidad10 = tuplas10;
                                }
                                else {
                                    cantidad10 = -1;
                                }
                                    
                                MontoEntrada = MontoEntrada - cantidadAnterior * 10;

                                bool pas_5 = false;
                                int cont5 = 0;
                                while (cantidad5 >= 0 && !pas_5)
                                {

                                    
                                    decimal[] monedas5 = { 0.05m, 0.10m, 0.20m, 0.50m, 1, 2,5 };
                                    Dictionary<decimal, int> tuplas_5 = Inicial(MontoEntrada, monedas5);
                                    //cantidadAnterior = Convert.ToInt32(Math.Floor(MontoEntrada / 5));
                                    //if (cont5 != 0)
                                    //{
                                    //    cantidadAnterior = cantidad5;
                                    //}
                                    //cont5++;


                                    if (tuplas5>0)
                                    {
                                        for (int i = 0; i < tuplas5; i++)
                                            Console.Write("5,");
                                        cantidad5 = tuplas5;
                                    }
                                    else {
                                        cantidad5 = -1;
                                    }
                                        
                                    MontoEntrada = MontoEntrada - cantidadAnterior * 5;

                                    bool pas_2 = false;
                                    int cont2 = 0;
                                    while (cantidad2 >= 0 && !pas_2)
                                    {
                                      
                                        decimal[] monedas2 = { 0.05m, 0.10m, 0.20m, 0.50m, 1,2 };
                                        Dictionary<decimal, int> tuplas_2 = Inicial(MontoEntrada, monedas2);
                                        //cantidadAnterior = Convert.ToInt32(Math.Floor(MontoEntrada /2));
                                        //if (cont2 != 0)
                                        //{
                                        //    cantidadAnterior = cantidad2;
                                        //}
                                        //cont2++;
                                        if (tuplas2 > 0)
                                        {
                                            for (int i = 0; i < tuplas2; i++)
                                                Console.Write("2,");
                                            cantidad2 = tuplas2;
                                        }
                                        else {
                                            cantidad2 = -1;
                                        }
                                           
                                        MontoEntrada = MontoEntrada - cantidadAnterior * 2;
                                        bool pas_1 = false;
                                        int cont1 = 0;
                                        while (cantidad1 >= 0 && !pas_1)
                                        {

                                      
                                            decimal[] monedas1 = { 0.05m, 0.10m, 0.20m, 0.50m,1 };
                                            Dictionary<decimal, int> tuplas_1 = Inicial(MontoEntrada, monedas1);
                                            //cantidadAnterior = Convert.ToInt32(Math.Floor(MontoEntrada / 1));
                                            //if (cont1 != 0)
                                            //{
                                            //    cantidadAnterior = cantidad1;
                                            //}
                                            //cont1++;
                                            if (tuplas1 > 0)
                                            {
                                                for (int i = 0; i < tuplas1; i++)
                                                    Console.Write("1,");
                                                cantidad1 = tuplas1;
                                            }
                                            else {

                                                cantidad1 = -1;
                                            }
                                            
                                            MontoEntrada = MontoEntrada - cantidadAnterior * 1;
                                            bool pas_050 = false;
                                            int cont050 = 0;
                                            while (cantidad050 >= 0 && !pas_050)
                                            {                                                
                                                decimal[] monedas050 = { 0.05m, 0.10m, 0.20m, 0.50m };
                                                Dictionary<decimal, int> tuplas_050 = Inicial(MontoEntrada, monedas050);
                                                cantidadAnterior = Convert.ToInt32(Math.Floor(MontoEntrada / 0.50m));
                                                if (cont050 != 0)
                                                {
                                                    cantidadAnterior = cantidad050;
                                                }
                                                cont050++;
                                                if (tuplas050 > 0)
                                                {

                                                    for (int i = 0; i < tuplas050; i++)
                                                        Console.Write("0.50,");
                                                    cantidad050 = tuplas050;
                                                }
                                                else {
                                                    cantidad050 = -1;
                                                }
                                               
                                                MontoEntrada = MontoEntrada - cantidadAnterior * 0.50m;

                                                bool pas_020 = false;
                                                int cont020=0;
                                                while (cantidad020 >= 0 && !pas_020)
                                                {
                                                   
                                                    decimal[] monedas020 = { 0.05m, 0.10m, 0.20m };
                                                    Dictionary<decimal, int> tuplas_020 = Inicial(MontoEntrada, monedas020);

                                                                                                                                                         

                                                      if (tuplas020 > 0) {
                                                          for (int i = 0; i < tuplas020; i++)
                                                              Console.Write("0.20,");
                                                          cantidad020 = tuplas020;
                                                      }
                                                      else
                                                      {
                                                          cantidad020 = -1;
                                                      }
                                                      
                                                      
                                                     MontoEntrada = MontoEntrada - cantidadAnterior * 0.20m;
                                                     bool pas_010 = false;
                                                     int cont010 = 0;
                                                    while (cantidad010 >= 0 && !pas_010)
                                                    {
                                                        
                                                        decimal[] monedas010 = { 0.05m, 0.10m };
                                                        Dictionary<decimal, int> tuplas_010 = Inicial(MontoEntrada, monedas010);
                                                    

                                                        if (tuplas010 > 0)
                                                        {

                                                            for (int i = 0; i < tuplas010; i++)
                                                                Console.Write("0.10,");
                                                            cantidad010 = tuplas010;
                                                        }
                                                        else {
                                                            cantidad010 = -1;
                                                        }
                                                        
                                                           
                                                        MontoEntrada = MontoEntrada - cantidadAnterior * 0.10m;
                                                        bool pas_005 = false;
                                                        int cont005 = 0;
                                                        while (cantidad005 >= 0 && !pas_005)
                                                        {
                                                            
                                                            decimal[] monedas005 = { 0.05m};
                                                            Dictionary<decimal, int> tuplas_005 = Inicial(MontoEntrada, monedas005);
                                                            
                                                            //if (cont005 != 0)
                                                            //{
                                                            //    cantidadAnterior = cantidad005;
                                                            //}
                                                            //cont005++;
                                                            if (tuplas005 > 0)
                                                            {
                                                                for (int i = 0; i < tuplas005; i++)
                                                                    Console.Write("0.05,");

                                                                cantidad005 = tuplas005;
                                                            }
                                                            else {
                                                                cantidad005 = -1;
                                                            
                                                            }
                                                               

                                                            MontoEntrada = MontoOriginal;
                                                            pas_005 = true;
                                                            //if (cantidad010 == 0)
                                                            cantidad005 = cantidad005 - 1;
                                                            if (keyMaximo == 0.05m) {
                                                                Console.WriteLine();
                                                                pas_005 = false;
                                                            }
                                                                
                                                        }
                                                        pas_010 = true;
                                                        //if (cantidad010 == 0)
                                                            cantidad010 = cantidad010 - 1 < 0 ? 0 : cantidad010 - 1;
                                                            if (keyMaximo == 0.10m) {
                                                                Console.WriteLine();
                                                                pas_010 = false;
                                                            }
                                                            
                                                    }
                                                    pas_020 = true;
                                                    //if (cantidad010 == 0)
                                                    
                                                    cantidad020 = cantidad020 - 1 < 0 ? 0 : cantidad020 - 1;
                                                    if (keyMaximo == 0.20m) {
                                                        pas_020 = false;
                                                        Console.WriteLine();
                                                    }
                                                        

                                                }
                                                pas_050 = true;
                                                //if (cantidad010 == 0)
                                                
                                                cantidad050 = cantidad050 - 1 < 0 ? 0 : cantidad050 - 1;
                                                if (keyMaximo == 0.50m) {
                                                    Console.WriteLine();
                                                    pas_050 = false;
                                                }
                                                    
                                            }
                                            pas_1 = true;
                                            //if (cantidad010 == 0)
                                            
                                            cantidad1= cantidad1 - 1 < 0 ? 0 : cantidad1- 1;
                                            if (keyMaximo == 1) {
                                                pas_1 = false;
                                                Console.WriteLine();
                                            }
                                                
                                        }
                                        pas_2 = true;
                                        //if (cantidad010 == 0)
                                        
                                        cantidad2 = cantidad2 - 1 < 0 ? 0 : cantidad1 - 1;
                                        if (keyMaximo == 2) {
                                            pas_2 = false;
                                            Console.WriteLine();
                                        }
                                        
                                    }
                                    pas_5 = true;
                                    //if (cantidad010 == 0)
                                    
                                    cantidad5 = cantidad5 - 1 < 0 ? 0 : cantidad5 - 1;
                                    if (keyMaximo == 5) {
                                        Console.WriteLine();
                                        pas_5 = false;
                                    }
                                    
                                }
                                pas_10 = true;
                                //if (cantidad010 == 0)
                                
                                cantidad10 = cantidad10- 1 < 0 ? 0 : cantidad10 - 1;
                                if (keyMaximo == 10) {
                                    pas_10 = false;
                                    Console.WriteLine();
                                }
                                    
                            }
                            pas_20 = true;
                            //if (cantidad010 == 0)
                            
                            cantidad20 = cantidad20 - 1 < 0 ? 0 : cantidad20 - 1;
                            if (keyMaximo == 20) {
                                pas_20 = false;
                                Console.WriteLine();
                            }
                            
                        }
                        pas_50 = true;
                        //if (cantidad010 == 0)
                        
                        cantidad50 = cantidad50 - 1 < 0 ? 0 : cantidad50 - 1;
                        if (keyMaximo == 50) {
                            Console.WriteLine();
                            pas_50 = false;
                        }
                            
                    }
                    pas_100 = true;
                    //if (cantidad010 == 0)
                    
                    cantidad100 = cantidad100- 1 < 0 ? 0 : cantidad100 - 1;
                    if (keyMaximo == 100) {
                        Console.WriteLine();
                        pas_100 = false;
                    }
                        
                }
                pas_200 = true;
                //if (cantidad010 == 0)                
                
                cantidad200 = cantidad200 - 1 < 0 ? 0 : cantidad200 - 1;
                if (keyMaximo == 200) {
                    Console.WriteLine();
                    pas_200 = false;
                }
                    
            }


        
        }
    }
}
