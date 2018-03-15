from django import forms
from django.forms import ModelForm

from models import User

class RegisterForm(forms.ModelForm):
	confirm_password= forms.CharField(max_length=255)
	class Meta: 
		model= User
		fields = '__all__'

class LoginForm(forms.Form):
	email = forms.EmailField()
	password = forms.CharField(min_length=4)




