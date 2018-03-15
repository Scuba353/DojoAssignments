
var express = require("express");
var session = require('express-session');
var path = require("path");
var bodyParser = require('body-parser');
var mongoose= require("mongoose");
var app = express();

app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static(path.join(__dirname, "./static")));
app.use(session({secret: 'codingdojorocks'}));
app.set('views', path.join(__dirname, './views'));
app.set('view engine', 'ejs');

mongoose.connect('mongodb://localhost/dojo_quotes');

var QuoteSchema = new mongoose.Schema({
    name: String,
    my_quote: String,
    created_at: { type: Date, default: Date.now },
   })

const Quote =mongoose.model('Quote', QuoteSchema); 

app.get('/', function(req, res) {
    res.render('index');
})

app.post('/addquote', function(req, res) {
    var quote = new Quote({name: req.body.name, my_quote: req.body.my_quote})
    quote.save(function(err){
        if(err) {
            console.log('There was an error upon submission');
        } else {
            console.log('Quote added');
            res.redirect('/');    
        }
    })
})

app.post('/results', function(req, res) {
    console.log("you made it here")
    // console.log(dojo_quotes.quotes.find({}))
    Quote.find({}, function(err, quotes){
        if (err){
            console.log("errors")
        }
        res.render('results', {allquotes: quotes});
    })
    
})

// tell the express app to listen on port 8000
app.listen(8000, function() {
 console.log("listening on port 8000");
});


