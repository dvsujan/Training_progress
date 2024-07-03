if __name__ == '__main__':
    n = int(input())
    arr = map(int, input().split()); 
    arr = list(arr)
    arr.sort(reverse=True); 
    for i in range(len(arr)): 
        if(arr[i] == arr[i+1]): 
            pass; 
        else:
            print(arr[i+1]) ;
            break ; 
