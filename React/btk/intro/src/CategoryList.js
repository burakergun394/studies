import React, { Component } from "react";
import { ListGroup, ListGroupItem } from "reactstrap";

export default class CategoryList extends Component {
  constructor(props) {
    super(props);
    this.state = {
      categories: [],
    };
  }

  componentDidMount() {
    this.getCategories();
  }

  getCategories = () => {
    fetch("http://localhost:3000/categories")
      .then((response) => response.json())
      .then((data) =>
        this.setState({
          categories: data,
        })
      );
  };

  setCategoryActive = (categoryId) => {
    return this.props.currentCategoryId === categoryId ? true : false;
  };

  render() {
    return (
      <div>
        <h3>{this.props.info.title}</h3>
        <ListGroup>
          {this.state.categories.map((category) => {
            return (
              <ListGroupItem
                onClick={() => {
                  this.props.changeCategory(category.id);
                }}
                key={category.id}
                active={this.setCategoryActive(category.id)}
              >
                {category.categoryName}
              </ListGroupItem>
            );
          })}
        </ListGroup>
      </div>
    );
  }
}
