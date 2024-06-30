def LongestSubstring(s): 
    longstr = "" ; 
    st = set();
    l = 0 ; 
    for r in range(len(s)):
        while s[r] in st:
            st.remove(s[l]) ;
            l+=1 ;
        st.add(s[r]) ;
        longstr = max(longstr, s[l:r+1], key=len) ;
    return longstr ;

st = input("Enter a string: "); 
print(LongestSubstring(st)) ; 

    