module.exports = function (){
    return {
      add: function(num1, num2) { 
        var total= num1 + num2
        return console.log(total)   
        // add code here 
      },
      multiply: function(num1, num2) {
        var total= num1 * num2
        return console.log(total) 
      },
      square: function(num) {
        var total= num * num
        return console.log(total) 
      },
      random: function(num1, num2) {
        var val= Math.floor(Math.random()*num2)+num1
        return console.log(val) 
      }
    }
  };