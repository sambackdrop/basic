
/*
	Rotate array using swap algoithm.
*/



using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Solution {



    static void Main(string[] args) {
        string[] nd = Console.ReadLine().Split(' ');

        int n = Convert.ToInt32(nd[0]);

        int d = Convert.ToInt32(nd[1]);

        int[] a = Array.ConvertAll(Console.ReadLine().Split(' '), aTemp => Convert.ToInt32(aTemp))
        ;

/*
        1,2,3,4,5,6,7  n=7, d=4 
        5,6,7,1,2,3,4    

        i= (i+d)%n 

        1,2,3,4,5,6  n=6, d=4 
        5,6,1,2,3,4    

        j = (i+d)%n

        while(j!=i)
K = 0
        0 1 2 3 4 5
     1    2 3 4 5 6   i = k=0, j = 
     1  5 2 3 4   6   i = 0, j = 4%6 = 4==>
     1  5 2   4 3 6   i = 4, j = 4+4%6 = 2 
     -  5 2 1  4 3 6   i = 2, j = 2+4%6 = 0

k= 1
     2  5   1 4 3 6    i = k = 1, j = 
     2  5 6 1 4 3      i = 1, j = (1+4)%6 = 5 
     2  5 6 1   3 4    i = 5, j = (5+4) % 6 = 3
     -                 i = 3, j = (3+4) % 6 = 1

            

*/  
        d = d%n;
        for(int k = 0; k < GCD(n, d);k++){
            int i = k, j = (i+ d)%n, t = a[i]; 
            while(j!=k){
                //Console.WriteLine($"i:{i},j:{j},a[i]:{a[i]}, a[j]:{a[j]}, nj:{(i+ d)%n}");
                a[i] = a[j];
                int p = i;
                i = j;
                j = (p+d)%n;
                  
                //Print(i,a);
            }
            a[i] = t;
            //Print(k,a);
        }


/*
        int j = d;
        for(int i = 0 ; i < n ; i++){
            if(j>=n)
                j = d;
            swap(a,i,j); 
            j++;
            //Print(i,a);
        }*/
        //Console.WriteLine();
        for(int i = 0 ; i < n ; i++){
            if(i!=0)
                Console.Write(" ");    
            Console.Write(a[i]);
        }
    }

    static int GCD(int a, int b){
        int g = 0;
        while(b > 0){
            g = a%b;
            a = b;
            b = g;
        }
        return a;

        /* 20, 12
           g = 8, a=12, b = 8
           g = 4, a = 8, b = 4
           g = 0, a = 4, b = 0

           7,4
           g = 3, a = 4, b = 3
           g = 1 , a =3, b = 1
           g = 0, a = 1, b  = 0
        */
    }

    static void Print(int i, int[] a){
        Console.Write(i+".");
        foreach(var aa in a)
            Console.Write(aa +" ");
        Console.WriteLine();
    }
    static void swap(int[] a, int idx1, int idx2){
        //Console.WriteLine($"1:{idx1}, 2:{idx2}, v1:{a[idx1]}, v2:{a[idx2]}");
        int t = a[idx1];
        a[idx1] = a[idx2];
        a[idx2] = t;
    }
}
