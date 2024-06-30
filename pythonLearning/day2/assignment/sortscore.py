
players = [
    ("ramu", 150),
    ("bimu", 200),
    ("somu", 120),
    ("doru", 180),
    ("lalu", 170),
    ("bapu", 160),
    ("dace", 130),
    ("doremon", 110),
    ("shinchan", 140),
    ("ben10", 190),
    ("nobita", 210),
    ("raze", 100),
    ("jett", 90),
    ("omen", 80),
    ("chamber", 60)
]

sorted_players = sorted(players, key=lambda x: x[1], reverse=True)

top_10_players = sorted_players[:10]

for player in top_10_players:
    print(f"Name: {player[0]}, Score: {player[1]}")