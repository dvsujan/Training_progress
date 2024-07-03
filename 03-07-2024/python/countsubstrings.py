def count_substring(string, sub_string):
    l = 0 ; 
    r = len(sub_string); 
    res = 0 ; 
    while r <= len(string):
        if(string[l:r] == sub_string):
            res+=1 ; 
        r+=1 ; 
        l+=1 ; 
    
    return res ; 
        