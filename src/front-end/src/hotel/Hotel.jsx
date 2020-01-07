import React, { Component } from "react";
import PageHeader from "../template/pageHeader";
import HotelForm from "./HotelForm";
import HotelList from "./HotelList";
import axios from "axios";

const URL = "http://localhost:5000/api/v1/hotel";

export default class Hotel extends Component {
  constructor(props) {
    super(props);

    this.handleAdd = this.handleAdd.bind(this);
    this.handleChange = this.handleChange.bind(this);
    this.handleRemove = this.handleRemove.bind(this);
    this.handleMarkAsDone = this.handleMarkAsDone.bind(this);
    this.handleMarkAsPending = this.handleMarkAsPending.bind(this);
    this.handleSearch = this.handleSearch.bind(this);
    this.handleClear = this.handleClear.bind(this);

    this.state = { description: "", list: [] };

    this.refresh();
  }

  refresh(description = "") {
    axios
      .get(`${URL}`)
      .then(resp =>
        this.setState({ ...this.state, description, list: resp.data })
      );
  }

  handleAdd() {
    // const description = this.state.description
    // axios.post(URL, {description})
    // .then(resp => this.refresh())
  }

  handleChange(e) {
    this.setState({ ...this.state, description: e.target.value });
  }

  handleRemove(Hotel) {
    // axios.delete(`${URL}/${Hotel._id}`)
    // .then(resp => this.refresh(this.state.description))
  }
  handleMarkAsDone(Hotel) {
    axios
      .put(`${URL}/${Hotel._id}`, { ...Hotel, done: true })
      .then(resp => this.refresh(this.state.description));
  }
  handleMarkAsPending(Hotel) {
    // axios.put(`${URL}/${Hotel._id}`, {...Hotel, done:false})
    // .then(resp => this.refresh(this.state.description))
  }
  handleSearch() {
    // this.refresh(this.state.description)
  }
  handleClear() {
    // this.refresh()
  }

  render() {
    return (
      <div>
        <PageHeader name="Lista" small="Hoteis" />
        <HotelForm
          description={this.state.description}
          handleAdd={this.handleAdd}
          handleChange={this.handleChange}
          handleSearch={this.handleSearch}
          handleClear={this.handleClear}
        />
        <HotelList
          list={this.state.list}
          handleRemove={this.handleRemove}
          handleMarkAsDone={this.handleMarkAsDone}
          handleMarkAsPending={this.handleMarkAsPending}
        />
      </div>
    );
  }
}
