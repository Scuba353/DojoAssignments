from flask import Flask, render_template, redirect, request, session, flash
from mysqlconnection import MySQLConnector

import re
import md5

EMAIL_REGEX = re.compile(r'^[a-zA-Z0-9.+_-]+@[a-zA-Z0-9._-]+\.[a-zA-Z]+$')
app= Flask(__name__)
app.secret_key = "KeepItSecretKeepItSafe"
mysql = MySQLConnector(app, 'users')

@app.route('/', methods=['GET'])
def home():
	return render_template('RegForm.html')

# NEW REGISTRATION VALIDATION
@app.route('/regvalid', methods=['POST'])
def regvalid():
	#logic for checing registration form

	if str.isalpha(str(request.form['first_name'])) == False or str.isalpha(str(request.form['last_name'])) == False:
		flash("First and Last Name require only alpha characters")

	if len(request.form['first_name']) < 2 or len(request.form['last_name']) < 2 : 
		flash("Name must be at least two characters")	

	if not EMAIL_REGEX.match(request.form['email']):
		flash("Invalid Email!")

	if len(request.form['password']) < 8:
		flash("Password must be at least 8 characters!")
		if (request.form['password'] != request.form['cpassword']):
			flash("Passwords do not match.")

	query2= "SELECT email FROM users WHERE email = '{}';".format(request.form['email'])
	if mysql.query_db(query2) != []:
		flash("Email is already being used by another user!")

	#upon entering valid information into the form do these things
	else: 
		flash("Successful Registration")
		first_name= request.form['first_name']
		last_name= request.form['last_name']
		email= request.form['email']
		session['currentuser']= {
		'first_name': first_name,
		'last_name': last_name,
		'email': email
		}
	
		# encpassword= md5.new(request.form['password']).hexidigest()
		query = "INSERT INTO users (first_name, last_name, email, password) VALUES (:first_name, :last_name, :email, :password)"
 		data_insert= {
 		'first_name': request.form['first_name'],
 		'last_name': request.form['last_name'],
 		'email': request.form['email'],
 		'password': request.form['password']
	 	}
	 	print data_insert
	 	mysql.query_db(query, data_insert)

		return render_template('successful.html', first_name=first_name, last_name=last_name, email=email)
	return redirect('/')

@app.route('/login', methods=['POST'])
def login():
	if not EMAIL_REGEX.match(request.form['email']):
		flash("Invalid Email!")
		return redirect('/')

	password = request.form['password']
	email = request.form['email']
	user_query = "SELECT * FROM users where users.email = :email AND users.password = :password;"
	query_data = { 'email': email, 'password': password}
	user = mysql.query_db(user_query, query_data)

	print query_data
	print len(user)

	if len(user) == 0:
		print "noone in db"
		flash("No User found!")
		return redirect('/')

	else:
		flash("Successful Login")
		first_query= "SELECT users.first_name FROM users where users.email = :email AND users.password = :password;"
		last_query= "SELECT users.last_name FROM users where users.email = :email AND users.password = :password;"
		first_name= mysql.query_db(first_query, query_data)[0]['first_name']
		last_name= mysql.query_db(last_query, query_data)[0]['last_name']
		print first_name
		session['currentuser']= {
		'first_name': first_name,
		'last_name': last_name,
		'email': request.form['email']
		}
		

		return render_template('successful.html', first_name=first_name, last_name=last_name, email=email)


app.run(debug=True)










