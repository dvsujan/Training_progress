class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
       def dfs(x ,y, dp={}): 
           k = (x , y); 
           if k in dp: 
               return dp[k]; 
           if(x == 1 and y == 1): 
               return 1 ; 
           if(x == 0 or y == 0): 
               return 0 ; 
           dp[k] = dfs(x , y-1)+ dfs(x-1, y); 
           return dp[k]; 

       return dfs(m , n); 