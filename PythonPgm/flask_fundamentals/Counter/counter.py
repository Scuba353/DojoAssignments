from flask import Flask, render_template, request, redirect, session
app = Flask(__name__)
app.secret_key= "secret"

@app.route('/')
#renders page, needs to know has this user been to this page yet?
def home():
	#counter is the information we are holding onto... if no counter 'key' exist yet do this
	if 'counter' in session:
		print "User has been to this page before"
	#if user has never been to this page before and this is the first time it will set the counter to 100
	#after the first time at the page the session key for counter now holds 100 or some value
	else:
		print "User has never been to this page before"
		session['counter'] = 100
	#renders the html page with the new set value of counter.  For the first instance 100 and other instances whatever we determing to inc by
	return render_template("counter.html", counter=session['counter'])

@app.route('/counter')
def count():
#tells the page what to do when the link for counter is clicked. 
	session['counter']= session['counter'] + 5
	return redirect('/')

app.run(debug=True)