

# def StdNames():
# 	students = [
#      {'first_name':  'Michael', 'last_name' : 'Jordan'},
#      {'first_name' : 'John', 'last_name' : 'Rosales'},
#      {'first_name' : 'Mark', 'last_name' : 'Guillen'},
#      {'first_name' : 'KB', 'last_name' : 'Tonel'}
# ]
# 	for value in students:
# 			print value['first_name'], value['last_name']
# StdNames()

def StdInst():
	users = {
	 'Students': [
	     {'first_name':  'Michael', 'last_name' : 'Jordan'},
	     {'first_name' : 'John', 'last_name' : 'Rosales'},
	     {'first_name' : 'Mark', 'last_name' : 'Guillen'},
	     {'first_name' : 'KB', 'last_name' : 'Tonel'}
	  ],
	 'Instructors': [
	     {'first_name' : 'Michael', 'last_name' : 'Choi'},
	     {'first_name' : 'Martin', 'last_name' : 'Puryear'}
	  ]
	 }
	for value in users:
		count=1
		print value
		for key in users[value]:
			namelen=len(key['first_name'])+len(key['last_name'])
	 		print count, key['first_name'], key['last_name'], namelen
	 		count+=1
	 		
StdInst()