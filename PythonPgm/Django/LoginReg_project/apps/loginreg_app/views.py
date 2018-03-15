from django.shortcuts import render, redirect

from .models import User
from .forms import RegisterForm, LoginForm
import re, bcrypt

# EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')

def index(request):
  regform = RegisterForm()
  loginform= LoginForm()
  context = { 
  	"regForm": regform,
  	"logForm": loginform
  }
  return render(request, "loginreg/index.html", context)

def registervalid(request):
	print "something submitted"
	if request.path == '/register':
		R_form = RegisterForm(request.POST)
		if request.POST['password'] == request.POST['confirm_password']:
			print "you tried to register"
			# R_form = RegisterForm(request.POST)
			if R_form.is_valid():
				request.session['first_name']=request.POST['first_name']
				# password=bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt())
				User.objects.create(first_name=request.POST['first_name'], 
					last_name= request.POST['last_name'], 
					email=request.POST['email'],
					password= bcrypt.hashpw(request.POST['password'].encode(), bcrypt.gensalt()))

				print"your form is valid"
				return redirect('/success')
			else:
				print "your form is broke"
				messages=[]
				for r in R_form.errors:
					messages.append(R_form.errors[r])
				print messages
				# R_form.errors
				context={
					"regForm": R_form,
				}
				return render(request, "loginreg/index.html", context)
		else:
			print "Your passwords do not match" # messages.error
			context={
				"regForm": R_form,
			}
			return render(request, "loginreg/index.html", context)
				

def loginvalid(request):
	print "login tried"
	if request.path == '/login':
		if User.objects.filter(email=request.POST['email'], password=bcrypt.checkpw(request.POST['password'].encode(), bcrypt.gensalt()))==[]:
			return redirect('/')
		else:
			user = User.objects.get(email=request.POST['email'], password=bcrypt.checkpw(request.POST['password'].encode(), bcrypt.gensalt()))
			request.session['name'] = user.first_name
			return render(request,'loginreg/success.html')




def success(request):
	return render(request, "loginreg/success.html")
