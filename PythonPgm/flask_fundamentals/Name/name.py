from flask import Flask, render_template, request, redirect
app = Flask(__name__)

@app.route('/')
def name():
    return render_template("name.html")

@app.route('/print', methods=['POST'])
def process():
	print "got post info" 
	print request.form['name']
	return redirect('/')

app.run(debug=True)