$(document).ready(function() {

        $('#calendar').fullCalendar({
        // put your options and callbacks here
            weekends: false,
            height: 500,
            editable: true,
            cache: true,
            events: [
                {
                    id: 1,
                    title  : 'Applied for job',
                    start  : '2016-10-05',
                    editable: false
                },
                { 
                    id: 2,
                    title  : 'Send follow-up email',
                    start  : '2016-10-12',
                    editable: true
                 },
                {
                    id: 3,
                    title  : 'Received rejection notice',
                    start  : '2016-10-19',
                    editable : false

                }
            ],
            eventDrop: function(event,revertFunc) {


                if (!confirm("Do you want to save this event?")) {
                    revertFunc(); 
                }
                else{
                    //*****save changes in database****
                }

            },

            dayClick: function(date, jsEvent, view) {
                var name = prompt('Enter a description:');
                if (name){
                    $('#calendar').fullCalendar('renderEvent', { title: name, start: date, }, true );
                }

            },

            eventClick: function(calEvent, jsEvent, view) {
                var action = prompt('Are you sure you want to delete this event?', calEvent.title, {buttons: {OK: true, Cancel: false} });
                //var name = prompt('Description:', calEvent.title, { buttons: { OK: true, Cancel: false} });

                if (action){
                    $('#calendar').fullCalendar('removeEvents', calEvent.id);
                    //*****remove event in database******
                }

                // edits an event title
                // if (name) {
                //   calEvent.title = name;
                //   $('#calendar').fullCalendar('updateEvent',calEvent);
                //   //save event in database*****
                // }
            },
            eventConstraint: {
                start: moment().format('YYYY-MM-DD'),
                end: '2050-05-05'
            }
    });

});