import React, { Component } from "react";
import { Container, Row, Col } from "reactstrap";
import Navi from "./Navi";
import CategoryList from "./CategoryList";
import ProductList from "./ProductList";

export default class App extends Component {
  constructor(props) {
    super(props);
    this.categoryInfo = { title: "CategoryList" };
    this.productInfo = { title: "ProductList" };
  }

  render() {
    return (
      <div className="App">
        <Container>
          <Row>
            <Navi></Navi>
          </Row>
          <Row>
            <Col xs="3">
              <CategoryList info={this.categoryInfo}></CategoryList>
            </Col>
            <Col xs="9">
              <ProductList info={this.productInfo}></ProductList>
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}
