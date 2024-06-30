def is_valid_guess(guess):
    for char in guess:
        if not char.isalpha():
            return False
    return True

def main():
    print("COW BULL game")

    secret_word = input("Enter secret word: ").lower()
    if len(secret_word) != 4 or not is_valid_guess(secret_word):
        print("Not a valid guess")
        return

    print("Enter 4-letter word")
    while True:
        guess = input().lower()

        if len(guess) != 4 or not is_valid_guess(guess):
            print("Please enter a valid 4-letter word.")
            continue

        cows = 0
        bulls = 0
        secret_counts = [0] * 26
        guess_counts = [0] * 26

        for i in range(4):
            if secret_word[i] == guess[i]:
                cows += 1
            else:
                secret_counts[ord(secret_word[i]) - ord('a')] += 1
                guess_counts[ord(guess[i]) - ord('a')] += 1

        for i in range(26):
            bulls += min(secret_counts[i], guess_counts[i])

        print(f"cows - {cows}, bulls - {bulls}")

        if cows == 4:
            print("Congratulations!!! You won!")
            break

main(); 