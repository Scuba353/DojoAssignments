
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
    var clicks=req.session.clicks
    if(clicks== undefined){
        req.session.clicks= 0
    }
 res.render('index', {clicky: clicks});
})

app.post('/clicked', function(req, res) {
    clicks= req.session.clicks ++;
    console.log(clicks);
    res.redirect('/');
})

app.post('/clicked2', function(req, res) {
    clicks= req.session.clicks +=2;
    console.log(clicks);
    res.redirect('/');
})

// tell the express app to listen on port 8000
app.listen(8000, function() {
 console.log("listening on port 8000");
});


