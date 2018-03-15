# Create your views here.
from django.shortcuts import render, HttpResponse, redirect

# Create your views here.
def index(request):
	if 'word' not in request.session:
		request.session['word']= []
	return render(request, 'words_app/index.html')

def process(request):
	word= request.POST['word']
	request.session['word'].insert(0, word)
	# new_word=request.POST['word']
	# print new_word
	# if 'color' == 'red':
	# 	print "color red"
	# 	context= {
	# 	'color': red,
	# 	'word': request.POST['word']
	# 	}
	# print context
	# wordlist.append(new_word)
	print request.session['word'] 
	#append to the empty array	
	
	return redirect('/')

# def show(request):
# 	return render(request, 'index.html', context=context)

# def back(request):
# 	for sesskey in request.session.keys():
# 		del request.session[sesskey]
# 	return redirect('/')

