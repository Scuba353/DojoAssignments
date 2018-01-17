l1 = ['magical unicorns',19,'hello',98.98,'world']
l2 = [2,3,1,7,4,12]
l3 = ['magical','unicorns']

def Typelist(list):
	sum=0
	string=""
	strcheck=False
	intcheck=False
	for x in list:
		if isinstance(x, str) == True:
			string+=x+' '
			strcheck=True
		elif isinstance(x, (int, float)) == True:
			sum+=x
			intcheck=True
	if strcheck is True and intcheck is True:
		print "The list you entered is mixed type"
	elif strcheck is True and intcheck is False:
		print "The list you entered is of string type"
	else:
		print "The list you entered is of integer type"

	print "The total sum is:", sum
	print "The final string is:", string
Typelist(l3)
