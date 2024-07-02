class Solution:
    def convert(self, s: str, numRows: int) -> str:
        if(numRows ==1): 
            return s ; 
        res=""
        for r in range (numRows): 
            i = 2*(numRows-1)
            for x in range(r , len(s), i): 
                res+= s[x]
                if(r>0 and r<numRows-1 and x+i-2*r<len(s)):
                    res+=s[x+i-2*r]
        return res ; 
