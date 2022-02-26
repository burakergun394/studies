import React, { Component } from "react";
import { Form, FormGroup, Input, Label, Button } from "reactstrap";
import alertify from "alertifyjs";

export default class Form2 extends Component {
  state = { email: "", password: "", city: "", description: "" };

  onChangeHandler = (event) => {
    const name = event.target.name;
    const value = event.target.value;

    this.setState({ [name]: value });
  };

  onSubmitHandler = (event) => {
    event.preventDefault();
    alertify.success(`${this.state.email} added to memory`, 2);
    alertify.success(`${this.state.password} added to memory`, 2);
    alertify.success(`${this.state.city} added to memory`, 2);
    alertify.success(`${this.state.description} added to memory`, 2);
  };

  render() {
    return (
      <Form onSubmit={this.onSubmitHandler}>
        <FormGroup>
          <Label for="email">Email</Label>
          <Input
            type="email"
            name="email"
            id="email"
            placeholder="Enter an email..."
            onChange={this.onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Label for="password">Password</Label>
          <Input
            type="password"
            name="password"
            id="password"
            placeholder="Enter a password..."
            onChange={this.onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Label for="city">City</Label>
          <Input
            type="select"
            name="city"
            id="city"
            onChange={this.onChangeHandler}
          >
            <option>Ankara</option>
            <option>Adana</option>
            <option>İzmir</option>
            <option>İstanbul</option>
          </Input>
        </FormGroup>
        <FormGroup>
          <Label for="description">Description</Label>
          <Input
            type="textarea"
            name="description"
            id="description"
            placeholder="Enter a description..."
            onChange={this.onChangeHandler}
          />
        </FormGroup>
        <FormGroup>
          <Button type="submit">Save</Button>
        </FormGroup>
      </Form>
    );
  }
}
