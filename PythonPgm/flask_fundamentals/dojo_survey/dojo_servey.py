from flask import Flask, render_template, request, redirect
app = Flask(__name__)

@app.route('/')
def home():
	return render_template('dojo_survey.html')

@app.route('/results', methods=['POST'])
def resutls():
	print "Info Received"
	return render_template('results.html', name = request.form['name'], location = request.form['location'], language = request.form['language'], comment = request.form['comment'])

app.run(debug=True)