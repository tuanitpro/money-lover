import React, { Component } from 'react'
import PropTypes from 'prop-types';
import { Input, Label } from 'reactstrap'
class RadioButton extends Component {
    constructor(props) {
        super(props);
        this.state = {
            selectedValue: '1'
        };

        this.handleOnChange = this.handleOnChange.bind(this);
    }
    handleOnChange(changeEvent) {
        let getValue = changeEvent.target.value;
        this.setState({
            selectedValue: changeEvent.target.value
        });
        this.props.onChecked(getValue);
    }
    componentDidMount() {
        const { defaultValue } = this.props;
        this.setState({ selectedValue: defaultValue });
    }
    componentDidUpdate() {

    }
    render() {
        const { selectedValue } = this.state;
        return (
            <div className="iradio">
                <Input id="expenseMode" type="radio" name="expenseType" value={1} checked={selectedValue === '1'} onChange={e => this.handleOnChange(e)} />
                <Label for="expenseMode" className="radio">Chi</Label>
                <Input id="incomeMode" type="radio" name="expenseType" value={0} checked={selectedValue === '0'} onChange={e => this.handleOnChange(e)} />
                <Label for="incomeMode" className="radio">Thu</Label>
            </div>
        )
    }
}
RadioButton.propTypes = {
    onChecked: PropTypes.func,
    defaultValue: PropTypes.string
}
RadioButton.defaultProps = {
    defaultValue: '',
    onChecked: () => { }
}
export default RadioButton