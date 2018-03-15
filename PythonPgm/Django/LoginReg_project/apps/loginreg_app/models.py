from __future__ import unicode_literals
from django.core.exceptions import ValidationError

from django.db import models

def validateGTtwo(value):
   if len(value) < 3:
   		raise ValidationError('First and Last name must be longer than two characters')

# def validatePW(value):
# 	if value != password:
# 		raise ValidationError('Password and Confirm Password do not match')

def validateGTfour(value):
   if len(value) < 5:
   		raise ValidationError('Password must be longer than four characters')


# Create your models here.
class User(models.Model):
	first_name= models.CharField(max_length=45, validators=[validateGTtwo])
	last_name= models.CharField(max_length=45, validators=[validateGTtwo])	
	email= models.EmailField(max_length=255)
	password= models.CharField(max_length=255, validators=[validateGTfour])
	# confirm_password= models.CharField(max_length=255)


	

