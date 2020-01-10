import React from "react";
import PageHeader from "../template/pageHeader";

export default props => (
  <div>
    <PageHeader name="Sobre" small="" />
    <h2>Sobre o teste</h2>
    <p>Demorou mais saiu, hehe.</p>
    <p>
      Demorei pra fazer por conta da correria de uma entrega agora no fim de
      ano, está implementado o básico em uma arquitetura aproveitada de um curso
      que fiz.
    </p>
    <p>
      Tem algumas validações no front-end e outras trazendo a mensagem direto do
      backend, tem componentes funcionais e classes.
    </p>
    <p>
      OBS: utilize a seguinte url para bater na api:
      http://localhost:5000/api/v1/hotel
    </p>
    <p>
      Você consegue essa URL rodando o comando dotnet run na pasta Hotel.API em
      HotelContext
    </p>
  </div>
);
