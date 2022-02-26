import React, { Component } from "react";
import { connect } from "react-redux";
import { ListGroup, ListGroupItem } from "reactstrap";
import { bindActionCreators } from "redux";
import * as categoryActions from "../../redux/actions/categoryActions";
import * as productActions from "../../redux/actions/productActions";
import { Badge } from "reactstrap";

class CategoryList extends Component {
  componentDidMount() {
    this.props.actions.getCategories();
  }

  onClickHandler = (category) => {
    this.props.actions.changeCategory(category);
    this.props.actions.getProducts(category.id);
  };

  selectCategory = (category) => {
    const result = this.props.currentCategory.id === category.id;
    return result;
  };

  render() {
    return (
      <div>
        <h3>
          <Badge color="warning">Categories</Badge>
        </h3>
        <ListGroup>
          {this.props.categories.map((category) => {
            return (
              <ListGroupItem
                key={category.id}
                onClick={() => this.onClickHandler(category)}
                active={this.selectCategory(category)}
              >
                {category.categoryName}
              </ListGroupItem>
            );
          })}
        </ListGroup>
        <h5>{this.props.currentCategory.categoryName}</h5>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    currentCategory: state.changeCategoryReducer,
    categories: state.categoryListReducer,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    actions: {
      getCategories: bindActionCreators(
        categoryActions.getCategories,
        dispatch
      ),
      changeCategory: bindActionCreators(
        categoryActions.changeCategory,
        dispatch
      ),
      getProducts: bindActionCreators(productActions.getProducts, dispatch),
    },
  };
}

export default connect(mapStateToProps, mapDispatchToProps)(CategoryList);
