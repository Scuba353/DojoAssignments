
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

mongoose.connect('mongodb://localhost/messagedb');

var Schema = mongoose.Schema;

var MessageSchema = new mongoose.Schema({
    name: String,
    message: String,
    comments: [{type: Schema.Types.ObjectId, ref: 'Comment'}],
   },{ timestamps: true })

var CommentSchema = new mongoose.Schema({
    _message: {type: Schema.Types.ObjectId, ref: 'Message'},
    name: String, 
    comment: String,
},{ timestamps: true })

const Message =mongoose.model('Message', MessageSchema); 
const Comment =mongoose.model('Comment', CommentSchema);

app.get('/', function(req, res) {
    Message.find({})
    .populate('comments')
    .exec(function(err, message) {
        res.render('index', {message: message});
        });
});


app.post('/addnewmessage', function(req, res) {
    var message = new Message({name: req.body.name, message: req.body.message})
    message.save(function(err){
        if(err) {
            console.log('There was an error upon submission');
        } else {
            console.log('message added');
            res.redirect('/');    
        }
    })
})


app.post('/addcomment/:id', function (req, res){
    Message.findOne({_id: req.params.id}, function(err, message){
            var thiscomment = new Comment({name: req.body.name, comment: req.body.comment});
            console.log(thiscomment)
            thiscomment._message = message._id;
            message.comments.push(thiscomment);
            thiscomment.save(function(err){
                    message.save(function(err){
                            if(err) { console.log('Error'); } 
                            else { res.redirect('/'); }
                    });
            });
        });
})

// tell the express app to listen on port 8000
app.listen(8000, function() {
 console.log("listening on port 8000");
});


