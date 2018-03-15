from __future__ import unicode_literals

from django.db import models

# Create your models here.
class User(models.Model):
	name= models.CharField(max_length=45)
	alias= models.CharField(max_length=45)	
	email= models.EmailField(max_length=255)
	password= models.CharField(max_length=255)
	birthdate= models.DateField()
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)

class Poke(models.Model):
	poke_send= models.ForeignKey(User, related_name="pokes_sent")
	poke_received= models.ForeignKey(User, related_name="pokes_received")
	counter= models.IntegerField(default=1)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)
