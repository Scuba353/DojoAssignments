
var express = require("express");
var session = require('express-session');
var path = require("path");
var app = express();
var bodyParser = require('body-parser');

//body parser looks at the body of a page... it looks for stuff to grab and 
//wraps it into a responce for the route to handle
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static(path.join(__dirname, "./static")));
app.use(session({secret: 'codingdojorocks'}));
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

// root route to render the index.ejs view
app.get('/', function(req, res) {
    res.render('index');
})


app.post('/result', function(req, res) {
    console.log(req.body)
    res.render('answer', {answer: req.body});
})

// tell the express app to listen on port 8000
app.listen(8000, function() {
 console.log("listening on port 8000");
});


