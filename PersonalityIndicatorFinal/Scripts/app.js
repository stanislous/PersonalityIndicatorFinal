

$('#btnSubmit').on('click', function () {
  var arr = []; // take an array to store values
  $('input[type="radio"]:checked').each(function(){
   arr.push($(this).val());  //push values in array
  });
  console.log(arr);
});