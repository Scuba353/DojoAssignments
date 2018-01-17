#print 1-255
for x in range(1, 256):
	print x,

#print odds 1-255
for x in range(1, 256, 2):
	print x,

#ints and sum 0-255
sum=0
for x in range(256):
	sum+=x
	print x
	print sum

#itterate and print array
arr=[1,2,3,4]
for x in arr:
	print x,

#find and print max of array
arr2=[5,6,7,8]
max=arr2[0]
for x in arr2:
	if max<x:
		max=x
print max

#get and print average or array
arr3=[9,10,11,12]
sum=0
for x in arr3:
	sum+=x
print sum/len(arr3)

#create an array of odds 1-255
arr4=[]
for x in range(1, 256, 2):
	arr4+=[x]
print arr4

#square the values in an array
arr5=[1,2,3,4,5,6,7]
for x in arr5:
	x=x*x]
print arr5




