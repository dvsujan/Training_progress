s = input("pls enter a string for all the permutataions: "); 

def permute(a, l, r): 
    if l == r: 
        print(''.join(a)); 
    else: 
        for i in range(l, r): 
            a[l], a[i] = a[i], a[l] 
            permute(a, l+1, r) 
            a[l], a[i] = a[i], a[l] 
            

n = len(s)
a = list(s)

permute(a, 0, n); 