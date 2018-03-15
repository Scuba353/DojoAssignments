from django.shortcuts import render, redirect
from django.contrib import messages
# Create your views here.
from ..logreg_app.models import User, Poke

def success(request):
	# curr_user = User.objects.filter(name=request.session['name'])
	context={
		"people_to_poke": User.objects.all(),
	}
	return render(request, "beltexam/index.html", context)

def poke(request, id):
	print id
	return redirect('/success')