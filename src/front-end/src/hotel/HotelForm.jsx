import React from "react";
import Grid from "../template/grid";
import IconButton from "../template/iconButton";
import IconHref from "../template/iconHref";

export default props => {
  const keyHandler = e => {
    if (e.key === "Enter") {
      e.shiftKey ? props.handleSearch() : props.handleAdd();
    } else if (e.key === "Escape") {
      props.handleClear();
    }
  };

  return (
    <React.Fragment>
        <div role='form' className='hotelForm row'>
            <Grid cols='12 9 10'>
                <input type="text" id="description" className="form-control" placeholder="Digite o nome do hotel para buscar (não implementado)"
                value={props.description}
                onKeyUp={keyHandler}
                onChange={props.handleChange} />
            </Grid>
            <Grid cols='12 3 2'>
                <IconHref style='primary' icon='plus' onClick={"#/registro/hotel"}></IconHref>
                <IconButton style='info' icon='search' onClick={props.handleSearch}></IconButton>
            </Grid>
        </div>
    </React.Fragment>
  );
};
