from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
	return render(request, 'survey_app/index.html')

def process(request):
	if not 'counter' in request.session:
		request.session['name']= request.POST['name']
		request.session['location']= request.POST['location']
		request.session['language']= request.POST['language']
		request.session['comment']= request.POST['comment']
		return redirect('/result')

def show(request):
	context = {
		'name': request.session['name'],
		'location': request.session['location'],
		'language': request.session['language'],
		'comment': request.session['comment']
	}
	return render(request, 'survey_app/result.html', context=context)

def back(request):
	for sesskey in request.session.keys():
		del request.session[sesskey]
	return redirect('/')

