import React, { Component } from "react";
import Grid from "../template/grid";
import IconButton from "../template/iconButton";
import axios from "axios";

const URL = "http://localhost:5000/api/v1/hotel";

const keyHandler = e => {
  if (e.key === "Enter") {
    e.shiftKey ? this.props.handleSearch() : this.props.handleAdd();
  } else if (e.key === "Escape") {
    this.props.handleClear();
  }
};

let initialState = {
  referenceId: 0
};

class HotelRegister extends Component {
  state = initialState;

  componentDidMount() {
    if (this.props.match.params.id != null) {
      this.setState({ referenceId: this.props.match.params.id });
    }
  }

  render() {
    return (
      <React.Fragment>
        <div role="form" className="hotelForm">
          <Grid cols="12 9 10">
            <input
              type="text"
              id="description"
              className="form-control"
              placeholder="Digite o nome do hotel para buscar"
              value={this.props.description}
              onKeyUp={keyHandler}
              onChange={this.props.handleChange}
            />
          </Grid>
          <Grid cols="12 3 2">
            <IconButton
              style="primary"
              icon="plus"
              onClick={this.props.handleAdd}
            ></IconButton>
          </Grid>
        </div>
      </React.Fragment>
    );
  }
}

export default HotelRegister;
