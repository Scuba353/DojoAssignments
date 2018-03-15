from django.shortcuts import render, redirect
from django.contrib import messages
# Create your views here.
from .models import User
from .forms import RegistrationForm, LoginForm

import re, bcrypt

def index(request):
	regform = RegistrationForm()
	loginform= LoginForm()
	context = { 
		"regForm": regform,
		"logForm": loginform,
		"users": User.objects.all()
	}
	return render(request, "logreg/landing.html", context)

def registrationvalid(request):
	if request.method == 'POST':
		data=RegistrationForm(request.POST)
		if data.is_valid():
			name = data.cleaned_data['name']
			alias = data.cleaned_data['alias']
			email = data.cleaned_data['email']
			password =data.cleaned_data['password']
			confirm_password = data.cleaned_data['confirm_password']
			birthdate = data.cleaned_data['birthdate']

			if password != confirm_password:
				messages.error(request, "Passwords do not match.")
				print "pw dont match"
			
			try: 
				User.objects.get(email=email)
				messages.error(request, "Email is already being used, try Login.")
				print "same email"
				return redirect('/')

			except: 
				print "you got here"
				request.session['name']=name 
				User.objects.create(name=name, 
						alias= alias, 
						email=email,
						password= bcrypt.hashpw('password'.encode(), bcrypt.gensalt()),
						birthdate=birthdate)

				return redirect('/success')

def loginvalid(request):  
	if request.method == "POST":
		email = request.POST['email']
		password = request.POST['password']
		try:
			user = User.objects.get(email=email)
		except:
			messages.error(request, 'This Email does not exist. Try Regisering as a new user')
			return redirect('/')

		if bcrypt.checkpw(password.encode(), user.password.encode()):
			request.session['name'] = user.name
			return redirect('/success')

# def success(request):
# 	return render(request, "beltexam/index.html")

def logout(request):
	return redirect('/')








