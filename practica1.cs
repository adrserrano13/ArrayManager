using System;
using System.Collections.Generic;

namespace Practica.DINT
{

    class VectorEnteros{

      private  int[] vector = new int[0];
      private enum direccion {asc = 1, desc = 2};
      private bool error;
      private int cont=-1;
      private enum direccion2 {izq = 1, der = 2};
      int cod_error=0;

      //INSERTAR AL FINAL
      public void insertar(int n){

        Array.Resize(ref vector,vector.Length + 1);
        vector[vector.Length - 1] = n;
        error = false;
      }
      //INSERTAR CON POSICION
      public void insertar(int n1,int n2){

          if (n2 < vector.Length){

              Array.Resize(ref vector,vector.Length + 1);
              int posicion = n2;

              for (int i=vector.Length-1; i>posicion; i--)
                 vector[i] = vector[i-1];
                 vector[posicion] = n1;
                error = false;
           }
           else
            insertar(n1);
          error = false;

      }
      //MOSTRAR VECTOR
      public void mostrar(){

        if(vector.Length > 0){
          Console.WriteLine("\n-----vector----");
          foreach(int x in vector)
            Console.Write(x + " ");

          error = false;
        }
        else{
          error = true;
          cod_error = 1;
        }
      }
      //BORRAR POSICION
      public void borrar(int n){

        if(vector.Length > 0){
          if(n < vector.Length){
            for(int i = n; i<vector.Length-1; i++)
              vector[i]=vector[i+1];

            Array.Resize(ref vector,vector.Length -1);
            error = false;
          }
          else{
            Console.Write("ERROR!!");
            error = true;
            cod_error = 2;
          }
        }
        else{
          Console.Write("ERROR!!");
          error = true;
          cod_error = 1;
        }

      }
      //BUSCAR POR POSICION
      public void posicion(int n){

        if(vector.Length > 0){
          if(n < vector.Length){

            for(int i = 0; i<vector.Length; i++){

              if(i == n){
                Console.WriteLine("En la posicion {0} esta en valor: {1}", n,vector[i]);
                error = false;
              }
            }
          }
          else{
            Console.WriteLine("ERROR!!");
            error = true;
            cod_error = 3;
          }
        }
        else{
          Console.WriteLine("ERROR!!");
          error = true;
          cod_error = 1;
        }
      }
      //BUSCAR MAYOR ELEMENTO
      public void mayorElem(){

        if(vector.Length > 0){
          int max = -1;
          for(int i = 0; i<vector.Length; i++){

            if(vector[i] > max)
              max = vector[i];
          }
          Console.WriteLine("\nEl valor máximo del array es {0}",max);
          error = false;
        }
        else{
          Console.WriteLine("ERROR!!");
          error = true;
          cod_error = 1;
        }
      }
      //BUSCAR MENOR ELEMENTO
      public void menorElem(){

        if(vector.Length > 0){
          int min = 1111111111;
          for(int i = 0; i<vector.Length; i++){

            if(vector[i] < min)
              min = vector[i];
          }
          Console.WriteLine("\nEl valor máximo del array es {0}",min);
          error = false;
        }
        else{
          Console.WriteLine("ERROR!!");
          error = true;
          cod_error = 1;
        }

      }
      //ORDENAR ASC/DESC
      public void ordenar(int n){

        if(vector.Length > 0){
          if(n == (int)direccion.asc){

              Array.Sort(vector);
          }
          else if(n == (int)direccion.desc){

            Array.Sort(vector);
            Array.Reverse(vector);
            error = false;
          }
          else{
            Console.WriteLine("ERROR!!");
            error = true;
            cod_error = 4;
          }
        }
        else{
          Console.WriteLine("ERROR!!");
          error = true;
          cod_error = 1;
        }

      }
      //HAY ERROR?
      public void hayError(){

        if(error == true)
          Console.WriteLine("Ha habido un error");
        else
          Console.WriteLine("No ha habido ningun error");
      }
      //PRIMERO
      public int primero(){

        if(vector.Length > 0){

            error = false;
            return vector[0];

        }
        else{
          Console.WriteLine("ERROR!!");
          cod_error = 1;
          error = true;
          return -1;

        }

      }
      //SIGUIENTE
      public int siguiente(){

        if(vector.Length > 0){
          if( vector.Length - 1 > cont){
            cont++;
            error = false;
            return vector[cont];
          }
          else{

            error = true;
            cod_error = 3;
            Console.WriteLine("ERROR!!");
            return -1;
          }

        }
        else{
          Console.WriteLine("ERROR!!");
          error = true;
          return -1;

        }

      }
      //INVERTIR
      public void invertir(){
        if(vector.Length > 0){
          int j = 0;
          int[] aux = new int[vector.Length];
          for(int i =vector.Length-1; i>=0;i--){

              aux[j] = vector[i];
              j++;
          }
          Console.WriteLine("\n-----vector----");
          foreach(int u in aux)
            Console.Write(u + " ");
          error = false;
        }
        else{
          Console.WriteLine("ERROR!!");
          cod_error = 1;
          error = true;
        }

      }
      //ROTAR
      public void rotar(int n1){

        if(vector.Length > 0){

          if(n1 == (int) direccion2.izq){

            int aux = vector[0];
            for(int i = 0; i<vector.Length-1;i++)

              vector[i] = vector[i+1];

            vector[vector.Length-1] = aux;

            foreach(int x in vector)
              Console.Write(x + " ");
              error = false;
          }
          else if(n1 == (int) direccion2.der){


            for(int i = 0; i<vector.Length-1;i++){

                int aux = vector[i+1];
                vector[i+1] = vector[0];
                vector[0] = aux;
            }

            foreach(int x in vector)
              Console.Write(x + " ");
              error = false;
          }
          else{
            Console.WriteLine("ERROR!!");
            cod_error = 4;
            error = true;
          }
        }
        else{
          Console.WriteLine("ERROR!!");
          error = true;
          cod_error = 1;
        }

    }
    //codError
    public void codError(){

      if(cod_error == 0)
        Console.WriteLine("No han habido errores hasta ahora");
      else
        Console.WriteLine("EL codigo de error es {0}" ,cod_error);
    }
    //MENSAJE ERROR
    public void mensajeError(){

      switch(cod_error){

        case 1: Console.WriteLine("ERROR1: El array está vacio");break;
        case 2: Console.WriteLine("ERROR2: Se ha intentado borrar una posición que no existe en el array");break;
        case 3: Console.WriteLine("ERROR3: Se ha intentado acceder a una posición en el array que no existe");break;
        case 4: Console.WriteLine("ERROR4: No has introducido un numero correcto(Solo puedes introducir 1 0 2)");break;

      }
    }

      //INICIO DEL MAIN
      public static void Main(string[] args){

        VectorEnteros vecEnteros = new VectorEnteros();
        int valor;
        string s = "y";

        //MENU
        do{

          Console.WriteLine("\n\n");
          Console.WriteLine("1-Insetar al final");
          Console.WriteLine("***********************");
          Console.WriteLine("2-Insetar con posicion");
          Console.WriteLine("***********************");
          Console.WriteLine("3-Mostrar");
          Console.WriteLine("***********************");
          Console.WriteLine("4-Borrar");
          Console.WriteLine("***********************");
          Console.WriteLine("5-Buscar por posicion");
          Console.WriteLine("***********************");
          Console.WriteLine("6-Valor máximo");
          Console.WriteLine("***********************");
          Console.WriteLine("7-Valor mínimo");
          Console.WriteLine("***********************");
          Console.WriteLine("8-Ordenar");
          Console.WriteLine("***********************");
          Console.WriteLine("9-¿Ha habido algun error con el ultimo método usado?");
          Console.WriteLine("***********************");
          Console.WriteLine("10-Ver primer elemento del array");
          Console.WriteLine("***********************");
          Console.WriteLine("11-Ver siguiente elemento del array");
          Console.WriteLine("***********************");
          Console.WriteLine("12-Invertir");
          Console.WriteLine("***********************");
          Console.WriteLine("13-Rotar");
          Console.WriteLine("***********************");
          Console.WriteLine("14-Ver codigo de error");
          Console.WriteLine("***********************");
          Console.WriteLine("15-Ver mensaje de error");
          Console.WriteLine("***********************");

          Console.WriteLine("¿Que quieres hacer?");
          bool numero = Int32.TryParse(Console.ReadLine(), out valor);

          if(numero == true){

            switch (valor) {
              //INSERTAR AL FINAL
              case 1:
                int n;
                Console.WriteLine("\nIntroduce un numero para el array:");
                numero = Int32.TryParse(Console.ReadLine(),out n );
                if(numero == true)
                  vecEnteros.insertar(n);
                else
                  Console.WriteLine("ERROR -> No has introducido un numero");
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;
              //INSERTAR CON POSICION
              case 2:
                int n1,n2;
                Console.WriteLine("\nIntroduce un numero para el array:");
                numero = Int32.TryParse(Console.ReadLine(),out n1);
                if(numero == true){
                  Console.WriteLine("\nIntroduce una posicion");
                  numero = Int32.TryParse(Console.ReadLine(),out n2);
                  if(numero == true)
                    vecEnteros.insertar(n1,n2);
                  else
                    Console.WriteLine("ERROR -> No has introducido un numero");
                }
                else
                  Console.WriteLine("ERROR -> No has introducido un numero");
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;
              //MOSTRAR
              case 3:
                vecEnteros.mostrar();
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;
              //BORRAR
              case 4:
                int n3;
                Console.WriteLine("\nIntroduce una posicion a borrar");
                numero = Int32.TryParse(Console.ReadLine(),out n3);
                if(numero == true)
                  vecEnteros.borrar(n3);
                else
                  Console.WriteLine("ERROR -> No has introducido un numero");
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;

              //BUSCAR POR POSICION
              case 5:
                int n4;
                Console.WriteLine("\nIntroduce una posición para ver su valor");
                numero = Int32.TryParse(Console.ReadLine(),out n4);
                if(numero == true)
                  vecEnteros.posicion(n4);
                else
                  Console.WriteLine("ERROR -> No has introducido un numero");
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;

              //VALOR MAXIMO
              case 6:
                vecEnteros.mayorElem();
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;

              //VALOR MINIMO
              case 7:
                vecEnteros.menorElem();
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;

              //ORDENACION
              case 8:
                int n5;
                Console.WriteLine("Introduce un 1 para ordenar ascendente o un 2 para ordenar descendente");
                numero = Int32.TryParse(Console.ReadLine(),out n5);
                if(numero == true){
                  if(n5 == 1 || n5 == 2)
                    vecEnteros.ordenar(n5);
                  else
                    Console.WriteLine("ERROR -> Solo tienes la opción de usar los valores 1 y 2");
                }
                else
                  Console.WriteLine("ERROR -> No has introducido un numero");
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;

              //ERROR?
              case 9:
                vecEnteros.hayError();
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;

              //PRIMERO
              case 10:
                Console.WriteLine(vecEnteros.primero());
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;

              //SIGUIENTE
              case 11:
                Console.WriteLine("\nSiguiente elemento: {0}" ,vecEnteros.siguiente());
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;

              //INVERTIR
              case 12:
                vecEnteros.invertir();
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;
              //ROTAR
              case 13:
                int n6;
                Console.WriteLine("1 para rotar a la izquierda, 2 para rotar a la derecha");
                numero = Int32.TryParse(Console.ReadLine(),out n6);
                if(numero == true)
                  vecEnteros.rotar(n6);
                else
                  Console.WriteLine("ERROR -> Solo tienes la opción de usar los valores 1 y 2");
                Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
                s = Console.ReadLine();break;
            //cod_error
            case 14:
              vecEnteros.codError();
              Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
              s = Console.ReadLine();break;
            //MSG ERROR
            case 15:
              vecEnteros.mensajeError();
              Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
              s = Console.ReadLine();break;

            }//FIN SWITCH
            }else{
              Console.WriteLine("No has introducido un numero");
              Console.WriteLine("\n\ny para continuar(cualquier otra para cerra programa)");
              s = Console.ReadLine();
            }
          }while(string.Equals(s,"y"));//FIN WHILE

        Console.WriteLine("BYE");
      }//FIN MAIN
    }//FIN CLASS

}//FIN NS
