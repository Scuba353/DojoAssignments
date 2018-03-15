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
	return render(request, "logreg/index.html", context)

def registrationvalid(request):
	if request.method == 'POST':
		data=RegistrationForm(request.POST)
		if data.is_valid():
			first_name = data.cleaned_data['first_name']
			last_name = data.cleaned_data['last_name']
			email = data.cleaned_data['email']
			password =data.cleaned_data['password']
			confirm_password = data.cleaned_data['confirm_password']

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
				request.session['first_name']=first_name 
				User.objects.create(first_name=first_name, 
						last_name= last_name, 
						email=email,
						password= bcrypt.hashpw('password'.encode(), bcrypt.gensalt()))

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

		if bcrypt.checkpw('password'.encode(), user.password.encode()):
			request.session['first_name'] = user.first_name
			return redirect('/success')

def success(request):
	return render(request, "logreg/success.html")

def logout(request):
	return redirect('/')








