
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

mongoose.connect('mongodb://localhost/otters');

var OtterSchema = new mongoose.Schema({
    name: String,
    pack_details: String,
    created_at: { type: Date, default: Date.now },
   })

const Otter =mongoose.model('Otter', OtterSchema); 

//shows all animals in db
app.get('/', function(req, res) {
    Otter.find({}, function(err, animals){
        if (err){
            console.log("errors")
        }
    res.render('index', {allanimals: animals});
    })
})

//renders form to add a new animal
app.post('/addnew', function(req, res) {
    res.render('add');
})

//adds new animal to db
app.post('/add', function(req, res) {
    var animal = new Otter({name: req.body.name, pack_details: req.body.pack_details})
    animal.save(function(err){
        if(err) {
            console.log('There was an error upon submission');
        } else {
            console.log('animal added');
            res.redirect('/');    
        }
    })
})

//shows details on a single animal
app.get('/show/:id', function(req, res) {
    Otter.findById(req.params.id, function(err, animals){
        if (err){
            console.log("errors")
        }
    res.render('show', {animals: animals});
    })
})

//edit details on a single animal
app.get('/update/:id', function(req, res) {
    Otter.findById(req.params.id, function(err, animals){
        if (err){
            console.log("errors")
        }
    res.render('edit', {animals: animals});
    })
})

//update the single animal info
app.post('/updaterecord/:id', function(req, res) {
    Otter.findByIdAndUpdate(req.params.id, { $set: {name: req.body.name, pack_details: req.body.pack_details}},{new: true},  function(err){
        if (err){
            console.log("errors")
        }
    res.redirect('/');
    })
})


//delete a single animal
app.get('/delete/:id', function(req, res) {
    Otter.remove({_id: req.params.id},  function(err){
        if (err){
            console.log("errors")
        }
        else{
            console.log("it should work")
        }
    res.redirect('/');
    })
})









// tell the express app to listen on port 8000
app.listen(8000, function() {
 console.log("listening on port 8000");
});