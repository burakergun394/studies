import React, { Component } from "react";
import { Form, FormGroup, Input, Label } from "reactstrap";

export default class Form1 extends Component {
  state = { userName: "", city: "" };

  onChangeUsernameHandler = (event) => {
    this.setState({ userName: event.target.value });
    // onChangeHandler fonksiyonu daha kullanışlı
  };

  onChangeHandler = (event) => {
    const name = event.target.name;
    const value = event.target.value;
    this.setState({ [name]: value });
  };

  onSubmitForm = (event) => {
    event.preventDefault();
    alert(this.state.userName);
  };

  render() {
    return (
      <Form onSubmit={this.onSubmitForm}>
        <FormGroup>
          <Label for="userName">Username</Label>
          <Input
            id="userName"
            name="userName"
            placeholder="userName"
            type="text"
            onChange={this.onChangeHandler}
          />
          <Label for="userName">Username is {this.state.userName}</Label>
        </FormGroup>
        <FormGroup>
          <Label for="city">City</Label>
          <Input
            id="city"
            name="city"
            placeholder="city"
            type="text"
            onChange={this.onChangeHandler}
          />
          <Label for="city">City is {this.state.city}</Label>
        </FormGroup>
        <FormGroup>
          <Input type="submit" value="Save" />
        </FormGroup>
      </Form>
    );
  }
}
