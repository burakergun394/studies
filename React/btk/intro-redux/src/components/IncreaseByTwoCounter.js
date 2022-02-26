import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { increaseByTwoCounter } from "../redux/actions/counterActions";

class IncreaseByTwoCounter extends Component {
  onClickHandler = (e) => {
    this.props.dispatch(increaseByTwoCounter());
  };

  render() {
    return (
      <div>
        <button onClick={this.onClickHandler}>2 arttır</button>
      </div>
    );
  }
}

function mapDispatchToProps(dispatch) {
  return { actions: bindActionCreators(increaseByTwoCounter, dispatch) };
}

export default connect(mapDispatchToProps)(IncreaseByTwoCounter);
