import React from 'react'

export default props => (
    // <nav className="navbar navbar-inverse bg-inverse">
    //     <div className="container">
    //         <div className="navbar-header">
    //             <a href="#" className="navbar-brand">
    //                 <i className="fa fa-calendar-check-o">Hotel App</i>
    //             </a>
    //         </div>
    //         <div className="navbar-collapse collapse" id="navbar">
    //             <ul className="nav navbar-nav">
    //                 <li><a href="#/todos">Hoteis</a></li>
    //                 <li><a href="#/about">Sobre</a></li>
    //             </ul>
    //         </div>
    //     </div>
    // </nav>
    <React.Fragment>
    <nav class="navbar navbar-expand-lg navbar-dark bg-dark">
  <a class="navbar-brand" href="#/hoteis">Teste - ExpenseOn</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="navbarSupportedContent">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item active">
        <a class="nav-link" href="#/hoteis">Hoteis <span class="sr-only">(current)</span></a>
      </li>
      <li class="nav-item">
        <a class="nav-link" href="#/sobre">Sobre</a>
      </li>
    </ul>
  </div>
</nav>
</React.Fragment>

)