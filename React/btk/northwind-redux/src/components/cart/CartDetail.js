import React, { Component } from "react";
import { connect } from "react-redux";
import * as cartActions from "../../redux/actions/cartActions";
import { bindActionCreators } from "redux";
import { Table, Button } from "reactstrap";
import alertify from "alertifyjs";

class CartDetail extends Component {
  renderCartDetail = () => {
    return (
      <div>
        <Table>
          <thead>
            <tr>
              <th>Product Id</th>
              <th>Category Id</th>
              <th>Product Name</th>
              <th>Quantity Per Unit</th>
              <th>Unit Price</th>
              <th>Quantity</th>
              <th></th>
            </tr>
          </thead>
          <tbody>
            {this.props.cart.map((cartItem) => {
              return (
                <tr key={cartItem.product.id}>
                  <td>{cartItem.product.id}</td>
                  <td>{cartItem.product.categoryId}</td>
                  <td>{cartItem.product.productName}</td>
                  <td>{cartItem.product.quantityPerUnit}</td>
                  <td>{cartItem.product.unitPrice}</td>
                  <td>{cartItem.quantity}</td>
                  <td>
                    <Button
                      color="danger"
                      onClick={() => this.removeFromCart(cartItem.product)}
                    >
                      remove
                    </Button>
                  </td>
                </tr>
              );
            })}
          </tbody>
        </Table>
      </div>
    );
  };

  renderEmpty = () => {
    return <div>Empty cart</div>;
  };

  removeFromCart = (product) => {
    this.props.actions.removeFromCart(product);
    alertify.error(product.productName + " removed from cart.", 2);
  };

  render() {
    return (
      <div>
        {this.props.cart.length > 0
          ? this.renderCartDetail()
          : this.renderEmpty()}
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    cart: state.cartReducer,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: {
      removeFromCart: bindActionCreators(cartActions.removeFromCart, dispatch),
    },
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(CartDetail);
