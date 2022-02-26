import React, { Component } from "react";
import { Table, Button } from "reactstrap";

export default class CartList extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  renderCartList = () => {
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
                      onClick={() =>
                        this.props.removeFromCart(cartItem.product)
                      }
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

  render() {
    return (
      <div>
        {this.props.cart.length > 0
          ? this.renderCartList()
          : this.renderEmpty()}
      </div>
    );
  }
}
