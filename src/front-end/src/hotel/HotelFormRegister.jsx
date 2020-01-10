import React, { Component, isValidElement } from "react";
import Grid from "../template/grid";
import IconButton from "../template/iconButton";
import axios from "axios";
import IF from "../template/If";
import If from "../template/If";
import "../template/custom.css";
import swal from "sweetalert";

const URL = "http://localhost:5000/api/v1/hotel";

const keyHandler = e => {
  if (e.key === "Enter") {
    e.shiftKey ? this.props.handleSearch() : this.props.handleAdd();
  } else if (e.key === "Escape") {
    this.props.handleClear();
  }
};

class HotelRegister extends Component {
  constructor(props) {
    super(props);

    this.handleChange = this.handleChange.bind(this);

    this.state = {
      referenceId: 0,
      nameHotel: "",
      description: "",
      rating: 0,
      street: "",
      number: "",
      zipCode: "",
      state: "",
      city: "",
      featureDescriptions: "",
      isNameValid: false,
      isRatingValid: false
    };
  }

  componentDidMount() {
    if (this.props.match.params.id && this.props.match.params.id != null) {
      axios.get(`${URL}/` + this.props.match.params.id).then(resp =>
        this.setState({
          referenceId: resp.data.id,
          nameHotel: resp.data.name,
          description: resp.data.description,
          rating: resp.data.rating,
          street: resp.data.street,
          number: resp.data.number,
          zipCode: resp.data.zipCode,
          state: resp.data.state,
          city: resp.data.city,
          featureDescriptions: resp.data.featureDescriptions,
          isNameValid: true,
          isRatingValid: true
        })
      );
    }
  }
  componentDidUpdate(prevProps, prevState) {
    console.log(this.state)
  }

  handleChange(e) {
    let change = {};
    change[e.target.name] = e.target.value;
    this.validationField(e.target.name, e.target.value);
    this.setState(change);
  }

  validationField(fieldName, fieldValue) {
    switch (fieldName) {
      case "nameHotel": {
        let isNameValid = fieldValue && fieldValue.length > 3;
        this.setState({ isNameValid });
      }
      case "rating": {
        let isRatingValid =
          parseInt(fieldValue) > 0 && parseInt(fieldValue) < 6;
        this.setState({ isRatingValid });
      }
    }
  }

  handleAdd() {
    if (this.state.isNameValid && this.state.isRatingValid) {
      let model = {
        name: this.state.nameHotel,
        description: this.state.description,
        rating: parseInt(this.state.rating),
        street: this.state.street,
        number: this.state.number,
        zipCode: this.state.zipCode,
        state: this.state.state,
        city: this.state.city,
        featureDescriptions: this.state.featureDescriptions
      };

      if (this.state.referenceId && parseInt(this.state.referenceId) > 0) {
        axios.put(`${URL}/` + this.state.referenceId, model).then(resp => {
          console.log("TCL: HotelRegister -> handleAdd -> resp", resp);
          swal("Mensagem!", resp.data.message);
        });
      } else {
        axios.post(URL, model).then(resp => {
          console.log("TCL: HotelRegister -> handleAdd -> resp", resp);
          swal("Mensagem!", resp.data.message);
        });
      }
    }
  }

  render() {
    return (
      <React.Fragment>
        <div className="form-group mt-3">
          <h5>Dados Básicos</h5>
          <hr />
        </div>
        <div className="form-group">
          <label>Nome</label>
          <input
            type="text"
            class="form-control"
            placeholder="Digite o nome do hotel"
            onChange={this.handleChange}
            value={this.state.nameHotel}
            name="nameHotel"
          />
          <If test={!this.state.isNameValid}>
            <small id="emailHelp" class="form-text text-muted text-red">
              O campo nome é obrigatório, e deve possuir ao menos 3 letras.
            </small>
          </If>
        </div>
        <div className="form-group">
          <label>Descrição</label>
          <textarea
            type="text"
            class="form-control"
            placeholder="Conte um pouco sobre o seu hotel"
            onChange={this.handleChange}
            value={this.state.description}
            name="description"
          />
        </div>
        <div className="form-group">
          <label>Avaliação</label>
          <input
            type="text"
            class="form-control"
            placeholder="Informe aqui quantas estrelas o seu hotel possui."
            onChange={this.handleChange}
            value={this.state.rating}
            name="rating"
          />
          <If test={!this.state.isRatingValid}>
            <small id="emailHelp" class="form-text text-muted text-red">
              O campo avaliação é obrigatório, e deve ser um número, e deve
              entre 1 e 5.
            </small>
          </If>
        </div>
        <div className="form-group">
          <h5>Endereço</h5>
          <hr />
        </div>
        <div className="form-group">
          <label>Rua</label>
          <input
            type="text"
            class="form-control"
            placeholder="Informe o nome da rua que seu hotel está localizado"
            onChange={this.handleChange}
            value={this.state.street}
            name="street"
          />
        </div>
        <div className="form-group">
          <label>Número</label>
          <input
            type="text"
            class="form-control"
            placeholder="Informe o número na rua que seu hotel está localizado"
            onChange={this.handleChange}
            value={this.state.number}
            name="number"
          />
        </div>
        <div className="form-group">
          <label>CEP</label>
          <input
            type="text"
            class="form-control"
            placeholder="Informe o CEP que seu hotel está localizado"
            onChange={this.handleChange}
            value={this.state.zipCode}
            name="zipCode"
          />
        </div>
        <div className="form-group">
          <label>Estado</label>
          <input
            type="text"
            class="form-control"
            placeholder="Informe o estado que seu hotel está localizado"
            onChange={this.handleChange}
            value={this.state.state}
            name="state"
          />
        </div>
        <div className="form-group">
          <label>Cidade</label>
          <input
            type="text"
            class="form-control"
            placeholder="Informe o cidade que seu hotel está localizado"
            onChange={this.handleChange}
            value={this.state.city}
            name="city"
          />
        </div>
        <div className="form-group">
          <label>Comodidades</label>
          <textarea
            class="form-control"
            placeholder="Informe as comidades que seu hotel oferece ex: (wi-fi, estacionamento, etc)."
            onChange={this.handleChange}
            value={this.state.featureDescriptions}
            name="featureDescriptions"
          />
        </div>
        <button class="btn btn-primary" onClick={() => this.handleAdd()}>
          {this.state.referenceId ? "Atualizar" : "Cadastrar"}
        </button>
      </React.Fragment>
    );
  }
}

export default HotelRegister;
