if __name__ == '__main__':
    x = int(input())
    y = int(input())
    z = int(input())
    n = int(input())
    print([[x,y,z] for x in range(a + 1) for y in range(b + 1) for z in range(c + 1) if x + y + z != n])
