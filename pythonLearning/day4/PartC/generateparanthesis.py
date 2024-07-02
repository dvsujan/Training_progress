class Solution:
    def generateParenthesis(self, n: int) -> List[str]:
        stack = []
        res = []

        def dfs(o, c):
            if o == c == n:
                res.append("".join(stack))
                return

            if o < n:
                stack.append("(")
                dfs(o + 1, c)
                stack.pop()
            if c < o:
                stack.append(")")
                dfs(o, c + 1)
                stack.pop()

        dfs(0, 0)
        return res