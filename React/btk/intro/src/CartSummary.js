import React, { Component } from "react";
import {
  UncontrolledDropdown,
  DropdownToggle,
  DropdownMenu,
  DropdownItem,
  Badge,
  NavItem,
  NavLink,
} from "reactstrap";
import { Link } from "react-router-dom";

export default class CartSummary extends Component {
  constructor(props) {
    super(props);
    this.state = {};
  }

  renderFillCart = () => {
    return (
      <UncontrolledDropdown inNavbar nav>
        <DropdownToggle caret nav>
          Your Cart
        </DropdownToggle>
        <DropdownMenu end>
          {this.props.cart.map((c) => {
            return (
              <DropdownItem key={c.product.id}>
                <Badge
                  color="danger"
                  onClick={() => this.props.removeFromCart(c.product)}
                >
                  X
                </Badge>
                <Badge color="success">{c.quantity}</Badge>
                {c.product.productName}
              </DropdownItem>
            );
          })}
          <DropdownItem divider />
          <DropdownItem>
            <Link to="Cart">Go to cart</Link>
          </DropdownItem>
        </DropdownMenu>
      </UncontrolledDropdown>
    );
  };

  renderEmptyCart = () => {
    return (
      <NavItem>
        <NavLink href="#">Empty Cart</NavLink>
      </NavItem>
    );
  };

  render() {
    return (
      <div>
        {this.props.cart.length > 0
          ? this.renderFillCart()
          : this.renderEmptyCart()}
      </div>
    );
  }
}
