import React from "react";
import IconButton from "../template/iconButton";

export default props => {
  const renderRows = () => {
    const list = props.list || [];
    return list.map(hotel => (
      <tr className="col-md-12" key={hotel.id}>
        <td className="col-md-8">{hotel.name}</td>
        <td className="col-md-2">
          <IconButton
            style="success"
            icon="edit"
            hide={false}
            onClick={() => props.handleEdit(hotel)}
          />
        </td>
        <td className="col-md-2">
          <IconButton
            style="danger"
            icon="trash-o"
            hide={false}
            onClick={() => props.handleRemove(hotel)}
          ></IconButton>
        </td>
      </tr>
    ));
  };

  return (
    <table className="table">
      <thead>
        <tr className="col-md-12">
          <th className="col-md-8">Nome do hotel</th>
          <th></th>
          <th className="col-md-4">Ações</th>
        </tr>
      </thead>
      <tbody>{renderRows()}</tbody>
    </table>
  );
};
