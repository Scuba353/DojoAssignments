# list_one = [1,2,5,6,2]
# list_two = [1,2,3,6,2]

# list_one = [1,2,5,6,5]
# list_two = [1,2,5,6,5,3]

# list_one = [1,2,5,6,5,16]
# list_two = [1,2,5,6,5]

list_one = ['celery','carrots','bread','milk']
list_two = ['celery','carrots','bread','cream']

def compareList(list1, list2):
	compare=False
	if len(list1) != len(list2):
		print "The list are not identical!"
	else:
		for x in range(len(list1)):
			if list1[x] == list2[x]:
				compare= True
			else:
				compare=False
				break
	if compare == True:
		print "The list are identical!!"
	else:
		print "The list are not identical!"

compareList(list_one, list_two)