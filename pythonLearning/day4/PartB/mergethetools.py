def merge_the_tools(string, k):
    chunks = [string[i:i + k] for i in range(0, len(string), k)]
    for chunk in chunks:
        unique_chars = "".join(dict.fromkeys(chunk))
        print(unique_chars)
