#Write a function that simulates tossing a coin 5,000 times
#Your function should print how many times the head/tail appears.
import random

def coinToss():
	head=0
	tail=0
	for x in range(25):
		random_num = random.random()
		if round(random_num) == 0:
			result="head"
			head+=1
		elif round(random_num) == 1:
			result="tail"
			tail+=1
		print "Attempt #"+str(x)+ ": Throwing a coin... It's a "+ result+"! ... Got "+str(head)+" head(s) so far and "+str(tail)+" so far"
coinToss()
