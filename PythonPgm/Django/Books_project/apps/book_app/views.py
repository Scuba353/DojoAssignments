from django.shortcuts import render, HttpResponse, redirect
from .models import User, Book

# Create your views here.
def index(request):
	context = {
		"user": User.objects.all(),
		"like1": User.objects.filter(liked_by=(Book.objects.get(id=7))),
		# "like1": Book.objects.filter(liked_users=(User.objects.all())), #all books liked by user 1
		"book1": Book.objects.get(id=7),
		"like2": User.objects.filter(liked_by=(Book.objects.get(id=8))),
		"book2": Book.objects.get(id=8),
	}
	return render(request, 'book_app/index.html', context)