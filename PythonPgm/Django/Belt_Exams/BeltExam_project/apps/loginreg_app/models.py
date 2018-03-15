from __future__ import unicode_literals

from django.db import models

# Create your models here.


class Traveler(models.Model):
	name= models.CharField(max_length=45)
	username= models.CharField(max_length=45)	
	password= models.CharField(max_length=255)
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)

class TravelPlans(models.Model):
	destination= models.CharField(max_length=45)
	travel_start= models.DateField()	
	travel_end= models.DateField()
	description= models.CharField(max_length=255)
	travelers= models.ManyToManyField(Traveler, related_name="tripper")
	creator= models.ForeignKey(Traveler, related_name="created_by")
	created_at = models.DateTimeField(auto_now_add=True)
	updated_at = models.DateTimeField(auto_now=True)