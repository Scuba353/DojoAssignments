import random

def ScoreGrade():
	for x in range(10):
		score=random.randint(60,100)
		if score >=90 and score <100:
			grade= "Grade is A"
		elif score >=80 and score <90:
			grade= "Grade is B"
		elif score >=70 and score <80:
			grade= "Grade is C"
		elif score >=60 and score <70:
			grade= "Grade is D"
		print "Score:", score, "and", grade
ScoreGrade()