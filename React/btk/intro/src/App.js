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
      currentCategoryId: "",
      products: [],
    };
  }

  componentDidMount() {
    this.getProducts();
  }

  changeCategory = (categoryId) => {
    this.setState({ currentCategoryId: categoryId });
    this.getProductsByCategoryId(categoryId);
  };

  getProducts = () => {
    fetch(`http://localhost:3000/products`)
      .then((response) => response.json())
      .then((data) =>
        this.setState({
          products: data,
        })
      );
  };

  getProductsByCategoryId = (categoryId) => {
    fetch(`http://localhost:3000/products?categoryId=${categoryId}`)
      .then((response) => response.json())
      .then((data) =>
        this.setState({
          products: data,
        })
      );
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
                currentCategoryId={this.state.currentCategoryId}
                changeCategory={this.changeCategory}
              />
            </Col>
            <Col xs="9">
              <ProductList
                info={this.productInfo}
                products={this.state.products}
              />
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}
