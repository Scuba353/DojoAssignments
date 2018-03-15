from django.shortcuts import render, redirect, HttpResponse
from django.utils.crypto import get_random_string

## render landing page
def index(request):
	return render(request, 'words/index.html')

#set up an attempt counter
def counter(request):
	if 'counter' in request.session:
		request.session['counter'] = request.session['counter'] + 1
		print request.session['counter']
		random_word= get_random_string(length=14)
		print random_word
		request.session['random_word']= random_word
	# else:
	# 	request.session['counter']= 0
	# 	request.session['random_word'] = "no random word yet"
	return redirect('/', counter=counter, random_word=request.session['random_word'])

#clear session
def reset(request):
	for sesskey in request.session.keys():
		del request.session[sesskey]
	request.session['counter']= 0
	request.session['random_word'] = "no random word yet"
	return redirect('/')
	
		

