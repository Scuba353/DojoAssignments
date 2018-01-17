arr=[1, 2, 3, 4, 5]
arr2=[1, "string", 3, "Blah", 5]

#Part 1
#Create a function called draw_stars() that takes a list of numbers and prints out *.
def stars(arr): #arr= multiply([2,4,5],3) ==> [6, 12, 15]
  for x in arr:
  	print x*("*")
stars(arr)

#Part 2
def starStr(arr): 
  for x in arr:
  	if isinstance(x, str) == True:
  		x=x.lower()
  		print len(x)*(x[0])
  	elif isinstance(x, (int, float)) == True:
		print x*("*")
starStr(arr2)