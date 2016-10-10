function setVisibility(one, two, three) {
    document.getElementById('regionQuestion').style.display = one;
    document.getElementById('stateQuestion').style.display = two;
    document.getElementById('cityFinal').style.display = three;
}

function setRegionQuestion() {
    setVisibility('', 'none', 'none');
    var html = "";

    html += '<div>';
    html += '<strong>What region would you prefer to live in the most?</strong>';
    html += '<form>';
    html += '<input type="radio" name="region" onclick="setStateQuestion(\'Pacific\')">Pacific<br>';
    html += '<input type="radio" name="region" onclick="setStateQuestion(\'Rocky Mountains\')">Rocky Mountains<br>';
    html += '<input type="radio" name="region" onclick="setStateQuestion(\'Southwest\')">Southwest<br>';
    html += '<input type="radio" name="region" onclick="setStateQuestion(\'Noncontigious\')">Noncontigious<br>';
    html += '<input type="radio" name="region" onclick="setStateQuestion(\'Northeast\')">Northeast<br>';
    html += '<input type="radio" name="region" onclick="setStateQuestion(\'Southeast\')">Southeast<br>';
    html += '<input type="radio" name="region" onclick="setStateQuestion(\'Midwest\')">Midwest<br>';
    html += '</form>';
    html += '</div>';

    $('#regionQuestion').html(html);
}

function setStateQuestion(state) {
    setVisibility('none', '', 'none');
    var html = "";

    html += '<h4>Pick which is most important to you:</h4>';
    html += '<form>'
    
    switch (state) {
        case "Pacific":
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Seafood<br>'.replace("{0}", "\'Seattle\',47.6062,-122.3321");//Seattle, WA
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Outdoor Activities<br>'.replace("{0}", "\'Eugene\',44.0521,-123.0868");//Eugene, OR
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Big City Life<br>'.replace("{0}", "\'Los Angeles\',34.0522,-118.2437");//Los Angeles, CA
            break;
        case "Rocky Mountains":
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Potatoes<br>'.replace("{0}", "\'Boise\',43.6187,-116.2146");//Boise, ID
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Gambling<br>'.replace("{0}", "\'Las Vegas\',36.1699,-115.1398");//Las Vegas, NV
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Racing<br>'.replace("{0}", "\'Salt Lake City\',40.7608,-111.8910");//Salt Lake City, UT
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Plants<br>'.replace("{0}", "\'Denver\',39.7392,-104.9903");//Denver, CO
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Rodeo\'s<br>'.replace("{0}", "\'Cheyenne\',41.1400,-104.8202");//Cheyenne, WY
            break;
        case "Southwest":
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Mexican Food<br>'.replace("{0}", "\'Phoenix\',33.4484,-112.0740");//Phoenix, AZ
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Horseback Riding<br>'.replace("{0}", "\'Dallas\',32.7767,-96.7970");//Dallas, TX
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">History<br>'.replace("{0}", "\'Oklahoma City\',35.0078,-97.0929");//Oklahoma City, OK
            break;
        case "Noncontigious":
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Cold Weather<br>'.replace("{0}", "\'Anchorage\',61.2181,-149.9003");//Anchorage, AK
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Warm Weather<br>'.replace("{0}", "\'Honolulu\',21.3069,-157.8583");//Honolulu, HI
            break;
        case "Northeast":
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Cheese Steaks<br>'.replace("{0}", "\'Philadelphia\',39.9526,-75.1652");//Philadelphia, PN
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Big City Living<br>'.replace("{0}", "\'New York City\',40.7128,-74.0059");//NYC, NY
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">History<br>'.replace("{0}", "\'Boston\',42.3601,-71.0589");//Boston, MA
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Lobster<br>'.replace("{0}", "\'Augusta\',44.3106,-69.7795");//Augusta, ME
            break;
        case "Southeast":
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Partying<br>'.replace("{0}", "\'New Orleans\',29.9511,-90.0715");//New Orleans, LA
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">City with Soul<br>'.replace("{0}", "\'Jackson\',32.2988,-90.1848");//Jackson, MI
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Music<br>'.replace("{0}", "\'Nashville\',36.1627,-86.7816");//Nashville, TN
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Fried Chicken<br>'.replace("{0}", "\'Lexington\',38.0406,-84.5037");//Lexington, KY
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">History<br>'.replace("{0}", "\'Charleston\',38.3498,-81.6326");//Charleston, WV
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Big City Living<br>'.replace("{0}", "\'Atlanta\',33.7490,-84.3880");//Atlanta, GA
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Beaches<br>'.replace("{0}", "\'Miami\',25.7617,-80.1918");//Miami, FL
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Technology<br>'.replace("{0}", "\'Raleigh\',35.7796,-78.6382");//Raleigh, NC
            break;
        case "Midwest":
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Historical Sites<br>'.replace("{0}", "\'Pierre\',44.3683,-100.3510");//Pierre, SD
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Barbaque<br>'.replace("{0}", "\'Kansas City\',39.1141,-94.6275");//Kansas City, KS
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Agriculture<br>'.replace("{0}", "\'Desmoines\',41.6005,-93.6091");//Desmoines, IA
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Bad Sports Teams<br>'.replace("{0}", "\'Minneapolis\',44.9778,-93.2650");//Minneapolis, MN
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Vehicle developement<br>'.replace("{0}", "\'Detroit\',42.3314,-83.0458");//Detroit, MI
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Beer and Cheese<br>'.replace("{0}", "\'Milwaukee\',43.0389,-87.9065");//Milwaukee, WI
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Big City Living<br>'.replace("{0}", "\'Chicago\',41.8781,-87.6298");//Chicago, IL
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Races<br>'.replace("{0}", "\'Indianapolis\',39.7684,-86.1581");//Indianapolis, IN
            html += '<input type="radio" name="city" onclick="DisplayFoundCity({0})">Hall Of Fame<br>'.replace("{0}", "\'Cleveland\',41.4993,-81.6944");//Cleveland, OH
            break;
    }
    html += '</form>';
    $('#stateQuestion').html(html);
}

function DisplayFoundCity(city, lat, lng) {
    setVisibility('none', 'none', '');
    var html = '';

    html += '<div>';
    html += '<h4>The Best City for you is <strong>{0}</strong>!'.replace("{0}", city);
    html += '</div>';
    html += '<form action="/Jobs/Details" method = "post"><input type="text" name="Latitude" value = "latitude" hidden><input type="text" name="Longitude" value = "longitude" hidden><input type="text" name="City" value = "city" hidden><input type="submit" value = "Your City Details">'
           .replace("longitude", lng)
           .replace("latitude", lat)
           .replace("city", city)
           .replace("city2", city) + '</form>';

    $('#cityFinal').html(html);
}




