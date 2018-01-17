def AboutMe():
	me={"name": "Allyse", 
	"age": "30", 
	"birth": "The United States", 
	"sport": "hockey"}	
	
	for data in me:
		print "My", data, "is", me[data]
AboutMe()