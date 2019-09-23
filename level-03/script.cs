// This is a closure function https://medium.com/javascript-scene/master-the-javascript-interview-what-is-a-closure-b2f0d2152b36
(function() {
  var initialize = function() {
    /*
      1. Add all your event bindings here. Please avoid binding events inline and add your event listeners here.
      
      onSubmit callback
      disableDuplicateSecondaryDepartment callback,...
    */
      document.getElementById("dept1").addEventListener("change", disableDuplicateSecondaryDepartment);
      document.getElementById("sub").addEventListener("click", onSubmit);
  };

  var disableDuplicateSecondaryDepartment = function(event) {
    // 2. in department2, Should disable the option selected in department1
    
    var flag = document.getElementById("dept1").value;
    var i;
    for(i=0;i<4;i++)
      {    
        if(document.getElementById("dept2").options[i].value === flag)
        {
          document.getElementById("dept2").options[i].disabled = true;
          event.preventDefault();

        }
        else
        {
          document.getElementById("dept2").options[i].disabled = false;
          event.preventDefault();
        }
     
      }
  }

  var constructData = function() {
    var data = {};

    // 3. Construct data from the form here. Please ensure that the keys are the names of input elements

    data["name"]=document.getElementById("Name").value;
    data["phno"]=document.getElementById("num").value;
    data["email"]=document.getElementById("emid").value;
    data["department1"]=document.getElementById("dept1").value;
    data["department2"]=document.getElementById("dept2").value;

    return data;
  }

  var validateResults = function(data) {
    var isValid = true;

    // 4. Check if the data passes all the validations here
    
    var isValid = true;
    var name = document.getElementById("Name").value;
    if(name.length > 100)
    isValid=false;
    var num = document.getElementById("num").value;
    if(num.length>10)
    isValid=false;
    var reg=/[a-zA-Z0-9]@college.edu$/;
    var mail=document.getElementById("emid").value;
    if(reg.exec(mail)==null)
    isValid=false;

    return isValid;
  };

  var onSubmit = function(event) {
        // 5. Figure out how to avoid the redirection on form submit

    var data = constructData();

    if (validateResults(data)) {
      event.preventDefault();
      printResults(data);
    } else {
      var resultsDiv = document.getElementById("results");
      resultsDiv.innerHTML = '';
      event.preventDefault();
      resultsDiv.classList.add("hide");
    }
  };

  var printResults = function(data) {
    var constructElement = function([key, value]) {
      return `<p class='result-item'>${key}: ${value}</p>`;
    };

    var resultHtml = (Object.entries(data) || []).reduce(function(innerHtml, keyValuePair) {
      debugger
      return innerHtml + constructElement(keyValuePair);
    }, '');
    var resultsDiv = document.getElementById("results");
    resultsDiv.innerHTML = resultHtml;
    resultsDiv.classList.remove("hide");
  };

  /*
    Initialize the javascript functions only after the html DOM content has loaded.
    This is to ensure that the elements are present in the DOM before binding any event listeners to them.
  */
  document.addEventListener('DOMContentLoaded', initialize);
})();
