import React, { Component } from "react";
import { Container, Row, Col } from "reactstrap";
import Navi from "./Navi";
import CategoryList from "./CategoryList";
import ProductList from "./ProductList";

export default class App extends Component {
  render() {
    return (
      <div className="App">
        <Container>
          <Row>
            <Navi></Navi>
          </Row>
          <Row>
            <Col xs="3">
              <CategoryList title="Category List"></CategoryList>
            </Col>
            <Col xs="9">
              <ProductList title="Product List"></ProductList>
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}
