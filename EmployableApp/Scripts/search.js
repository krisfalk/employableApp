//parameters needs to be an object



function keyWordSearch(){
    var encodedParameters;

    if ($('#search-input').val() != "") {
        encodedParameters = handleParameters();
    }
    var url= "http://api.indeed.com/ads/apisearch?publisher=6943012943597582&format=json&" + encodedParameters + "&sort=&radius=&st=&jt=&start=&limit=&fromage=&filter=&latlong=1&co=us&chnl=&userip=1.2.3.4&useragent=Mozilla/%2F4.0%28Firefox%29&v=2";
    $('head').append('<script src="' + url + '"></script>');

}

function handleParameters(){
    var searchInput = $('#search-input').val();
    var filterInput = $('#city-state-input').val();

    var parameters = {
        q: searchInput,
        l: filterInput,
        callback: 'handleReturnResults'
    }

//can do a bunch of ifs for different filter input

  parameters = encode(parameters);
  return parameters;
}


function encode(parameters) {
  var encodedInput = '';

  for (var key in parameters) {
    encodedInput += encodeURIComponent(key) + '=' + encodeURIComponent(parameters[key]) + '&';
  }
  if (encodedInput.length != 0) {
    encodedInput = encodedInput.slice(0,  -1);
  }

  return encodedInput;
}


function handleReturnResults(totalResults) {
  console.log(totalResults);
  var rawResults = totalResults.results;
  var readyResults = [];

  for (var i = 0; i < rawResults.length; i++) {
    var currentItem = rawResults[i];
    var individualResult = {
        jobTitle : currentItem.jobtitle,
        url : currentItem.url,
        company : currentItem.company,
        latitude : currentItem.latitude,
        longitude : currentItem.longitude,
        postDate : currentItem.date,
        city : currentItem.city,
        state : currentItem.state
    };
    readyResults[i] = individualResult;

  }

  if (readyResults.length != 0) {

      displayResultsInHtml(readyResults);
      $('#myTableBody').pageMe({pagerSelector:'#myPager',showPrevNext:true,hidePageNumbers:false,perPage:10});
    }
    else {
      $('#display-message').html("I'm sorry, your search yielded no results. Please try again with other key words.");
    }

}


var lat = "";
var lng = "";

function displayResultsInHtml(readyResults){
    var htmlToAdd = "";
    readyResults = readyResults.forEach(getDisplayForTrack);

    function getDisplayForTrack(individual) {
      
        htmlToAdd += '<div> <input checked="unchecked" id="isSaved" type="checkbox" name="checkbox" value="{0}"/>'.replace("{0}", individual.latitude + "," + individual.longitude + "," + individual.company + "," + individual.postDate + "," + individual.city + "," + individual.state);
        htmlToAdd += '<a href="urlLink" target="_blank" id="firstA">'.replace("urlLink", individual.url) + 'title'.replace("title", individual.jobTitle) + '</a></div>';
        htmlToAdd += '<div id="city"><a href="" onclick="setLatLng({1}, {0})" id="secondA">'.replace("urlCity", 'http://localhost:44172/Jobs/DisplayCity').replace("{0}", individual.longitude).replace("{1}", individual.latitude).replace("{3}", individual.city) + '{2}'.replace("{2}", individual.city) + '</a></div>';

    }

    $('#result').html(htmlToAdd);

}

//function setLatLng(latitude, longitude) {
//    Html.Partial("DisplayCity", new{lat:latitude, lng:longitude});
//}

function Coordinates(myLatitude, myLongitude, myCityName) {
    this.latitude = myLatitude;
    this.longitude = myLongitude;
    this.city = myCityName;
}
function setLatLng(latitude, longitude) {
    var coords = new Coordinates(latitude.toString(), longitude, "Phish");
    $.ajax({
        type: "POST",
        url: "http://localhost:44172/Jobs/Details",
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(coords)
    });
}

function sortBySortInput(readyResults, typeChoice)
{
  if($('#sort-choice').val() == "noFilter"){
    typeChoice = $('#filter').val();
  }

  sortedResults = readyResults.sort(compare);
  return sortedResults;

  function compare(a, b){

    if (a[typeChoice] < b[typeChoice])
      return -1;
    if (a[typeChoice] > b[typeChoice])
      return 1;
    return 0;
  }
}

function getCheckedBoxes(checkbox) {
 
    var checkBoxes = $("#result div input");
    var isChecked = checkBoxes.map((x) => { return checkBoxes[x].checked });
    var links = $("[id=firstA]");

    var jobs = links.map((x) => { return { 'JobTitle': links[x].text, 'Link': links[x].href, 'Information' : checkBoxes[x].defaultValue }});
    var checkedJobs = [];
    for (var i = 0; i < isChecked.length; i++) {
        if (isChecked[i]) {
            checkedJobs.push(jobs[i])
        }
    }
    $.ajax({
        type: "POST",
        url: "http://localhost:44172/Jobs/SaveJobs",
        dataType: 'json',
        contentType: 'application/json',
        data: JSON.stringify(checkedJobs)
    });
}

function goToCity() {
    var coordinates = lat + "," + lng;
    var currentUrl = 'https://api.teleport.org/api/locations/' + coordinates + '/?embed=location%3Anearest-cities%2Flocation%3Anearest-city';
    var cityNameFull = "";
    var cityNameShort = "";
    var cityPopulation = "";
    var cityDescription = "";
    var html = "";
        
    $.ajax
    ({
        type: "GET",
        url: currentUrl,
        //dataType: "json",
        success: function (response) {
            alert(response._embedded["location:nearest-cities"][0]._embedded["location:nearest-city"].full_name);
            cityNameFull = response._embedded["location:nearest-cities"][0]._embedded["location:nearest-city"].full_name;
            alert(response._embedded["location:nearest-cities"][0]._embedded["location:nearest-city"].name);
            cityNameShort = response._embedded["location:nearest-cities"][0]._embedded["location:nearest-city"].name;
            alert(response._embedded["location:nearest-cities"][0]._embedded["location:nearest-city"].population);
            cityPopulation = response._embedded["location:nearest-cities"][0]._embedded["location:nearest-city"].population;

            var html = '<div id="city"><h3>{0}</h3></div>'.replace("{0}", cityNameFull);

            $('#cityName').html(html);
       }
    }
    );
    //var keyword = city;
    //var currentUrl2 = 'http://en.wikipedia.org/w/api.php?action=query&prop=extracts&format=json&exintro=&titles=' + keyword;

    //$.ajax
    //    ({
    //        type: "GET",
    //        url: currentUrl2,
    //        //dataType: "json",
    //        success: function (response) {
    //            alert(response);
    //        }
    //    }
    //    );
}
//function SetDescription(name) {
//    var keyword = name;
//    var currentUrl2 = 'http://en.wikipedia.org/w/api.php?action=query&prop=extracts&format=json&exintro=&titles=' + keyword;

//    $.ajax
//        ({
//            type: "GET",
//            url: currentUrl2,
//            //dataType: "json",
//            success: function (response) {
//                alert(response);
//            }
//        }
//        );
//}

function saveJob() {
    var checkedBoxes = getCheckedBoxes("checkbox");
}
