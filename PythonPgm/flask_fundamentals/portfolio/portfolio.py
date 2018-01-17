from flask import Flask, render_template  
                                          
app = Flask(__name__)                     
                                          
@app.route('/')                          
def myPortfolio():
  return render_template('myPortfolio.html')   

@app.route('/Skills') 
def Skills():
	return render_template('Skills.html')

@app.route('/aboutMe')
def aboutMe():
	return render_template('aboutMe.html')
app.run(debug=True)