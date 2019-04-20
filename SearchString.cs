

/*
	Search string using KMP algorithm.
*/


public class Solution {
    public int StrStr(string haystack, string needle) {
        
        return DoMatch(haystack, needle);
    }
    
    private int DoMatch(string str, string pat){
        int ret = -1;
        int N = str.Length;
        int M = pat.Length;
        
        List<int> matchIndex = new List<int>();
        
        if(M == 0)
            ret = 0;
        else if(N==0 && M > 0)
            ret = -1;
        else{
        
        int[] T = ConstructTable(pat,M);
        
        for(int i = 0, j = 0;i < N ;i ++){
            if(str[i]== pat[j]) 
                j++;
            else{
                while(j>0){
                    j = T[j-1];
                    if(str[i] == pat[j]){
                        j++;
                        break;
                    }
                }
            }
            
            if(j==M){
                ret = i-(j-1);
                //matchIndex.Add(ret);
                //j = T[j-1];
                break; //uncomment for all appearance
            }
        }    
            
            //ret = matchIndex.Count()>0? matchIndex[0]:-1;
        
            foreach(var m in matchIndex){
                Console.Write($"{m} ");
            }
        
        }
      
        
        
        return ret;
    }
    
    private int[] ConstructTable(string W, int M){
        int[] T = new int[M];
        T[0] = 0;
        
        for(int i = 1 ; i < M ; i ++){
            int L = T[i-1];
            
            while(L>0 && W[i] != W[L])
                L = T[L -1];
            if(W[i] == W[L])
                L++;
            T[i] = L;
        }
        
        return T;
    }
}