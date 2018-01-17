from flask import Flask, render_template, request, redirect, session
import random

app= Flask(__name__)
app.secret_key= "secret"

# set random number
# allow user to make a guess
# validate the guess
	#display the correct box
# allow user to guess again or restart
	# if restart reset the session num

@app.route('/')
#determine if already in session, if yes guess again, if no generate session num
def home():
	if 'randnum' in session:
		print "keep guessing"
		print session['randnum']
		return render_template('GreatNumGame.html')
	#sets random number at page render for the session
	else:
		session['randnum']= random.randrange(0, 101)
		return render_template('GreatNumGame.html', randnum= session['randnum'])

#take a guess via the form and determine if it matches to the session num
@app.route('/result', methods=['POST'])
def result():
	print "Received guess"
	guess = int(request.form['guess'])
	print guess 
	
	if guess < session['randnum']:
		session['guess']= "low"
	elif guess > session['randnum']:
		session['guess']= "high"
	elif guess == session['randnum']:
		session['guess']= "correct"

	return redirect('/')

#win/redirect to home with "restart key"/pop session
@app.route('/reset', methods=['POST'])
def dropsession():
	session.clear()
	print "dropped"
	return redirect('/')

app.run(debug= True)