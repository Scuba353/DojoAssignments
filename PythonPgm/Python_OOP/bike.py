class Bike(object):
	def __init__(self, dollars, max_speed, miles=0):
		self.price= dollars
		self.speed= max_speed
		self.miles= miles

	def displayinfo(self):
		print "Price: {} Max Speed: {} Miles: {}".format(self.price, self.speed, self.miles) 
		return self
		# another way to accomplish this
		#def __repr__(self)
			#return "<Bike! price: {}, max_speed: {}, miles {},>".format(self.price, self.speed, self.miles)
		#.format puts a variable into an object to be printed as a whole string

	def ride(self, numride):
		ride= self.miles
		for x in range(numride):
			ride+=10
		print "Riding! Total miles riden: {}".format(ride)
		return self

	def reverse(self, dist):
		rev= self.miles
		for x in range(dist):
			rev-=5
		print "Reversing! Total miles: {}".format(rev)
		return self

#three instances of the class Bike
bikeone= Bike(100, 50)
biketwo= Bike(300, 150)
bikethree= Bike(200, 75)

#print bikeone with the function display info applied to it
bikeone.reverse(5).ride(3).displayinfo() 


# What would you do to prevent negative miles?
# to prevent negative miles you could use a conditional if statement  in the reverse statemet to prevent 
# miles from going to zero. 
# Which methods can return self in order to allow chaining?
# All of the methods can return self to allow the object to be used if another method is called on it
