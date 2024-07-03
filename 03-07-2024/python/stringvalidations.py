if __name__ == '__main__':
    s = input()
    
    a = ''.join([c for c in s if c.isalnum()])
    b = ''.join([c for c in s if c.isalpha()])
    cc = ''.join([c for c in s if c.isdigit()])
    d = ''.join([c for c in s if c.islower()])
    e = ''.join([c for c in s if c.isupper()])
    
    print(a.isalnum()); 
    print(b.isalpha()); 
    print(cc.isdigit()); 
    print(d.islower()); 
    print(e.isupper()); 
