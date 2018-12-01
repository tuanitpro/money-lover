import React, {Component} from 'react'
import {shallow, mount } from "enzyme";

import RadioButton from './RadioButton';

describe("RadioButton", () => {
    let props;
    let mountedRadioButton;    

    beforeEach(() => {
      props = {
        
      };
      mountedRadioButton = undefined;
    });
    
     it('Render a snapshot for RadioButto use enzyme', () => {
        mountedRadioButton = shallow(<RadioButton {...props} />);        
        expect(mountedRadioButton).toMatchSnapshot();
    })
  });