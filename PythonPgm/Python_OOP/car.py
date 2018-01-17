class Car(object):
	def __init__(self, price, speed, fuel, mileage, tax=0.12):
		self.cost= price
		self.fast= speed
		self.gas= fuel
		self.mile= mileage
		self.tax= tax
		
		if price >= 10000:
			tax= 0.15

		if fuel is 100:
			self.gas= "Full"
		elif fuel >50 and fuel<100:
			self.gas= "More than half full"
		elif fuel <50 and fuel>0:
			self.gas= "Less than half full"
		elif fuel is 0:
			self.gas= "Empty"

		print self
	
	# def DisplayAll(self):
	# 	print self
	# 	return self

		#__repr__ sets up self to display this way anytime its called
	def __repr__(self):
		return "<Car! price: {}, Speed: {}, Fules: {}, Mileage {}, Tax: {}>".format(self.cost, self.fast, self.gas, self.mile, self.tax)

	# def DisplayAll()
if __name__== "__main__":
	car1= Car(2000, 35, 100, 15)
	car2= Car(2000, 5, 30, 105)
	car3= Car(2000, 15, 70, 95)
	car4= Car(20000, 35, 40, 15)
	car5= Car(20004, 25, 0, 15)
