

$('#btnSubmit').on('click', function () {
  var arr = []; // take an array to store values
  $('input[type="radio"]:checked').each(function(){
   arr.push($(this).val());  //push values in array
  });

  if(arr.length < 20) alert(" You need to answer all the questions.");
  console.log(arr);
});