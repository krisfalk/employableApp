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




function displayResultsInHtml(readyResults){
    var htmlToAdd = "";
    readyResults = readyResults.forEach(getDisplayForTrack);

    function getDisplayForTrack(individual) {
      
        htmlToAdd += '<div> <input checked="unchecked" id="isSaved" type="checkbox" name="checkbox" value="{0}"/>'.replace("{0}", individual.latitude + "," + individual.longitude + "," + individual.company + "," + individual.postDate + "," + individual.city + "," + individual.state);
        htmlToAdd += '<a href="urlLink" target="_blank" id="firstA">'.replace("urlLink", individual.url) + 'title'.replace("title", individual.jobTitle) + '</a></div>';
        htmlToAdd += '<div id="city"><a href="urlCity" onclick="goToCity({0}, {1})" id="secondA">'.replace("urlCity", 'http://localhost:44172/Jobs/DisplayCity').replace("{0}", individual.longitude).replace("{1}", individual.latitude) + 'title'.replace("title", individual.city) + '</a></div>';

    }

    $('#result').html(htmlToAdd);

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

function goToCity(longitude, latitude) {
        var coordinates = latitude + "," + longitude;
        var currentUrl = 'https://api.teleport.org/api/locations/' + coordinates + '/?embed=location%3Anearest-cities%2Flocation%3Anearest-city';
        var cityName = "";
        var cityPopulation = "";
        var cityDescription = "";

        $.ajax
        ({
            type: "GET",
            url: teleportUrl,
            //dataType: "json",
            success: function (response) {
                cityName = response._embedded["location:nearest-cities"][0]._embedded["location:nearest-city"].full_name;
                cityPopulation = response._embedded["location:nearest-cities"][0]._embedded["location:nearest-city"].population;
                }
            }
        );

        currentUrl = "";
}

function saveJob() {
    var checkedBoxes = getCheckedBoxes("checkbox");
}
