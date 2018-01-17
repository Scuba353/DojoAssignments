#find and replace
words = "It's thanksgiving day. It's my birthday,too!"
words.find("day")
print words.find("day")
import string 
new_str= string.replace(words, "day", "month", 1)
print new_str

#min and max
x = [2,54,-2,7,12,98]
print min(x)
print max(x)
y= ["ZAllysez", "Brian", 100, "Mags", 50, "Ruben", -3]
print min(y)
print max(y)

#first and last
newy=[]
y = ["hello",2,54,-2,7,12,98,"world"]
print y[0]
print y[len(y)-1]
newy.append(y[0])
newy.append(y[len(y)-1])
print newy

#new list
z = [19,2,54,-2,7,12,98,32,10,-3,6]
z.sort()
print z
print len(z)/2
zz= z[:5]
print zz
del z[:5]
print z
z.insert(0, zz)
print z