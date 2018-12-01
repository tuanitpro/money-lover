import React, { Component } from 'react';
import { Container, Row, Col } from 'reactstrap';
import Header from './pages/Header';
import MainForm from './pages/MainForm';
import FullCalendar from './pages/FullCalendar';
import EventCalendar from './pages/EventCalendar';

class App extends Component {
  constructor(props){
    super(props);
    this.handleOnSaveForm = this.handleOnSaveForm.bind(this);
    this.state={
      event: null,
    }
  }

  handleOnSaveForm(event){   
    if(event){
      this.setState({
        event
      })
    }
  }

  render() {
    return (
      <div>
        <Header />      
        <Container fluid={true}>
          <Row>
            <Col md="3">               
                <MainForm onSave={this.handleOnSaveForm}/>                              
            </Col>
            <Col md="9">
              <div className="main-calendar">
                <FullCalendar newEvent={this.state.event}/>
              </div>
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}

export default App;
