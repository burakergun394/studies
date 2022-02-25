import React, { Component } from "react";

export default class ProductList extends Component {
  constructor(props) {
    super(props);
    state: {
    }
  }
  render() {
    return <div>{this.props.info.title}</div>;
  }
}
