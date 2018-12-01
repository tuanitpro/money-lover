import React, { Component } from 'react';
import BigCalendar from 'react-big-calendar'
import 'react-big-calendar/lib/css/react-big-calendar.css';
import moment from 'moment'
import axios from 'axios';
const localizer = BigCalendar.momentLocalizer(moment)

class EventCalendar extends Component {
    constructor(props) {
        super(props);
        this.state = {
            events: []
        }
    }

    async  componentDidMount() {
        var eventSource = await axios.get('https://localhost:44344/api/v1/events');
        this.setState({ events: eventSource.data.data });
    }

    render() {
        const { events } = this.state
        return (
            <div>
                <BigCalendar
                    localizer={localizer}
                    events={events}
                    startAccessor="start"
                    endAccessor="end"
                />
            </div>
        )
    }
}
export default EventCalendar
