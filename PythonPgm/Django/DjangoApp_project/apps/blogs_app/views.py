from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
  
  # the index function is called when root is visited
def index(request):
    response = "Place holder for blogs later"
    return HttpResponse(response)

def new(request):
    response = "Place holder for a form to create a new blog"
    return HttpResponse(response)

def create(request):
    return redirect('/')

def show(request, number):
    response = "Place holder to display blog"+ number
    return HttpResponse(response)

def edit(request, number2):
    response = "Place holder to display blog"+ number
    return HttpResponse(response)

def delete(request, number):
    return redirect('/')
