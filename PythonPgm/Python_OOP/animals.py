class Animal(object):
	def __init__(self, name, health):
		self.name=name
		self.health=health

	def __repr__(self):
		return "Animal! \nName: {}, \nHealth: {}".format(self.name, self.health)

	def walk(self, num):
		while num > 0:
			self.health= self.health - 1
			num= num - 1
		return self

	def run(self, num):
		while(num>0):
			self.health= self.health - 5
			num =num - 1
		return self

#Dog Class
class Dog(Animal):
	def __init__(self, name, health):
		super(Dog, self).__init__(name, health)
		self.health= 150

	def pet(self, num):
		while(num>0):
			self.health= self.health + 5
			num = num - 1
		return self

#Dragon Class
class Dragon(Animal):
	def __init__(self, name, health):
		super(Dragon, self).__init__(name, health)
		self.health= 170

	def fly(self, num):
		while(num>0):
			self.health= self.health -10
			num= num - 1
		print "I am a dragon!"
		return self


print Dog("bob", 75).pet(5)
