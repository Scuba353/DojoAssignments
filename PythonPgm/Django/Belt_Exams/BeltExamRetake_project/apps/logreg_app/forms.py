from django import forms

from models import User


class RegistrationForm(forms.Form):
	name = forms.CharField(max_length= 45, min_length=2)
	alias = forms.CharField(max_length= 45, min_length=2)
	email = forms.EmailField()
	password = forms.CharField(min_length=4)
	confirm_password = forms.CharField(min_length=4)
	birthdate= forms.DateField()


class LoginForm(forms.Form):
	email = forms.EmailField()
	password = forms.CharField(min_length=4)