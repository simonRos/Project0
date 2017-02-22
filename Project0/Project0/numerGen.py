import random, math


mlist = ""
for i in range(50):
    mlist += (random.randint(1, 60).__str__() + ",")
    print(i)

print("{" + mlist + "}")

