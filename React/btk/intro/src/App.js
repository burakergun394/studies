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
    this.state = {
      currentCategory: "",
    };
  }

  changeCategory = (categoryName) => {
    this.setState({ currentCategory: categoryName });
  };

  render() {
    return (
      <div className="App">
        <Container>
          <Row>
            <Navi></Navi>
          </Row>
          <Row>
            <Col xs="3">
              <CategoryList
                info={this.categoryInfo}
                currentCategory={this.state.currentCategory}
                changeCategory={this.changeCategory}
              />
            </Col>
            <Col xs="9">
              <ProductList
                info={this.productInfo}
                currentCategory={this.state.currentCategory}
              />
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}
