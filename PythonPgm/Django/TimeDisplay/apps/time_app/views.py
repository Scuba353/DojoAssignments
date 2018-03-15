from django.shortcuts import render, redirect
from time import gmtime, strftime

# Create your views here.
def index(request):
	context ={
	'time': strftime("%b %d, %Y  %I:%m %p", gmtime())
	}
	return render(request, 'time_app/index.html', context)