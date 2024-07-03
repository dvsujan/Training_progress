if __name__ == '__main__':
    N = int(input())
    my_list = [] ;  
    
    for i in range(N): 
        x = input()
        command = x.split()
        comm = command[0]
        
        if comm == "insert":
            my_list.insert(int(command[1]), int(command[2]))
        
        elif comm == "append":
            my_list.append(int(command[1]))
        
        elif comm == "remove":
            my_list.remove(int(command[1]))
        
        elif comm == "pop":
            my_list.pop()
        
        elif comm == "reverse":
            my_list.reverse()
        elif comm=="sort" :
            my_list.sort(); 
        elif comm == "print":
            print(my_list)