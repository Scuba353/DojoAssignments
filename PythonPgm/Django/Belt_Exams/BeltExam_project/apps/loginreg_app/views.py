from django.shortcuts import render, redirect
from django.contrib import messages
# Create your views here.
from .models import Traveler, TravelPlans
from .forms import RegistrationForm, LoginForm, AddTripForm

import re, bcrypt, datetime

def index(request):
	regform = RegistrationForm()
	loginform= LoginForm()
	context = { 
		"regForm": regform,
		"logForm": loginform,
		"travelers": Traveler.objects.all()
	}
	return render(request, "loginreg/index.html", context)

def registrationvalid(request):
	if request.method == 'POST':
		data=RegistrationForm(request.POST)
		if data.is_valid():
			name = data.cleaned_data['name']
			username = data.cleaned_data['username']
			password =data.cleaned_data['password']
			confirm_password = data.cleaned_data['confirm_password']

			if password != confirm_password:
				messages.error(request, "Passwords do not match.")
				print "pw dont match"
			
			try: 
				Traveler.objects.get(username=username)
				messages.error(request, "Username is already being used, try Login.")
				print "same email"
				return redirect('/')

			except: 
				print "you got here"
				Traveler.objects.create(name=name, 
						username= username, 
						password= bcrypt.hashpw(password.encode(), bcrypt.gensalt()))
				request.session['name']= Traveler.objects.last().name
				return redirect('/success')

def loginvalid(request):  
	if request.method == "POST":
		username = request.POST['username']
		password = request.POST['password']
		try:
			traveler = Traveler.objects.get(username=username)
		except:
			messages.error(request, 'This username does not exist. Try Regisering as a new user')
			return redirect('/')

		if bcrypt.checkpw(password.encode(), traveler.password.encode()):
			request.session['name'] = traveler.name
			return redirect('/success')

def success(request):

	context= {
		"mytrips": TravelPlans.objects.filter(creator=Traveler.objects.get(name=request.session['name']))| TravelPlans.objects.filter(travelers__name=request.session['name']),
		"traveler" : TravelPlans.objects.exclude(creator=Traveler.objects.get(name=request.session['name']))
	}
	return render(request, "loginreg/travel.html", context)

def logout(request):
	return redirect('/')

def addtravel(request):
	print "add travel"
	tripForm= AddTripForm()
	context = { 
		"tripForm": tripForm,
		}
	return render(request, "loginreg/addtravel.html", context)

def triprecord(request):
	print "createtravelrecord"
	# request.session['username'] = username
	if request.method == 'POST':
		trip= AddTripForm(request.POST)
		if trip.is_valid():
			destination = trip.cleaned_data['destination']
			description =trip.cleaned_data['description']
			travel_start = trip.cleaned_data['travel_start']
			travel_end = trip.cleaned_data['travel_end']

			# if travel_start< datetime.now() or travel_start >= travel_end:
			# 	messages.error(request, "Select valid date range.")
			# 	print "bad dates"
			# print "data valid"

			print "try to create record"
			TravelPlans.objects.create(destination=destination,
				travel_start=travel_start, 
				travel_end=travel_end,
				description=description,
				creator=(Traveler.objects.get(name=request.session['name'])))
			print "record created"
			return redirect('/success')
		else:
			return render(request, "nope")

def showtripinfo(request, id):
	context={
	"tripinfo": TravelPlans.objects.get(id=id),
	"others":  Traveler.objects.filter(tripper__id=id)
	}
	return render(request, "loginreg/showtrip.html", context)

def addtrip(request, id):
		join = TravelPlans.objects.get(id=id)
		join.travelers.add(Traveler.objects.get(name=request.session['name']))
		print "trip added"
		return redirect('/success')
		


# .exclude(id=Traveler.tripper.username)



