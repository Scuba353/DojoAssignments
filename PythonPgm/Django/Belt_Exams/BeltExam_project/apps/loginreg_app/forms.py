from django import forms

from models import Traveler, TravelPlans

class RegistrationForm(forms.Form):
	name = forms.CharField(max_length= 45, min_length=3)
	username = forms.CharField(max_length= 45, min_length=3)
	password = forms.CharField(min_length=8)
	confirm_password = forms.CharField(min_length=8)


class LoginForm(forms.Form):
	username = forms.CharField(max_length= 45, min_length=3)
	password = forms.CharField(min_length=4)

class AddTripForm(forms.Form):
	destination= forms.CharField(max_length=45, min_length=1)
	description= forms.CharField(max_length=45, min_length=1)
	travel_start= forms.DateField()
	travel_end= forms.DateField()
	