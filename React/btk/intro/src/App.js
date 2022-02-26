import React, { Component } from "react";
import { Container, Row, Col } from "reactstrap";
import Navi from "./Navi";
import CategoryList from "./CategoryList";
import ProductList from "./ProductList";
import alertify from "alertifyjs";
import { Routes, Route } from "react-router-dom";
import NotFound from "./NotFound";
import CartList from "./CartList";

export default class App extends Component {
  constructor(props) {
    super(props);
    this.categoryInfo = { title: "CategoryList" };
    this.productInfo = { title: "ProductList" };
    this.state = {
      currentCategoryId: "",
      products: [],
      cart: [],
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

  addToCart = (product) => {
    let newCart = this.state.cart;
    let addedItem = newCart.find((x) => x.product.id === product.id);
    if (addedItem) {
      addedItem.quantity += 1;
    } else {
      newCart.push({ product: product, quantity: 1 });
    }
    this.setState({ cart: newCart });

    alertify.success(`${product.productName} added to cart`, 2);
  };

  removeFromCart = (product) => {
    let newCart = this.state.cart.filter(
      (cartItem) => cartItem.product.id !== product.id
    );
    this.setState({ cart: newCart });
  };

  render() {
    return (
      <div className="App">
        <Container>
          <Navi
            cart={this.state.cart}
            removeFromCart={this.removeFromCart}
          ></Navi>
          <Row>
            <Col xs="3">
              <CategoryList
                info={this.categoryInfo}
                currentCategoryId={this.state.currentCategoryId}
                changeCategory={this.changeCategory}
              />
            </Col>
            <Col xs="9">
              <Routes>
                <Route
                  exact
                  path="/"
                  element={
                    <ProductList
                      info={this.productInfo}
                      products={this.state.products}
                      addToCart={this.addToCart}
                    />
                  }
                />
                <Route exact path="cart" element={<CartList />} />
                <Route path="*" element={<NotFound />} />
              </Routes>
            </Col>
          </Row>
        </Container>
      </div>
    );
  }
}
