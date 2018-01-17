class Product(object):
	def __init__(self, price, name, weight, brand, status="for sale"):
		self.cost=price
		self.item=name
		self.weight=weight
		self.brand=brand
		self.status=status

	def __repr__(self):
		return "Product! \nprice: {}, \nName: {}, \nweight: {}, \nbrand: {} \nstatus: {}".format(self.cost, self.item, self.weight, self.brand, self.status)

	def Sell(self):
		self.status= "sold"
		return self

	def Tax(self, tax):
		self.cost= (self.cost * tax) + self.cost
		return self

	def Return(self, reason, condition):
		self.reason= reason
		self.condition=condition
		if self.condition is "defective":
			self.status= "defective"
			self.cost=0
		elif self.condition is "open":
			self.status= "used"
			self.cost=(self.cost-(self.cost*.20))
		elif self.condition is "unopen":
			self.status="for sale"
		print "The item was returned because {}".format(self.reason)
		print self
		return self
		
		

if __name__== "__main__":
	advacado= Product(2.00, "advacado", 1.0, "HASS").Sell().Tax(.5)
	#advacado.Return("damaged", "defective")
	print advacado
