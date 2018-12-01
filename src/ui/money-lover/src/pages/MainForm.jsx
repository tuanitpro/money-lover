import React, { Component } from 'react';
import { Col, Button, Input, FormGroup, Label, Form } from 'reactstrap';
import Select from 'react-select';
import NumberFormat from 'react-number-format';
import RadioButton from '../components/RadioButton';
import MoneyLoverService from '../services/MoneyLoverService';
import moment from 'moment';

import InputMoment from 'input-moment';
import 'input-moment/dist/input-moment.css';

import toastr from 'toastr'
import 'toastr/build/toastr.min.css'
class MainForm extends Component {
    constructor(props) {
        super(props);
        this.state = {
            m: moment(),
            categories: [],
            selectedCategory: null,
            expense: null,
            note: '',
            expenseType: '1'
        };

        this.saveChange = this.saveChange.bind(this);
         this.handleExpenseTypeChange = this.handleExpenseTypeChange.bind(this);
        this.handleChange = this.handleChange.bind(this);
        this.handleChangeDate = this.handleChangeDate.bind(this);
        this.handleExpenseChange = this.handleExpenseChange.bind(this);
    }

    async saveChange(event) {
        const { expense, selectedCategory, expenseType, note, m } = this.state;
        if (!selectedCategory) {
            toastr.warning('Bạn chưa chọn danh mục');
            return;
        }
        if (!expense) {
            toastr.warning('Bạn chưa nhập chi phí');
            return;
        }

        var postModel = {
            money: expense,
            expenseType,
            note,
            createdDate: m.format(),
            categoryId: selectedCategory.value,
            categoryName: selectedCategory.label,
        }
        await MoneyLoverService.addEvent(postModel);
        
        this.props.onSave(postModel);
        toastr.success('Saved');
    }

    handleChangeDate = m => {
        this.setState({
            m,
        });
    };

    handleExpenseTypeChange(value) {             
        this.setState({
            expenseType: value
        });
    }
    handleExpenseChange(values) {
        this.setState({
            expense: values.value
        });
    }

    handleCategoryChange = (selectedCategory) => {
        this.setState({ selectedCategory });
    }

    handleChange = (e) => {
        this.setState({
            [e.target.name]: e.target.value
        })
    }

    async componentWillMount() {
        var categorySource = await MoneyLoverService.getCategories();
        if (categorySource.data) {
            this.setState({ categories: categorySource.data });
        }

        MoneyLoverService.getCategories();
    }

    render() {
        const { categories, selectedCategory, expenseType, note } = this.state;
        return (
            <div className="main-activity">
                <InputMoment
                    onChange={this.handleChangeDate}
                    moment={this.state.m}
                    minStep={1}
                    hourStep={1}
                    prevMonthIcon="fc-icon fc-icon-left-single-arrow"
                    nextMonthIcon="fc-icon fc-icon-right-single-arrow"
                />
                <div className="form">
                    <Form  >
                        <FormGroup   >
                            <Label >Loại</Label>
                            <RadioButton defaultValue={expenseType} onChecked={this.handleExpenseTypeChange}/>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="categoryId" sm={4}>Danh mục</Label>
                            <Col sm={8}>
                                <Select id="categoryId" placeholder="Chọn danh mục" options={categories} value={selectedCategory} onChange={this.handleCategoryChange} />
                            </Col>
                        </FormGroup>
                        <FormGroup row>
                            <Label for="expense" sm={4}>Thu chi</Label>
                            <Col sm={8}>
                                <NumberFormat thousandSeparator={true} suffix={' đ'} name="expense" id="expense" onValueChange={this.handleExpenseChange} className="form-control" />
                            </Col>
                        </FormGroup>
                        <FormGroup >
                            <Label for="note">Ghi chú</Label>
                            <Input type="textarea" name="note" id="note" value={note}
                                onChange={e => this.handleChange(e)} />
                        </FormGroup>
                        <Button type="button" color="primary" className="btn-block" onClick={this.saveChange}>Lưu</Button>
                    </Form>
                </div>
            </div>
        )
    }
}

export default MainForm;