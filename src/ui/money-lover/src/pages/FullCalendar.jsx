import React, { Component } from 'react';
import $ from 'jquery';
import moment from 'moment';
import fullCalendar from "fullcalendar";
import '../assets/fullcalendar.min.css';
const dataSource = {
    events: [
        {
            title: 'event1',
            start: '2018-02-01'
        },
        {
            title: 'event2',
            start: '2018-12-05',
            end: '2018-12-07'
        },
        {
            title: 'event3',
            start: '2018-12-09T12:30:00',
            allDay: false // will make the time show
        }
    ]
};
class FullCalendar extends Component {
    componentDidMount() {
        $('#fullcalendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            editable: true,
            droppable: true, // this allows things to be dropped onto the calendar
            drop: function () {
                // is the "remove after drop" checkbox checked?
                if ($('#drop-remove').is(':checked')) {
                    // if so, remove the element from the "Draggable Events" list
                    $(this).remove();
                }
            },
            events: dataSource.events,
            dayClick: function(date, jsEvent, view) {

                alert('Clicked on: ' + date.format());
            
                alert('Coordinates: ' + jsEvent.pageX + ',' + jsEvent.pageY);
            
                alert('Current view: ' + view.name);
            
                // change the day's background color just for fun
                $(this).css('background-color', 'red');
            
              }
        })
    }
    render() {
        return (
            <div id="fullcalendar"></div>
        )
    }
}

export default FullCalendar