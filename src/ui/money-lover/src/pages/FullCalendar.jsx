import React, { Component } from 'react';
import axios from 'axios';
import $ from 'jquery';
import moment from 'moment';
import fullCalendar from "fullcalendar";
import '../assets/fullcalendar.min.css';

import MoneyLoverService from '../services/MoneyLoverService';

class FullCalendar extends Component {

    constructor(props) {
        super(props);
        this.state = {
            events: [],
            start: null,
            end: null,
        };

        this.updateEvents = this.updateEvents.bind(this);
        this.getEvents = this.getEvents.bind(this);
    }


    async componentDidUpdate(prevProps, prevState) {
        const { newEvent } = this.props;
        if (newEvent) {
            let { events } = this.state;
            if (events) {
                events.push({
                    title: newEvent.categoryName,
                    description: newEvent.note,
                    start: newEvent.createdDate,
                    end: newEvent.createdDate,
                    color: newEvent.expenseType === '1' ? 'red' : 'green',
                    allDay: true
                });
            }
            this.updateEvents();
        }
    }

    async  componentDidMount() {
        var eventSource = await axios.get('https://localhost:44344/api/v1/events');
        this.setState({ events: eventSource.data.data });

        //  const { events } = this.state;
        this.updateEvents();

    }
    componentWillUnmount() {
        $('#fullcalendar').fullCalendar('destroy');
    }
    async  getEvents(start, end, timezone, callback) {
        // console.log(start);
        // console.log(end);
        // var eventSource = await MoneyLoverService.getEvents(moment(start).format("YYYY-MM-DD HH:mm:ss"), moment(end).format("YYYY-MM-DD HH:mm:ss"));
        // let events = eventSource.data;

        // events.push({
        //     title: 'aaaa',
        //     description: 'bbbb',
        //     start: new Date(),
        //     end: new Date()
        // });

        const { events } = this.state;
        console.log(events);
        if (events) {
            callback(events);
        }
    }

    updateEvents() {
        $('#fullcalendar').fullCalendar('destroy');
        $('#fullcalendar').fullCalendar({
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            firstDay: 0, // 1: Monday
            editable: true,
            droppable: true,
            drop: function () {
                // is the "remove after drop" checkbox checked?
                if ($('#drop-remove').is(':checked')) {
                    $(this).remove();
                }
            },
            events: this.getEvents,
            // events: eventsList,
            eventAfterAllRender: function (view) {

            },
            eventClick: function(calEvent, jsEvent, view) {
                alert('Event: ' + calEvent.title+' '+ calEvent.description);
            },
            dayClick: function (date, jsEvent, view) {

                // alert('Clicked on: ' + date.format());

                //  alert('Coordinates: ' + jsEvent.pageX + ',' + jsEvent.pageY);

                // alert('Current view: ' + view.name);

                // change the day's background color just for fun
                // $(this).css('background-color', 'red');

            }
        });
    }


    render() {
        return (
            <div id="fullcalendar" ></div>
        )
    }
}

export default FullCalendar