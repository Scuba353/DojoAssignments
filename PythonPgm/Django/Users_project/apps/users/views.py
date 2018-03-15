from django.shortcuts import render

# Create your views here.
def index(request):
	context ={
		"users": users.objects.all(), #all users in table
		# "users": users.objects.last() #last user
		# "users": users.objects.create({{first_name}}="{{value}}", {{last_name}}="{{value}}", {{email}}="{{value}}", {{age}}="{{value}}",{{created_at}}="{{value}}", {{updated_at}}="{{value}}") #create a user
		# "users": users.objects.first() #first user
		# "users": users.objects.order_by('-first_name') # users ordered decending by first name
		# in shell --> u= users.objects.get(id=3)  u.name= "JEFF" u.save()
		# in shell -->users.objects.get(id=4).delete() #delete user who has ID 4
		
	}
