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
        jobTitle: currentItem.jobtitle,
        url: currentItem.url
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
      
      htmlToAdd += '<div> <input checked="unchecked" id="isSaved" type="checkbox" name="checkbox" value="{0}"/>'.replace("{0}", individual);
      htmlToAdd += '<a href="urlLink" target="_blank">'.replace("urlLink", individual.url) + 'title'.replace("title", individual.jobTitle) + '</a></div>';
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
function Job(JobTitle, Link) {
    this.title = JobTitle;
    this.link = Link;
}
function getCheckedBoxes(checkbox) {
    var checkBoxes = $("#result div input");
    var isChecked = checkBoxes.map((x) => { return checkBoxes[x].checked });
    var links = $("#result div a");

    var jobs = links.map((x) => { return { 'Job' : new Job(links[x].text, links[x].href) }});
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

function saveJob() {
    var checkedBoxes = getCheckedBoxes("checkbox");
    document.getElementById("save").style.display = "none";
    document.getElementById("submit").style.display = "block";
}
