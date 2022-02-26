import React, { Component } from "react";
import { connect } from "react-redux";
import { bindActionCreators } from "redux";
import { increaseCounter } from "../redux/actions/counterActions";

class IncreaseCounter extends Component {
  onClickHandler = (e) => {
    this.props.dispatch(increaseCounter());
  };

  render() {
    return (
      <div>
        <button onClick={this.onClickHandler}>1 arttır</button>
      </div>
    );
  }
}

function mapDispatchToProps(dispatch) {
  return { actions: bindActionCreators(increaseCounter, dispatch) };
}

export default connect(mapDispatchToProps)(IncreaseCounter);
