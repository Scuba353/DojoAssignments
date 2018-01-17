#Odd/Even
def oddEven(start, end):
	for x in range(start, end):
		if x%2 == 0:
			print "Number is", x, " This is an even number."
		else:
			print "Number is", x, " This is an odd number."
oddEven(1,4)

#Multiply
a=[2,4,10,16]
def multiply(l1,num):
	for x in range(len(l1)):
		l1[x]*=num
	return l1
multiply(a,5)

#hacker challenge- write a function that takes the multiply function call as an argument
#new function should return the multiplied list as a two-dimensional list of 1s
def layered_multiples(arr): #arr= multiply([2,4,5],3) ==> [6, 12, 15]
  new_array=[]
  for x in arr:
  	print x
  	new_array.append([1]*x)
  	print new_array
#   return new_array
layered_multiples(multiply([2,4,5],3)) #layered_multiples([6,12,15])


