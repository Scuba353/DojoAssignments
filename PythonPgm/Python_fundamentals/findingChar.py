word_list = ['hello','world','moy','name','is','Anna']
char = 'o'
new_list=[]

def findChar(givelist):
	for x in range(len(givelist)):
		if char in givelist[x]:
			new_list.append(givelist[x])
	print new_list
findChar(word_list)