
import math
import os
import random
import re
import sys



if __name__ == '__main__':
    s = input()
    dic = {}; 
    for c in s : 
        if c in dic: 
            dic[c]+=1 ; 
        else: 
            dic[c] = 1; 
    dic = dict(sorted(dic.items(), key=lambda item: (-item[1], item[0])))

    x = 0 ; 
    for k , v in dic.items(): 
        if(x>=3):
            break ; 
        print(k , v)
        x+=1; 
       