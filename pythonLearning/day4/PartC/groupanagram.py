class Solution:
    def isAnagram(self, s: str, t: str) -> bool:
        sdic = {}
        for ss in s: 
            if ss in sdic:
                sdic[ss]+=1; 
            else:
                sdic[ss] = 1 ; 
        tdic = {} 
        for tt in t: 
            if tt in tdic: 
                tdic[tt]+=1 ; 
            else: 
                tdic[tt] = 1 ; 
        for ss in s: 
            if(ss not in tdic or sdic[ss] != tdic[ss]):
                return False ; 
        for tt in t: 
            if(tt not in sdic or sdic[tt]!=tdic[tt]):
                return False ; 
        return True ; 
    def groupAnagrams(self, strs: List[str]) -> List[List[str]]:
        res = []; 
        strs = sorted(strs ); 
        for s in strs: 
            ll = []
            for ss in strs: 
                if(self.isAnagram(s , ss)): 
                    ll.append(ss) ; 
                else:
                    pass ; 
            if ll not in res: 
                res.append(ll) ; 
        return res ;  