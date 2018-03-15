from __future__ import unicode_literals

from django.db import models

# Create your models here.
class User(models.Model):
	first_name = models.CharField(max_length=255)
	last_name = models.CharField(max_length=255)
	email = models.CharField(max_length=255)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)

class Book(models.Model):
	name = models.CharField(max_length=255)
	desc = models.CharField(max_length=255)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
	uploader = models.ForeignKey(User, related_name="loader")
	liked_users = models.ManyToManyField(User, related_name="liked_by")

	#would not allow for us to leave related_name out... Runserver required this data. 

# To add data to many to many field. 
# >>> a= User.objects.get(id=1) #set variable 
# >>> b1= Book.objects.get(id=1) #set varaible
# >>> a.liked_by.add(b1) #add user a to liked by field of book 1
# >>> a.save() #save
